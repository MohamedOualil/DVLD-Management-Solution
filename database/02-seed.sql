-- Fictional development data. Fees and country IDs are demo choices, not recovered records.
-- Run only after 01-schema.sql in an empty database.
-- Demo admin uses admin1234; employee/inactive use DvldDemo!2026 (enhanced BCrypt work factor 12).
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF EXISTS (SELECT 1 FROM sys.tables t JOIN sys.partitions p ON p.object_id=t.object_id
           WHERE t.is_ms_shipped=0 AND p.index_id IN (0,1) AND p.rows>0)
    THROW 50001, 'Seed refused: the database contains existing data.', 1;
BEGIN TRY
BEGIN TRANSACTION;
DECLARE @now datetime2 = SYSUTCDATETIME();

SET IDENTITY_INSERT Countries ON;
INSERT Countries (Id, CountryName) VALUES
(1,N'Morocco'),(2,N'Algeria'),(3,N'Tunisia'),(4,N'Egypt'),(5,N'Jordan'),
(6,N'Saudi Arabia'),(7,N'France'),(8,N'Spain'),(9,N'United Kingdom'),(10,N'United States');
SET IDENTITY_INSERT Countries OFF;

SET IDENTITY_INSERT ApplicationTypes ON;
INSERT ApplicationTypes (Id,ApplicationTypeTitle,ApplicationFees) VALUES
(1,N'New Local Driving License',15),(2,N'Renew Driving License',7),
(3,N'Replacement for a Lost Driving License',10),(4,N'Replacement for a Damaged Driving License',5),
(5,N'Release Detained Driving License',15),(6,N'New International License',50),(7,N'Retake Test',5);
SET IDENTITY_INSERT ApplicationTypes OFF;

SET IDENTITY_INSERT LicenseClasses ON;
INSERT LicenseClasses (Id,ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees) VALUES
(1,N'Small Motorcycle',N'Small motorcycle demo class',18,5,15),
(2,N'Heavy Motorcycle',N'Heavy motorcycle demo class',21,5,30),
(3,N'Ordinary Driving License',N'Passenger cars',18,10,20),
(4,N'Commercial',N'Commercial vehicles',21,10,200),
(5,N'Agricultural',N'Agricultural vehicles',21,10,50),
(6,N'Small and Medium Bus',N'Small and medium passenger buses',21,10,250),
(7,N'Truck and Heavy Vehicle',N'Trucks and heavy vehicles',21,10,300);
SET IDENTITY_INSERT LicenseClasses OFF;

SET IDENTITY_INSERT TestTypes ON;
INSERT TestTypes (Id,TestTypeTitle,TestTypeDescrption,TestFees) VALUES
(1,N'Vision Test',N'Checks vision before the written test.',10),
(2,N'Written Test',N'Checks road rules after passing vision.',20),
(3,N'Street Test',N'Checks practical driving after passing the written test.',30);
SET IDENTITY_INSERT TestTypes OFF;

SET IDENTITY_INSERT Persons ON;
INSERT Persons (Id,FirstName,SecondName,ThirdName,LastName,NationalNo,DateOfBirth,Gender,
NationalityCountryId,Street,State,City,ZipCode,Phone,Email,ImagePath,CreateAt,UpdateAt)
SELECT v.Id,v.FirstName,NULL,NULL,v.LastName,CONCAT(N'DEMO',RIGHT('0000'+CONVERT(varchar(4),v.Id),4)),
DATEFROMPARTS(1985+v.Id,3,15),v.Gender,1,CONCAT(v.Id,N' Demo Street'),N'Casablanca-Settat',N'Casablanca',N'20000',
CONCAT(N'+212600000',RIGHT('000'+CONVERT(varchar(3),v.Id),3)),
CONCAT(N'demo',v.Id,N'@example.com'),NULL,DATEADD(day,-4000,@now),@now
FROM (VALUES (1,N'Adam',N'Admin',1),(2,N'Sara',N'Employee',2),(3,N'Omar',N'Inactive',1),
(4,N'Youssef',N'Amrani',1),(5,N'Leila',N'Bennani',2),(6,N'Karim',N'Idrissi',1),
(7,N'Salma',N'Mansouri',2),(8,N'Hamza',N'Fassi',1),(9,N'Nadia',N'Alaoui',2),
(10,N'Rachid',N'Tazi',1),(11,N'Imane',N'Saidi',2),(12,N'Mehdi',N'Zaki',1),
(13,N'Hana',N'Rami',2),(14,N'Anas',N'Nouri',1)) v(Id,FirstName,LastName,Gender);
SET IDENTITY_INSERT Persons OFF;

SET IDENTITY_INSERT Users ON;
INSERT Users (Id,PersonId,UserName,PasswordHash,Role,IsActive,CreateAt,UpdateAt) VALUES
(1,1,N'admin',N'$2a$12$j3/fiYGfaWW3GnKGAmNx0eVnfEK3Q30rDMmzq2rgrny3FfzFACpIy',1,1,DATEADD(day,-4000,@now),@now),
(2,2,N'employee',N'$2a$12$UQ0pg0Idp.w2YQW763P2O.g6OY5HJ0lISZ53.H11eCmxxkm3i5Jxq',2,1,DATEADD(day,-4000,@now),@now),
(3,3,N'inactive',N'$2a$12$UQ0pg0Idp.w2YQW763P2O.g6OY5HJ0lISZ53.H11eCmxxkm3i5Jxq',2,0,DATEADD(day,-4000,@now),@now);
SET IDENTITY_INSERT Users OFF;

