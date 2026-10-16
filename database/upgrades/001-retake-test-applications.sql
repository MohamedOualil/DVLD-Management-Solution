-- Run against the existing DVLD database before deploying retake appointment support.
-- Existing appointments are preserved; historical fees are not inferred or backfilled.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.TestAppointments', 'RetakeTestApplicationId') IS NULL
BEGIN
    ALTER TABLE dbo.TestAppointments ADD RetakeTestApplicationId int NULL;
END;

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys
               WHERE name = 'FK_TestAppointments_RetakeApplications'
                 AND parent_object_id = OBJECT_ID('dbo.TestAppointments'))
BEGIN
    EXEC(N'ALTER TABLE dbo.TestAppointments WITH CHECK
        ADD CONSTRAINT FK_TestAppointments_RetakeApplications
        FOREIGN KEY (RetakeTestApplicationId) REFERENCES dbo.Applications (Id);');
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'IX_TestAppointments_RetakeTestApplicationId'
                 AND object_id = OBJECT_ID('dbo.TestAppointments'))
BEGIN
    EXEC(N'CREATE INDEX IX_TestAppointments_RetakeTestApplicationId
        ON dbo.TestAppointments (RetakeTestApplicationId);');
END;

COMMIT TRANSACTION;
