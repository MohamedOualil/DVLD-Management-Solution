using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application = DVLD.Domain.Entities.Application;

// Dependency-free regression runner: dotnet run --project tests/DVLD.RetakeTests
var vision = TestType.Create("Vision", "Vision test", Money.Create(20).Value!);
Set(vision, nameof(Entity.Id), 1);
var retakeType = ApplicationType.Create("Retake", Money.Create(5).Value!);
Set(retakeType, nameof(Entity.Id), 7);
var originalType = ApplicationType.Create("Local license", Money.Create(15).Value!);
Set(originalType, nameof(Entity.Id), 1);

var first = Fixture();
var firstAppointment = first.ScheduleTest(vision, DateTime.UtcNow.AddDays(1), 2).Value!;
Check(firstAppointment.RetakeTestApplication is null && firstAppointment.RetakeTestApplicationId is null,
    "First attempt has no retake application");
Check(firstAppointment.PaidFees.Amount == 20, "First attempt charges the test fee");
Check(first.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2, retakeType).IsFailure,
    "An active appointment prevents another booking");

Check(firstAppointment.TakeTest(TestResult.Failure, "Failed", 2).IsSuccess, "Failure is recorded");
Check(first.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2).IsFailure && first.TestAppointments.Count == 1,
    "Missing retake configuration does not create an appointment");
Check(first.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2, originalType).IsFailure,
    "Wrong application type is rejected");
var retry = first.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2, retakeType).Value!;
var application = retry.RetakeTestApplication!;
Check(application.ApplicationTypeId == 7 && application.PersonId == 42 && application.CreatedByUserId == 2,
    "Retake application records type, applicant, and creator");
Check(application.Status == ApplicationStatusEnum.Completed && application.PaidFees.Amount == 5,
    "Retake service is completed with its configured fee");
Check(retry.PaidFees.Amount + application.PaidFees.Amount == 25,
    "Total charge is the test fee plus the retake fee");
Check(first.Application.Id == 10 && first.Application.Status == ApplicationStatusEnum.New,
    "Original application remains active");
retry.TakeTest(TestResult.Failure, null, 2);
var third = first.ScheduleTest(vision, DateTime.UtcNow.AddDays(3), 2, retakeType).Value!;
Check(!ReferenceEquals(third.RetakeTestApplication, application), "Each retake creates its own application");
third.TakeTest(TestResult.Failure, null, 2);
Check(first.ScheduleTest(vision, DateTime.UtcNow.AddDays(4), 2, retakeType).IsFailure,
    "Existing three-attempt limit is preserved");

var passed = Fixture();
passed.ScheduleTest(vision, DateTime.UtcNow.AddDays(1), 2).Value!.TakeTest(TestResult.Success, null, 2);
Check(passed.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2, retakeType).IsFailure,
    "Passed tests cannot be retaken");

var otherType = TestType.Create("Written", "Written test", Money.Create(30).Value!);
Set(otherType, nameof(Entity.Id), 2);
Check(passed.ScheduleTest(otherType, DateTime.UtcNow.AddDays(2), 2, retakeType).Value!.RetakeTestApplication is null,
    "First attempt of a different test type has no retake fee");

// Check EF graph insertion and the FK without connecting to a database.
using var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=(local);Database=RetakeModelOnly;Integrated Security=True;TrustServerCertificate=True").Options);
var tracked = Fixture();
var oldAppointment = tracked.ScheduleTest(vision, DateTime.UtcNow.AddDays(1), 2).Value!;
Set(oldAppointment, nameof(Entity.Id), 100);
oldAppointment.TakeTest(TestResult.Failure, null, 2);
Set(oldAppointment.Test!, nameof(Entity.Id), 100);
db.Attach(tracked);
db.Attach(retakeType);
var newAppointment = tracked.ScheduleTest(vision, DateTime.UtcNow.AddDays(2), 2, retakeType).Value!;
db.Add(newAppointment);
Check(db.Entry(newAppointment).State == EntityState.Added &&
    db.Entry(newAppointment.RetakeTestApplication!).State == EntityState.Added,
    "Adding the appointment also inserts the retake application in the same SaveChanges");
Check(db.Entry(newAppointment).Property(a => a.RetakeTestApplicationId).CurrentValue ==
    db.Entry(newAppointment.RetakeTestApplication!).Property(a => a.Id).CurrentValue,
    "EF propagates the new application key to the appointment");
var appointmentModel = db.Model.FindEntityType(typeof(TestAppointment))!;
Check(appointmentModel.GetForeignKeys().Any(f => f.Properties.Single().Name == "RetakeTestApplicationId" &&
    f.PrincipalEntityType.ClrType == typeof(Application) && f.DeleteBehavior == DeleteBehavior.NoAction),
    "Retake application FK is mapped without cascading deletes");
Console.WriteLine("All retake regression checks passed.");

LocalDrivingLicenseApplication Fixture()
{
    var original = Application.CreateApplication(42, originalType, 1);
    Set(original, nameof(Entity.Id), 10);
    Set(original, nameof(Application.Status), ApplicationStatusEnum.New);
    var local = (LocalDrivingLicenseApplication)Activator.CreateInstance(typeof(LocalDrivingLicenseApplication), true)!;
    Set(local, nameof(Entity.Id), 10);
    Set(local, nameof(LocalDrivingLicenseApplication.ApplicationId), 10);
    Set(local, nameof(LocalDrivingLicenseApplication.Application), original);
    return local;
}

static void Set(object entity, string name, object value) => entity.GetType().GetProperty(name)!.SetValue(entity, value);
static void Check(bool condition, string description)
{
    if (!condition) throw new InvalidOperationException(description);
    Console.WriteLine($"PASS: {description}");
}
