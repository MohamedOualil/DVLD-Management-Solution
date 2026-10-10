-- Generated from AppDbContext. Run against a new, empty database.
IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
    THROW 50000, 'Schema creation refused: database already contains tables.', 1;
CREATE TABLE [ApplicationTypes] (
    [Id] int NOT NULL IDENTITY,
    [ApplicationTypeTitle] nvarchar(100) NOT NULL,
    [ApplicationFees] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ApplicationTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [CHK_ApplicationType_Fees] CHECK (ApplicationFees >= 0)
);
GO


CREATE TABLE [AuditLogs] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NULL,
    [UserName] nvarchar(256) NOT NULL,
    [Action] nvarchar(50) NOT NULL,
    [EntityName] nvarchar(255) NOT NULL,
    [EntityId] nvarchar(255) NOT NULL,
    [OldValues] nvarchar(max) NULL,
    [NewValues] nvarchar(max) NULL,
    [IsSuccess] bit NOT NULL,
    [FailureReason] nvarchar(max) NOT NULL,
    [IpAddress] nvarchar(45) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_AuditLogs] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [CountryName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [LicenseClasses] (
    [Id] int NOT NULL IDENTITY,
    [ClassName] nvarchar(100) NOT NULL,
    [ClassDescription] nvarchar(500) NOT NULL,
    [MinimumAllowedAge] tinyint NOT NULL,
    [DefaultValidityLength] tinyint NOT NULL,
    [ClassFees] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_LicenseClasses] PRIMARY KEY ([Id]),
    CONSTRAINT [CHK_LicenseClasses_Age] CHECK (MinimumAllowedAge > 0),
    CONSTRAINT [CHK_LicenseClasses_ClassFees] CHECK (ClassFees >= 0),
    CONSTRAINT [CHK_LicenseClasses_Validity] CHECK (DefaultValidityLength > 0)
);
GO


CREATE TABLE [TestTypes] (
    [Id] int NOT NULL IDENTITY,
    [TestTypeTitle] nvarchar(100) NOT NULL,
    [TestTypeDescrption] nvarchar(500) NOT NULL,
    [TestFees] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_TestTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [CHK_TestTypes_TestFees] CHECK (TestFees >= 0)
);
GO


CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(20) NOT NULL,
    [SecondName] nvarchar(20) NULL,
    [ThirdName] nvarchar(20) NULL,
    [LastName] nvarchar(20) NOT NULL,
    [NationalNo] nvarchar(20) NOT NULL,
    [DateOfBirth] date NOT NULL,
    [Gender] tinyint NOT NULL,
    [NationalityCountryId] int NOT NULL,
    [Street] nvarchar(100) NOT NULL,
    [City] nvarchar(100) NOT NULL,
    [State] nvarchar(100) NOT NULL,
    [ZipCode] nvarchar(10) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Email] nvarchar(150) NULL,
    [ImagePath] nvarchar(500) NULL,
    [CreateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [UpdateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id]),
    CONSTRAINT [CHK_Persons_Gender] CHECK (Gender > 0),
    CONSTRAINT [FK_Persons_Countries_NationalityCountryId] FOREIGN KEY ([NationalityCountryId]) REFERENCES [Countries] ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] int NOT NULL,
    [UserName] nvarchar(20) NOT NULL,
    [PasswordHash] nvarchar(255) NOT NULL,
    [Role] tinyint NOT NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CreateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [UpdateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Persons] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id])
);
GO


