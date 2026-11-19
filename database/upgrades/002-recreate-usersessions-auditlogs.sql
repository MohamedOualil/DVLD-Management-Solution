-- Upgrades UserSessions and non-destructively aligns AuditLogs with the EF Core domain model.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

-- 1. Recreate UserSessions (ephemeral refresh tokens)
IF OBJECT_ID(N'dbo.UserSessions', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.UserSessions;
END;

CREATE TABLE dbo.UserSessions (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    [RefreshTokenHash] NVARCHAR(128) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [ExpiresAt] DATETIME2 NOT NULL,
    [RevokedAt] DATETIME2 NULL,
    CONSTRAINT [PK_UserSessions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserSessions_Users] FOREIGN KEY ([UserId]) REFERENCES dbo.Users ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE NONCLUSTERED INDEX [IX_UserSessions_UserId] ON dbo.UserSessions ([UserId] ASC);
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserSessions_RefreshTokenHash] ON dbo.UserSessions ([RefreshTokenHash] ASC);

-- 2. Non-destructively upgrade AuditLogs to preserve historical audit trails
IF OBJECT_ID(N'dbo.AuditLogs', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AuditLogs (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [UserId] INT NULL,
        [UserName] NVARCHAR(256) NOT NULL,
        [Action] NVARCHAR(50) NOT NULL,
        [EntityName] NVARCHAR(255) NOT NULL,
        [EntityId] NVARCHAR(255) NOT NULL,
        [OldValues] NVARCHAR(MAX) NULL,
        [NewValues] NVARCHAR(MAX) NULL,
        [IsSuccess] BIT NOT NULL,
        [FailureReason] NVARCHAR(MAX) NOT NULL,
        [CreatedAt] DATETIME2 NOT NULL,
        CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
ELSE
BEGIN
    IF COL_LENGTH('dbo.AuditLogs', 'IpAddress') IS NOT NULL
    BEGIN
        ALTER TABLE dbo.AuditLogs DROP COLUMN [IpAddress];
    END;
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AuditLogs_EntityName_EntityId' AND object_id = OBJECT_ID('dbo.AuditLogs'))
    CREATE NONCLUSTERED INDEX [IX_AuditLogs_EntityName_EntityId] ON dbo.AuditLogs ([EntityName] ASC, [EntityId] ASC);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AuditLogs_UserId' AND object_id = OBJECT_ID('dbo.AuditLogs'))
    CREATE NONCLUSTERED INDEX [IX_AuditLogs_UserId] ON dbo.AuditLogs ([UserId] ASC);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AuditLogs_CreatedAt' AND object_id = OBJECT_ID('dbo.AuditLogs'))
    CREATE NONCLUSTERED INDEX [IX_AuditLogs_CreatedAt] ON dbo.AuditLogs ([CreatedAt] ASC);

COMMIT TRANSACTION;
