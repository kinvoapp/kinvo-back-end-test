IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [application] (
    [id] uniqueidentifier NOT NULL,
    [name] varchar(100) NOT NULL,
    [value] decimal(10,2) NOT NULL,
    [created_at] datetime2 NOT NULL,
    [withdrawn_at] datetime2 NULL,
    CONSTRAINT [PK_application] PRIMARY KEY ([id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210123232020_Initial', N'3.1.11');

GO

EXEC sp_rename N'[application].[value]', N'initial_value', N'COLUMN';

GO

ALTER TABLE [application] ADD [active] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [application] ADD [current_value] decimal(10,2) NOT NULL DEFAULT 0.0;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] ON;
INSERT INTO [application] ([id], [active], [created_at], [current_value], [initial_value], [name], [withdrawn_at])
VALUES ('f498ec2d-a9f1-47a9-b479-6cf1430f6e0a', CAST(1 AS bit), '2017-01-01T00:00:00.0000000Z', 300.0, 100.0, 'Sample application', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] ON;
INSERT INTO [application] ([id], [active], [created_at], [current_value], [initial_value], [name], [withdrawn_at])
VALUES ('85d83f27-9945-42b3-9021-0e316c8a8b3a', CAST(1 AS bit), '2019-01-01T00:00:00.0000000Z', 300.0, 100.0, 'Second application', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] ON;
INSERT INTO [application] ([id], [active], [created_at], [current_value], [initial_value], [name], [withdrawn_at])
VALUES ('d19039ef-cfc0-4413-911a-4bd69fb96f0c', CAST(1 AS bit), '2021-01-01T00:00:00.0000000Z', 300.0, 100.0, 'Third application', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'active', N'created_at', N'current_value', N'initial_value', N'name', N'withdrawn_at') AND [object_id] = OBJECT_ID(N'[application]'))
    SET IDENTITY_INSERT [application] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210125202915_AddProperties', N'3.1.11');

GO