CREATE TABLE [Applications] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] int NOT NULL,
    [ApplicationDate] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [ApplicationTypeId] int NOT NULL,
    [Status] TINYINT NOT NULL,
    [LastStatusDate] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [PaidFees] decimal(18,2) NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [LastUpdatedByUserId] int NULL,
    CONSTRAINT [PK_Applications] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Applications_PaidFees] CHECK (PaidFees >= 0),
    CONSTRAINT [CK_Applications_Status] CHECK (Status IN (1, 2, 3)),
    CONSTRAINT [FK_Applications_ApplicationTypes_ApplicationTypeId] FOREIGN KEY ([ApplicationTypeId]) REFERENCES [ApplicationTypes] ([Id]),
    CONSTRAINT [FK_Applications_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]),
    CONSTRAINT [FK_Applications_Users_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [FK_Applications_Users_LastUpdatedByUserId] FOREIGN KEY ([LastUpdatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [Drivers] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] int NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [CreateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Drivers_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]),
    CONSTRAINT [FK_Drivers_Users_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [UserSessions] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [RefreshTokenHash] nvarchar(500) NOT NULL,
    [ExpiresAt] DATETIME2 NOT NULL,
    [RevokedAt] DATETIME2 NULL,
    [CreatedIp] nvarchar(50) NULL,
    [DeviceId] nvarchar(255) NOT NULL,
    [DeviceInfo] nvarchar(255) NULL,
    [CreateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_UserSessions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSessions_Users] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [LocalDrivingLicenseApplications] (
    [Id] int NOT NULL IDENTITY,
    [ApplicationId] int NOT NULL,
    [LicenseClassId] int NOT NULL,
    CONSTRAINT [PK_LocalDrivingLicenseApplications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LocalDrivingLicenseApplications_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LocalDrivingLicenseApplications_LicenseClasses] FOREIGN KEY ([LicenseClassId]) REFERENCES [LicenseClasses] ([Id])
);
GO


CREATE TABLE [DrivingLicenses] (
    [Id] int NOT NULL IDENTITY,
    [ApplicationId] int NOT NULL,
    [DriverId] int NOT NULL,
    [LicenseClassId] int NOT NULL,
    [IssueDate] DATETIME2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [ExpirationDate] DATETIME2 NOT NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [PaidFees] decimal(18,2) NOT NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [IsDetained] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IssueReason] TINYINT NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [DriverId1] int NULL,
    CONSTRAINT [PK_DrivingLicenses] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_DrivingLicenses_Dates] CHECK (ExpirationDate > IssueDate),
    CONSTRAINT [CK_DrivingLicenses_IssueReason] CHECK (IssueReason IN (1, 2, 3, 4)),
    CONSTRAINT [CK_DrivingLicenses_PaidFees] CHECK (PaidFees >= 0),
    CONSTRAINT [FK_DrivingLicenses_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]),
    CONSTRAINT [FK_DrivingLicenses_Drivers] FOREIGN KEY ([DriverId]) REFERENCES [Drivers] ([Id]),
    CONSTRAINT [FK_DrivingLicenses_Drivers_DriverId1] FOREIGN KEY ([DriverId1]) REFERENCES [Drivers] ([Id]),
    CONSTRAINT [FK_DrivingLicenses_LicenseClasses] FOREIGN KEY ([LicenseClassId]) REFERENCES [LicenseClasses] ([Id]),
    CONSTRAINT [FK_DrivingLicenses_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [TestAppointments] (
    [Id] int NOT NULL IDENTITY,
    [TestTypeId] int NOT NULL,
    [LocalDrivingLicenseApplicationId] int NOT NULL,
    [AppointmentDate] DATETIME2 NOT NULL,
    [PaidFees] decimal(18,2) NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [IsLocked] bit NOT NULL DEFAULT CAST(0 AS bit),
    [CreateAt] datetime2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_TestAppointments] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_TestAppointments_AppointmentDate] CHECK (AppointmentDate > CreateAt),
    CONSTRAINT [CK_TestAppointments_PaidFees] CHECK (PaidFees >= 0),
    CONSTRAINT [FK_TestAppointments_LDLA] FOREIGN KEY ([LocalDrivingLicenseApplicationId]) REFERENCES [LocalDrivingLicenseApplications] ([Id]),
    CONSTRAINT [FK_TestAppointments_TestTypes] FOREIGN KEY ([TestTypeId]) REFERENCES [TestTypes] ([Id]),
    CONSTRAINT [FK_TestAppointments_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [DetainedLicenses] (
    [Id] int NOT NULL IDENTITY,
    [LicenseId] int NOT NULL,
    [DetainDate] DATETIME2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [PaidFees] decimal(18,2) NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [IsReleased] bit NOT NULL DEFAULT CAST(0 AS bit),
    [ReleaseDate] DATETIME2 NULL,
    [ReleasedByUserId] int NULL,
    [ReleaseApplicationId] int NULL,
    CONSTRAINT [PK_DetainedLicenses] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_DetainedLicenses_PaidFees] CHECK (PaidFees >= 0),
    CONSTRAINT [CK_DetainedLicenses_ReleaseDate] CHECK (ReleaseDate > DetainDate),
    CONSTRAINT [FK_DetainedLicenses_Applications] FOREIGN KEY ([ReleaseApplicationId]) REFERENCES [Applications] ([Id]),
    CONSTRAINT [FK_DetainedLicenses_CreatedBy_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [FK_DetainedLicenses_DrivingLicenses] FOREIGN KEY ([LicenseId]) REFERENCES [DrivingLicenses] ([Id]),
    CONSTRAINT [FK_DetainedLicenses_ReleasedBy_Users] FOREIGN KEY ([ReleasedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [InternationalLicenses] (
    [Id] int NOT NULL IDENTITY,
    [ApplicationId] int NOT NULL,
    [DriverId] int NOT NULL,
    [IssuedUsingLocalLicenseId] int NOT NULL,
    [IssueDate] DATETIME2 NOT NULL DEFAULT (SYSUTCDATETIME()),
    [ExpirationDate] DATETIME2 NOT NULL,
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [IsDetained] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IssueReason] TINYINT NOT NULL,
    [CreatedByUserId] int NOT NULL,
    CONSTRAINT [PK_InternationalLicenses] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_InternationalLicenses_ExpirationDate] CHECK (ExpirationDate > IssueDate),
    CONSTRAINT [CK_InternationalLicenses_IssueReason] CHECK (IssueReason IN (1, 2, 3, 4)),
    CONSTRAINT [FK_InternationalLicenses_Applications] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]),
    CONSTRAINT [FK_InternationalLicenses_Drivers] FOREIGN KEY ([DriverId]) REFERENCES [Drivers] ([Id]),
    CONSTRAINT [FK_InternationalLicenses_DrivingLicenses] FOREIGN KEY ([IssuedUsingLocalLicenseId]) REFERENCES [DrivingLicenses] ([Id]),
    CONSTRAINT [FK_InternationalLicenses_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE TABLE [Tests] (
    [Id] int NOT NULL IDENTITY,
    [TestAppointmentId] int NOT NULL,
    [TestResult] TINYINT NOT NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [CreatedByUserId] int NOT NULL,
    CONSTRAINT [PK_Tests] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Tests_TestResult] CHECK (TestResult IN (0,1)),
    CONSTRAINT [FK_Tests_TestAppointments] FOREIGN KEY ([TestAppointmentId]) REFERENCES [TestAppointments] ([Id]),
    CONSTRAINT [FK_Tests_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id])
);
GO


