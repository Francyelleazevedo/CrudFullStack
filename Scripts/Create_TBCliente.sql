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

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Telefone] varchar(11) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230504195208_ClienteMigration', N'7.0.5');
GO

COMMIT;
GO

