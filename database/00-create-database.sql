-- SQL Server / SSMS: execute this first, then select DVLD_DB for the other scripts.
USE master;
GO
IF DB_ID(N'DVLD_DB') IS NULL
    EXEC(N'CREATE DATABASE [DVLD_DB]');
GO
USE DVLD_DB;
GO
IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
    THROW 50000, 'Database already contains tables. Existing data will not be overwritten.', 1;