CREATE INDEX [IX_Applications_ApplicationTypeId] ON [Applications] ([ApplicationTypeId]);
GO


CREATE INDEX [IX_Applications_CreatedByUserId] ON [Applications] ([CreatedByUserId]);
GO


CREATE INDEX [IX_Applications_LastUpdatedByUserId] ON [Applications] ([LastUpdatedByUserId]);
GO


CREATE INDEX [IX_Applications_PersonId] ON [Applications] ([PersonId]);
GO


CREATE INDEX [IX_AuditLogs_CreatedAt] ON [AuditLogs] ([CreatedAt]);
GO


CREATE INDEX [IX_AuditLogs_EntityName_EntityId] ON [AuditLogs] ([EntityName], [EntityId]);
GO


CREATE INDEX [IX_AuditLogs_UserId] ON [AuditLogs] ([UserId]);
GO


CREATE INDEX [IX_DetainedLicenses_CreatedByUserId] ON [DetainedLicenses] ([CreatedByUserId]);
GO


CREATE INDEX [IX_DetainedLicenses_LicenseId] ON [DetainedLicenses] ([LicenseId]);
GO


CREATE INDEX [IX_DetainedLicenses_ReleasedByUserId] ON [DetainedLicenses] ([ReleasedByUserId]);
GO


