using System.Text.Json;
using System.Text.RegularExpressions;
using DVLD.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// Run from the repository root. No EF CLI installation is needed.
var root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../"));
var output = Path.Combine(root, "database");
var mode = args.FirstOrDefault() ?? "--export";
if (mode is not ("--export" or "--apply" or "--verify" or "--reset-demo-admin-password"))
    throw new ArgumentException("Use --export, --apply, --verify, or --reset-demo-admin-password.");
using var settings = JsonDocument.Parse(File.ReadAllText(Path.Combine(root, "backend/DVLD.Api/appsettings.json")));
var configured = settings.RootElement.GetProperty("ConnectionStrings").GetProperty("DefaultConnection").GetString();
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ?? configured
    ?? throw new InvalidOperationException("DefaultConnection is missing.");
var target = new SqlConnectionStringBuilder(connectionString);
if (string.IsNullOrWhiteSpace(target.InitialCatalog) || new[] { "master", "model", "msdb", "tempdb" }.Contains(target.InitialCatalog, StringComparer.OrdinalIgnoreCase))
    throw new InvalidOperationException("Specify a non-system database in DefaultConnection.");
var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(target.ConnectionString).Options;
await using var db = new AppDbContext(options);
var schema = db.Database.GenerateCreateScript();
if (mode == "--export")
{
    await File.WriteAllTextAsync(Path.Combine(output, "01-schema.sql"),
        "-- Generated from AppDbContext. Run against a new, empty database.\n" +
        "IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)\n" +
        "    THROW 50000, 'Schema creation refused: database already contains tables.', 1;\n" + schema);
    var seedTemplate = await File.ReadAllTextAsync(Path.Combine(output, "seed.template.sql"));
    var adminHash = BCrypt.Net.BCrypt.EnhancedHashPassword("admin1234", workFactor: 12);
    var hash = BCrypt.Net.BCrypt.EnhancedHashPassword("DvldDemo!2026", workFactor: 12);
    if (!BCrypt.Net.BCrypt.EnhancedVerify("admin1234", adminHash)) throw new InvalidOperationException("Password hash verification failed.");
    await File.WriteAllTextAsync(Path.Combine(output, "02-seed.sql"), seedTemplate.Replace("__ADMIN_PASSWORD_HASH__", adminHash).Replace("__PASSWORD_HASH__", hash));
    Console.WriteLine("Exported schema and demo seed SQL from the project model.");
    return;
}
Console.WriteLine($"Target: {target.DataSource} / {target.InitialCatalog}");
if (mode == "--reset-demo-admin-password")
{
    var hash = BCrypt.Net.BCrypt.EnhancedHashPassword("admin1234", workFactor: 12);
    var updated = await db.Users.Where(u => u.UserName == "admin").ExecuteUpdateAsync(setters => setters
        .SetProperty(u => u.PasswordHash, hash).SetProperty(u => u.UpdateAt, DateTime.UtcNow));
    if (updated != 1) throw new InvalidOperationException("Expected exactly one demo admin account.");
    Console.WriteLine("Demo admin password updated.");
}
if (mode == "--apply")
{
    var master = new SqlConnectionStringBuilder(target.ConnectionString) { InitialCatalog = "master" };
    await using (var connection = new SqlConnection(master.ConnectionString))
    {
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = "IF DB_ID(@name) IS NULL BEGIN DECLARE @sql nvarchar(max) = N'CREATE DATABASE ' + QUOTENAME(@name); EXEC(@sql); END";
        command.Parameters.AddWithValue("@name", target.InitialCatalog);
        await command.ExecuteNonQueryAsync();
    }
    await using var sql = new SqlConnection(target.ConnectionString);
    await sql.OpenAsync();
    await using (var check = sql.CreateCommand())
    {
        check.CommandText = "SELECT COUNT(*) FROM sys.tables WHERE is_ms_shipped = 0";
        if (Convert.ToInt32(await check.ExecuteScalarAsync()) != 0)
            throw new InvalidOperationException("Database already contains tables. Setup refuses to overwrite it. Use --verify, or choose a new database name.");
    }
    var seed = await File.ReadAllTextAsync(Path.Combine(output, "02-seed.sql"));
    await using var transaction = (SqlTransaction)await sql.BeginTransactionAsync();
    try
    {
        foreach (var batch in Regex.Split(schema, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase).Where(s => !string.IsNullOrWhiteSpace(s)))
        {
            await using var command = sql.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = batch;
            await command.ExecuteNonQueryAsync();
        }
        await using var insert = sql.CreateCommand();
        insert.Transaction = transaction;
        insert.CommandText = seed;
        await insert.ExecuteNonQueryAsync();
        await transaction.CommitAsync();
        Console.WriteLine("Created schema and demo data. Existing databases were not dropped.");
    }
    catch
    {
        // Seed SQL can already have rolled back the complete transaction.
        if (transaction.Connection != null) await transaction.RollbackAsync();
        throw;
    }
}

// Materialize complete EF graphs to verify columns, value objects, and relationships.
var people = await db.Persons.Include(p => p.NationalityCountry).AsNoTracking().ToListAsync();
var users = await db.Users.Include(u => u.Person).AsNoTracking().ToListAsync();
var applications = await db.LocalDrivingLicenseApplications.Include(a => a.Application).ThenInclude(a => a.Person)
    .Include(a => a.LicenseClass).Include(a => a.TestAppointments).ThenInclude(a => a.Test).AsNoTracking().ToListAsync();
var licenses = await db.Licenses.Include(l => l.Driver).Include(l => l.Application).Include(l => l.LicenseClass).AsNoTracking().ToListAsync();
var international = await db.InternationalLicenses.Include(l => l.LocalLicense).AsNoTracking().ToListAsync();
var detained = await db.DetainedLicenses.Include(l => l.License).AsNoTracking().ToListAsync();
if (!users.Any(u => u.UserName == "admin" && BCrypt.Net.BCrypt.EnhancedVerify("admin1234", u.PasswordHash)))
    throw new InvalidOperationException("Demo admin/password verification failed.");
await using (var integrity = new SqlConnection(target.ConnectionString))
{
    await integrity.OpenAsync();
    await using var command = integrity.CreateCommand();
    command.CommandText = "DBCC CHECKCONSTRAINTS WITH ALL_CONSTRAINTS";
    await using var reader = await command.ExecuteReaderAsync();
    if (await reader.ReadAsync()) throw new InvalidOperationException("Database contains constraint violations.");
}
Console.WriteLine($"Verified: {people.Count} persons, {users.Count} users, {applications.Count} local applications, {licenses.Count} licenses, {international.Count} international licenses, {detained.Count} detention records.");
