# Recreating the DVLD development database

The schema is generated from the project's actual `AppDbContext` and all Entity Framework mappings. It includes 16 tables, foreign keys, unique indexes, value-object columns, and check constraints. This recreates the current schema with **fictional demo data**; it cannot recover the deleted records.

The API connection string now targets the installed local SQL Server instance `.\SQLEXPRESS`, database `DVLD_DB`, using Windows authentication. The setup tool reads `backend/DVLD.Api/appsettings.json`; `ConnectionStrings__DefaultConnection` overrides that setting for another server/database. It does not read user secrets or other appsettings files. It requires .NET 8 and SQL Server, but no `dotnet-ef` installation.

## Create and populate

Run from PowerShell in the repository root:

```powershell
.\database\Setup.ps1 -Mode Apply
```

This builds the setup tool, exports the SQL, creates the database if absent, and creates the schema and seed data in a transaction. It refuses any target database that already contains user tables and never drops a database. If a SQL error occurs, schema/data changes roll back; a newly created database can remain empty for a retry. Do not run Apply again on the populated database; use Verify.

```powershell
.\database\Setup.ps1 -Mode Verify
```

Verification loads people, users, applications and test histories, licenses, international licenses, and detentions through Entity Framework; checks the demo admin's BCrypt password; and runs `DBCC CHECKCONSTRAINTS`.

To regenerate SQL files without connecting to SQL Server:

```powershell
.\database\Setup.ps1 -Mode Export
```

Export is a fresh snapshot of the current EF model, not a migration for an existing database. Commit these setup files with your code. For future schema changes on populated databases, introduce EF migrations rather than recreating the database.

## SQL Server Management Studio alternative

Connect to `.\SQLEXPRESS` with Windows authentication. Execute `00-create-database.sql`, then select `DVLD_DB` and execute `01-schema.sql`, then `02-seed.sql`. Stop if a script fails. The seed script refuses existing data and wraps all inserts in a transaction; the setup tool is preferred because it wraps schema creation and data insertion together.

## Demo logins

| Username | Password | Role | Active |
| --- | --- | --- | --- |
| admin | admin1234 | Admin (1) | Yes |
| employee | DvldDemo!2026 | Employee (2) | Yes |
| inactive | DvldDemo!2026 | Employee (2) | No |

Passwords are stored as enhanced BCrypt hashes with work factor 12, matching the application's password hasher. These are development accounts. User IDs 1 and 2 can be used for created-by references in API requests.

## Data included

| Table | Rows |
| --- | ---: |
| Countries | 10 |
| ApplicationTypes | 7 |
| LicenseClasses | 7 |
| TestTypes | 3 |
| Persons | 14 |
| Users | 3 |
| Applications | 12 |
| LocalDrivingLicenseApplications | 10 |
| TestAppointments | 20 |
| Tests | 16 |
| Drivers | 3 |
| DrivingLicenses | 3 |
| InternationalLicenses | 1 |
| DetainedLicenses | 2 |
| AuditLogs | 0 |
| UserSessions | 0 |

Reference IDs match the backend enums. Country IDs and fees are demo choices, not original values or official fees. All persons use Morocco (country ID 1), `DEMO0001` through `DEMO0014` national numbers, and `example.com` emails. Dates are calculated relative to SQL Server UTC time when seeding. Sessions and audit logs are created by normal runtime actions.

| Local application ID | Scenario |
| --- | --- |
| 1 | New application; no tests |
| 2 | Vision appointment scheduled |
| 3 | Vision passed; written appointment scheduled |
| 4 | Vision failed; vision retake scheduled |
| 5 | Vision and written passed; street appointment scheduled |
| 6 | Completed; valid ordinary license; international license; prior detention released |
| 7 | Completed; expired ordinary license for exercising renewal |
| 8 | Completed; valid license currently detained |
| 9 | All three tests passed; ready for issuance |
| 10 | Cancelled application |

Person ID 14 has no application and can be used to create a new one. Application IDs 11 and 12 represent international issuance and detention release. Database setup does not fix existing application behavior: the login endpoint currently bypasses password checking, and the renewal expiration condition is reversed, as identified in the project review.

After making changes you want to keep, create a database backup in SSMS (database → Tasks → Back Up) and keep a copy outside this repository. These scripts preserve the schema and initial demo data, not later user-entered records.
