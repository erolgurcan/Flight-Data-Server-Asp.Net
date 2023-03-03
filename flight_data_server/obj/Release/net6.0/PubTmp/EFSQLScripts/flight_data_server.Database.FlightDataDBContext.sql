IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208014647_FlightData')
BEGIN
    CREATE TABLE [FlightData] (
        [Id] int NOT NULL IDENTITY,
        [LoggingTime] datetime2 NOT NULL,
        [TrueAirSpeed] float NOT NULL,
        [GroundSpeed] float NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        [Altitude] float NOT NULL,
        [Throttle] float NOT NULL,
        CONSTRAINT [PK_FlightData] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208014647_FlightData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230208014647_FlightData', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208020846_FlightDataFK')
BEGIN
    ALTER TABLE [FlightData] ADD [AirlinerID] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208020846_FlightDataFK')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230208020846_FlightDataFK', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208021229_FlightDataFK2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230208021229_FlightDataFK2', N'6.0.13');
END;
GO

COMMIT;
GO