CREATE UNIQUE INDEX [UQ_DetainedLicenses_ReleaseApplicationId] ON [DetainedLicenses] ([ReleaseApplicationId]) WHERE [ReleaseApplicationId] IS NOT NULL;
GO


CREATE INDEX [IX_Drivers_CreatedByUserId] ON [Drivers] ([CreatedByUserId]);
GO


CREATE UNIQUE INDEX [UQ_Drivers_PersonId] ON [Drivers] ([PersonId]);
GO


CREATE INDEX [IX_DrivingLicenses_CreatedByUserId] ON [DrivingLicenses] ([CreatedByUserId]);
GO


CREATE INDEX [IX_DrivingLicenses_DriverId] ON [DrivingLicenses] ([DriverId]);
GO


CREATE INDEX [IX_DrivingLicenses_DriverId1] ON [DrivingLicenses] ([DriverId1]);
GO


CREATE INDEX [IX_DrivingLicenses_LicenseClassId] ON [DrivingLicenses] ([LicenseClassId]);
GO


CREATE UNIQUE INDEX [UQ_DrivingLicenses_ApplicationId] ON [DrivingLicenses] ([ApplicationId]);
GO


CREATE INDEX [IX_InternationalLicenses_CreatedByUserId] ON [InternationalLicenses] ([CreatedByUserId]);
GO


CREATE INDEX [IX_InternationalLicenses_DriverId] ON [InternationalLicenses] ([DriverId]);
GO


CREATE INDEX [IX_InternationalLicenses_IssuedUsingLocalLicenseId] ON [InternationalLicenses] ([IssuedUsingLocalLicenseId]);
GO


CREATE UNIQUE INDEX [UQ_InternationalLicenses_ApplicationId] ON [InternationalLicenses] ([ApplicationId]);
GO


CREATE INDEX [IX_LocalDrivingLicenseApplications_LicenseClassId] ON [LocalDrivingLicenseApplications] ([LicenseClassId]);
GO


CREATE UNIQUE INDEX [UQ_LocalDrivingLicenseApplications_ApplicationId] ON [LocalDrivingLicenseApplications] ([ApplicationId]);
GO


CREATE INDEX [IX_Persons_NationalityCountryId] ON [Persons] ([NationalityCountryId]);
GO


CREATE UNIQUE INDEX [UQ_Persons_Email] ON [Persons] ([Email]) WHERE [Email] IS NOT NULL;
GO


CREATE UNIQUE INDEX [UQ_Persons_NationalNo] ON [Persons] ([NationalNo]);
GO


CREATE INDEX [IX_TestAppointments_CreatedByUserId] ON [TestAppointments] ([CreatedByUserId]);
GO


CREATE INDEX [IX_TestAppointments_LocalDrivingLicenseApplicationId] ON [TestAppointments] ([LocalDrivingLicenseApplicationId]);
GO


CREATE INDEX [IX_TestAppointments_TestTypeId] ON [TestAppointments] ([TestTypeId]);
GO


CREATE INDEX [IX_Tests_CreatedByUserId] ON [Tests] ([CreatedByUserId]);
GO


CREATE UNIQUE INDEX [UQ_Tests_TestAppointmentId] ON [Tests] ([TestAppointmentId]);
GO


CREATE UNIQUE INDEX [UQ_Users_PersonId] ON [Users] ([PersonId]);
GO


CREATE UNIQUE INDEX [UQ_Users_UserName] ON [Users] ([UserName]);
GO


CREATE INDEX [IX_UserSessions_UserId] ON [UserSessions] ([UserId]);
GO


