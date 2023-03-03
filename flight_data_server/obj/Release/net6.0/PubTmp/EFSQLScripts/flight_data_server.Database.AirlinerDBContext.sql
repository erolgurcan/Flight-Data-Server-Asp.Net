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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230205185905_initial')
BEGIN
    CREATE TABLE [Airliner] (
        [Id] int NOT NULL IDENTITY,
        [AirlinerName] nvarchar(max) NOT NULL,
        [AirlinerCallSign] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Airliner] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230205185905_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AirlinerCallSign', N'AirlinerName') AND [object_id] = OBJECT_ID(N'[Airliner]'))
        SET IDENTITY_INSERT [Airliner] ON;
    EXEC(N'INSERT INTO [Airliner] ([Id], [AirlinerCallSign], [AirlinerName])
    VALUES (1, N''THY'', N''Turkish Airliner'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AirlinerCallSign', N'AirlinerName') AND [object_id] = OBJECT_ID(N'[Airliner]'))
        SET IDENTITY_INSERT [Airliner] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230205185905_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230205185905_initial', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230205191755_fix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230205191755_fix', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206014650_userTable')
BEGIN
    CREATE TABLE [User] (
        [UserId] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206014650_userTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230206014650_userTable', N'6.0.13');
END;
GO

COMMIT;
GO

