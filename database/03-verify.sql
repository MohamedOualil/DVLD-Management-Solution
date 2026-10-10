-- Read-only checks for the reconstructed database. Select DVLD_DB first.
SET NOCOUNT ON;
SELECT t.name AS TableName, SUM(p.rows) AS [RowCount]
FROM sys.tables t JOIN sys.partitions p ON p.object_id=t.object_id
WHERE t.is_ms_shipped=0 AND p.index_id IN (0,1)
GROUP BY t.name ORDER BY t.name;

DBCC CHECKCONSTRAINTS WITH ALL_CONSTRAINTS;

-- These queries should return no rows for the initial demo data.
SELECT l.Id AS LicenseWithIncompleteTests
FROM DrivingLicenses l
JOIN LocalDrivingLicenseApplications a ON a.ApplicationId=l.ApplicationId
WHERE l.IssueReason=1 AND
    (SELECT COUNT(DISTINCT ta.TestTypeId) FROM TestAppointments ta
     JOIN Tests t ON t.TestAppointmentId=ta.Id
     WHERE ta.LocalDrivingLicenseApplicationId=a.Id AND t.TestResult=1)<>3;

SELECT l.Id AS InconsistentDetention
FROM DrivingLicenses l
WHERE l.IsDetained<>CASE WHEN EXISTS
    (SELECT 1 FROM DetainedLicenses d WHERE d.LicenseId=l.Id AND d.IsReleased=0)
    THEN 1 ELSE 0 END;

SELECT ta.Id AS InconsistentTestLock
FROM TestAppointments ta
WHERE ta.IsLocked<>CASE WHEN EXISTS
    (SELECT 1 FROM Tests t WHERE t.TestAppointmentId=ta.Id) THEN 1 ELSE 0 END;

SELECT a.Id AS ApplicationForUnderagePerson
FROM LocalDrivingLicenseApplications a
JOIN Applications app ON app.Id=a.ApplicationId
JOIN Persons p ON p.Id=app.PersonId
JOIN LicenseClasses c ON c.Id=a.LicenseClassId
WHERE DATEADD(year,c.MinimumAllowedAge,p.DateOfBirth)>app.ApplicationDate;