SET IDENTITY_INSERT Applications ON;
INSERT Applications (Id,PersonId,ApplicationDate,ApplicationTypeId,Status,LastStatusDate,PaidFees,CreatedByUserId,LastUpdatedByUserId)
SELECT v.Id,v.PersonId,DATEADD(day,v.StartDay,@now),v.TypeId,v.Status,
DATEADD(day,v.EndDay,@now),t.ApplicationFees,2,CASE WHEN v.Status=1 THEN NULL ELSE 2 END
FROM (VALUES
(1,4,1,1,-10,-10),(2,5,1,1,-10,-10),(3,6,1,1,-30,-30),(4,7,1,1,-20,-20),
(5,8,1,1,-40,-40),(6,9,1,3,-400,-365),(7,10,1,3,-4000,-3900),
(8,11,1,3,-220,-180),(9,12,1,1,-30,-30),(10,13,1,2,-20,-15),
(11,9,6,3,-90,-90),(12,9,5,3,-100,-100)) v(Id,PersonId,TypeId,Status,StartDay,EndDay)
JOIN ApplicationTypes t ON t.Id=v.TypeId;
SET IDENTITY_INSERT Applications OFF;

SET IDENTITY_INSERT LocalDrivingLicenseApplications ON;
INSERT LocalDrivingLicenseApplications (Id,ApplicationId,LicenseClassId)
SELECT Id,Id,3 FROM Applications WHERE Id<=10;
SET IDENTITY_INSERT LocalDrivingLicenseApplications OFF;

-- A NULL result is a future, unlocked appointment; 0/1 are completed attempts.
DECLARE @appointments TABLE (Id int,LocalId int,TypeId int,DayOffset int,Result tinyint NULL);
INSERT @appointments VALUES
(1,2,1,3,NULL),(2,3,1,-20,1),(3,3,2,4,NULL),(4,4,1,-10,0),(5,4,1,5,NULL),
(6,5,1,-25,1),(7,5,2,-20,1),(8,5,3,6,NULL),
(9,6,1,-395,1),(10,6,2,-390,1),(11,6,3,-380,1),
(12,7,1,-3990,1),(13,7,2,-3980,1),(14,7,3,-3970,1),
(15,8,1,-210,1),(16,8,2,-200,1),(17,8,3,-190,1),
(18,9,1,-20,1),(19,9,2,-10,1),(20,9,3,-5,1);
SET IDENTITY_INSERT TestAppointments ON;
INSERT TestAppointments (Id,TestTypeId,LocalDrivingLicenseApplicationId,AppointmentDate,PaidFees,CreatedByUserId,IsLocked,CreateAt)
SELECT a.Id,a.TypeId,a.LocalId,DATEADD(day,a.DayOffset,@now),t.TestFees,2,
CASE WHEN a.Result IS NULL THEN 0 ELSE 1 END,
CASE WHEN a.DayOffset>0 THEN @now ELSE DATEADD(day,a.DayOffset-1,@now) END
FROM @appointments a JOIN TestTypes t ON t.Id=a.TypeId;
SET IDENTITY_INSERT TestAppointments OFF;
SET IDENTITY_INSERT Tests ON;
INSERT Tests (Id,TestAppointmentId,TestResult,Notes,CreatedByUserId)
SELECT Id,Id,Result,CASE WHEN Result=1 THEN N'Demo: passed' ELSE N'Demo: failed; retake booked' END,2
FROM @appointments WHERE Result IS NOT NULL;
SET IDENTITY_INSERT Tests OFF;

SET IDENTITY_INSERT Drivers ON;
INSERT Drivers (Id,PersonId,CreatedByUserId,CreateAt) VALUES
(1,9,2,DATEADD(day,-365,@now)),(2,10,2,DATEADD(day,-3900,@now)),(3,11,2,DATEADD(day,-180,@now));
SET IDENTITY_INSERT Drivers OFF;
SET IDENTITY_INSERT DrivingLicenses ON;
INSERT DrivingLicenses (Id,ApplicationId,DriverId,LicenseClassId,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IsDetained,IssueReason,CreatedByUserId) VALUES
(1,6,1,3,DATEADD(day,-365,@now),DATEADD(year,10,DATEADD(day,-365,@now)),N'Demo: valid ordinary license',20,1,0,1,2),
(2,7,2,3,DATEADD(day,-3900,@now),DATEADD(year,10,DATEADD(day,-3900,@now)),N'Demo: expired license for renewal workflow',20,1,0,1,2),
(3,8,3,3,DATEADD(day,-180,@now),DATEADD(year,10,DATEADD(day,-180,@now)),N'Demo: currently detained license',20,1,1,1,2);
SET IDENTITY_INSERT DrivingLicenses OFF;
SET IDENTITY_INSERT InternationalLicenses ON;
INSERT InternationalLicenses (Id,ApplicationId,DriverId,IssuedUsingLocalLicenseId,IssueDate,ExpirationDate,IsActive,IsDetained,IssueReason,CreatedByUserId) VALUES
(1,11,1,1,DATEADD(day,-90,@now),DATEADD(day,275,@now),1,0,1,2);
SET IDENTITY_INSERT InternationalLicenses OFF;
SET IDENTITY_INSERT DetainedLicenses ON;
INSERT DetainedLicenses (Id,LicenseId,DetainDate,PaidFees,CreatedByUserId,IsReleased,ReleaseDate,ReleasedByUserId,ReleaseApplicationId) VALUES
(1,3,DATEADD(day,-7,@now),100,2,0,NULL,NULL,NULL),
(2,1,DATEADD(day,-110,@now),50,2,1,DATEADD(day,-100,@now),2,12);
SET IDENTITY_INSERT DetainedLicenses OFF;

-- AuditLogs and UserSessions start empty; runtime actions create those records.
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
