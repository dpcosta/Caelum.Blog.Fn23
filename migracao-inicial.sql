IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Posts] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NULL,
    [Resumo] nvarchar(max) NULL,
    [Categoria] nvarchar(max) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] ON;
INSERT INTO [Posts] ([Titulo], [Resumo], [Categoria])
VALUES (N'Harry Potter III', N'Prisioneiro de Askaban', N'Filmes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] ON;
INSERT INTO [Posts] ([Titulo], [Resumo], [Categoria])
VALUES (N'Harry Potter II', N'Câmara Secreta', N'Filmes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] ON;
INSERT INTO [Posts] ([Titulo], [Resumo], [Categoria])
VALUES (N'Harry Potter I', N'Pedra Filosofal', N'Filmes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] ON;
INSERT INTO [Posts] ([Titulo], [Resumo], [Categoria])
VALUES (N'Lata d''água na cabeça', N'Samba famoso de época', N'Músicas');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] ON;
INSERT INTO [Posts] ([Titulo], [Resumo], [Categoria])
VALUES (N'Game of Thrones', N'Winter is Coming', N'Séries');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Titulo', N'Resumo', N'Categoria') AND [object_id] = OBJECT_ID(N'[Posts]'))
    SET IDENTITY_INSERT [Posts] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181203131846_Inicial', N'2.1.1-rtm-30846');

GO

