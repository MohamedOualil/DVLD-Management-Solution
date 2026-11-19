-- Drops shadow column DriverId1 on DrivingLicenses and aligns CHECK/unique constraints with EF Core configuration.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

-- 1. Remove phantom EF Core shadow column DriverId1
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DrivingLicenses_DriverId1' AND object_id = OBJECT_ID('dbo.DrivingLicenses'))
    DROP INDEX [IX_DrivingLicenses_DriverId1] ON [dbo].[DrivingLicenses];

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_DrivingLicenses_Drivers_DriverId1' AND parent_object_id = OBJECT_ID('dbo.DrivingLicenses'))
    ALTER TABLE [dbo].[DrivingLicenses] DROP CONSTRAINT [FK_DrivingLicenses_Drivers_DriverId1];

IF COL_LENGTH('dbo.DrivingLicenses', 'DriverId1') IS NOT NULL
    ALTER TABLE [dbo].[DrivingLicenses] DROP COLUMN [DriverId1];

-- 2. Tighten Persons.Gender check constraint
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Persons_Gender' AND parent_object_id = OBJECT_ID('dbo.Persons'))
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [CHK_Persons_Gender];

ALTER TABLE [dbo].[Persons] WITH CHECK
    ADD CONSTRAINT [CHK_Persons_Gender] CHECK ([Gender] IN (1, 2));

-- 3. Add Users.Role check constraint
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Users_Role' AND parent_object_id = OBJECT_ID('dbo.Users'))
    ALTER TABLE [dbo].[Users] WITH CHECK
        ADD CONSTRAINT [CHK_Users_Role] CHECK ([Role] IN (1, 2));

-- 4. Allow same-tick UTC release date on DetainedLicenses
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_DetainedLicenses_ReleaseDate' AND parent_object_id = OBJECT_ID('dbo.DetainedLicenses'))
    ALTER TABLE [dbo].[DetainedLicenses] DROP CONSTRAINT [CK_DetainedLicenses_ReleaseDate];

ALTER TABLE [dbo].[DetainedLicenses] WITH CHECK
    ADD CONSTRAINT [CK_DetainedLicenses_ReleaseDate] CHECK ([ReleaseDate] >= [DetainDate]);

-- 5. Enforce one active detention per license and one unlocked appointment per (local application, test type)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UQ_DetainedLicenses_ActiveLicenseId' AND object_id = OBJECT_ID('dbo.DetainedLicenses'))
    CREATE UNIQUE INDEX [UQ_DetainedLicenses_ActiveLicenseId]
        ON [dbo].[DetainedLicenses] ([LicenseId]) WHERE [IsReleased] = 0;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UQ_TestAppointments_ActiveUnlocked' AND object_id = OBJECT_ID('dbo.TestAppointments'))
    CREATE UNIQUE INDEX [UQ_TestAppointments_ActiveUnlocked]
        ON [dbo].[TestAppointments] ([LocalDrivingLicenseApplicationId], [TestTypeId]) WHERE [IsLocked] = 0;

COMMIT TRANSACTION;
