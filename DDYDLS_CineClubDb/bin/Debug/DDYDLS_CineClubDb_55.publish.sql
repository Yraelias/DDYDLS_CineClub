/*
Script de déploiement pour DDYDLS_CineClubDb

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DDYDLS_CineClubDb"
:setvar DefaultFilePrefix "DDYDLS_CineClubDb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[T_Cineclub]...';


GO
CREATE TABLE [dbo].[T_Cineclub] (
    [Id_Cineclub]      INT           IDENTITY (1, 1) NOT NULL,
    [Id_Movie_1]       INT           NOT NULL,
    [Id_Movie_2]       INT           NOT NULL,
    [Id_Movie_3]       INT           NOT NULL,
    [Id_Movie_4]       INT           NOT NULL,
    [Id_Movie_5]       INT           NULL,
    [NumberOfCineclub] INT           NOT NULL,
    [Begin]            DATE          NOT NULL,
    [End]              DATE          NULL,
    [Title]            NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Cineclub] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Genre]...';


GO
CREATE TABLE [dbo].[T_Genre] (
    [Id_Genre] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_Genre] PRIMARY KEY CLUSTERED ([Id_Genre] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Movie]...';


GO
CREATE TABLE [dbo].[T_Movie] (
    [Id_Movie] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Year]     INT          NOT NULL,
    [TMDB_Id]  INT          NOT NULL,
    CONSTRAINT [PK_1] PRIMARY KEY CLUSTERED ([Id_Movie] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_MovieToGenre]...';


GO
CREATE TABLE [dbo].[T_MovieToGenre] (
    [Id_MovieToGenre] INT NOT NULL,
    [Id_Movie]        INT NOT NULL,
    [Id_Genre]        INT NOT NULL,
    CONSTRAINT [PK_T_MovieToGenre] PRIMARY KEY CLUSTERED ([Id_MovieToGenre] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_MovieToGenre].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_MovieToGenre]([Id_Movie] ASC);


GO
PRINT N'Création de Index [dbo].[T_MovieToGenre].[FK_3]...';


GO
CREATE NONCLUSTERED INDEX [FK_3]
    ON [dbo].[T_MovieToGenre]([Id_Genre] ASC);


GO
PRINT N'Création de Table [dbo].[T_Person]...';


GO
CREATE TABLE [dbo].[T_Person] (
    [Id_Person] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50)  NOT NULL,
    [Country]   NVARCHAR (50) NULL,
    [FirstName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_T_Person] PRIMARY KEY CLUSTERED ([Id_Person] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Rating]...';


GO
CREATE TABLE [dbo].[T_Rating] (
    [ID_Rating]  INT           IDENTITY (1, 1) NOT NULL,
    [Id_User]    INT           NOT NULL,
    [Id_Movie]   INT           NOT NULL,
    [Rating]     INT           NOT NULL,
    [Date]       DATETIME      NOT NULL,
    [Commentary] VARCHAR (MAX) NULL,
    [Approbate]  INT           NOT NULL,
    CONSTRAINT [PK_T_Rating] PRIMARY KEY CLUSTERED ([ID_Rating] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_Rating].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_Rating]([Id_User] ASC);


GO
PRINT N'Création de Index [dbo].[T_Rating].[FK_3]...';


GO
CREATE NONCLUSTERED INDEX [FK_3]
    ON [dbo].[T_Rating]([Id_Movie] ASC);


GO
PRINT N'Création de Table [dbo].[T_User]...';


GO
CREATE TABLE [dbo].[T_User] (
    [Id_User]           INT          IDENTITY (1, 1) NOT NULL,
    [Username]          VARCHAR (50) NOT NULL,
    [Password]          VARCHAR (50) NOT NULL,
    [IsActive]          BIT          NOT NULL,
    [Registration_Date] DATETIME     NOT NULL,
    [Email]             VARCHAR (50) NULL,
    [ID_UserRole]       INT          NULL,
    CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED ([Id_User] ASC)
);


GO
PRINT N'Création de Contrainte par défaut contrainte sans nom sur [dbo].[T_Cineclub]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD DEFAULT 0 FOR [Id_Movie_5];


GO
PRINT N'Création de Contrainte par défaut contrainte sans nom sur [dbo].[T_Rating]...';


GO
ALTER TABLE [dbo].[T_Rating]
    ADD DEFAULT 0 FOR [Approbate];


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Id_Movie_1_T_Movie]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD CONSTRAINT [FK_Id_Movie_1_T_Movie] FOREIGN KEY ([Id_Movie_1]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Id_Movie_2_T_Movie]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD CONSTRAINT [FK_Id_Movie_2_T_Movie] FOREIGN KEY ([Id_Movie_2]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Id_Movie_3_T_Movie]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD CONSTRAINT [FK_Id_Movie_3_T_Movie] FOREIGN KEY ([Id_Movie_3]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Id_Movie_4_T_Movie]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD CONSTRAINT [FK_Id_Movie_4_T_Movie] FOREIGN KEY ([Id_Movie_4]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Id_Movie_5_T_Movie]...';


GO
ALTER TABLE [dbo].[T_Cineclub]
    ADD CONSTRAINT [FK_Id_Movie_5_T_Movie] FOREIGN KEY ([Id_Movie_5]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_4]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre]
    ADD CONSTRAINT [FK_4] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_5]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre]
    ADD CONSTRAINT [FK_5] FOREIGN KEY ([Id_Genre]) REFERENCES [dbo].[T_Genre] ([Id_Genre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_10]...';


GO
ALTER TABLE [dbo].[T_Rating]
    ADD CONSTRAINT [FK_10] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_9]...';


GO
ALTER TABLE [dbo].[T_Rating]
    ADD CONSTRAINT [FK_9] FOREIGN KEY ([Id_User]) REFERENCES [dbo].[T_User] ([Id_User]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '05e4c1a6-a97d-4f34-9e74-9c871d9f86ac')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('05e4c1a6-a97d-4f34-9e74-9c871d9f86ac')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '57cf40e2-15c3-4934-9d06-f80b91d9adce')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('57cf40e2-15c3-4934-9d06-f80b91d9adce')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '18a20399-4e42-4f32-a847-61c5e58ea201')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('18a20399-4e42-4f32-a847-61c5e58ea201')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6228c55e-3796-4bd7-9478-1828672a80e4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6228c55e-3796-4bd7-9478-1828672a80e4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd6dd07e9-3502-46d2-85fe-4ca903312414')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d6dd07e9-3502-46d2-85fe-4ca903312414')

GO

GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [DDYDLS_CineClubDb]
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Star Wars, épisode IV : Un nouvel espoir'
           ,1977
           ,11)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Gladiator'
           ,2000
           ,98)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Labyrinthe'
           ,1986
           ,13597)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Legend'
           ,1985
           ,11976)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Taram et le chaudron magique'
           ,1985
           ,10957)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Conan le barbare'
           ,1982
           ,9387)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Pokémon Detective Pikachu'
           ,2019
           ,447404)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Elfe'
           ,2003
           ,10719)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Le Roi Lion'
           ,2019
           ,420818)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Le livre de la jungle'
           ,2016
           ,278927)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Zathura : Une aventure spatiale'
           ,2005
           ,6795)
GO

USE [DDYDLS_CineClubDb]
GO

INSERT INTO [dbo].[T_Cineclub]
           ([Id_Movie_1]
           ,[Id_Movie_2]
           ,[Id_Movie_3]
           ,[Id_Movie_4]
		   ,[Id_Movie_5]
           ,[NumberOfCineclub]
           ,[Begin]
           ,[End]
           ,[Title])
     VALUES
           (3,
           4,
           5,
           6,
           1,
           1,
           '01/06/2023',
           '30/06/2023'
           ,'Dark Fantasy')
GO

INSERT INTO [dbo].[T_Cineclub]
           ([Id_Movie_1]
           ,[Id_Movie_2]
           ,[Id_Movie_3]
           ,[Id_Movie_4]
           ,[Id_Movie_5]
           ,[NumberOfCineclub]
           ,[Begin]
           ,[End]
           ,[Title])
     VALUES
           (8,
            9,
           10,
           11,
           1,
           2,
           '19/07/2023',
           '23/08/2023'
           ,'Jon Favreau')
GO

INSERT INTO [dbo].[T_User]
           ([Username]
           ,[Password]
           ,[IsActive]
           ,[Registration_Date]
           ,[Email]
           ,[ID_UserRole])
     VALUES
           ('Yraelias',
            'mvFbM25qlhmShTffMLLmojdlafz51+dz7M7eZWBlKaA=',
            1,
            '01/01/2024',
           'davidflemal@gmail.com'
           ,1)
GO

USE [DDYDLS_CineClubDb]
GO

INSERT INTO [dbo].[T_User]
           ([Username]
           ,[Password]
           ,[IsActive]
           ,[Registration_Date]
           ,[Email]
           ,[ID_UserRole])
     VALUES
           ('Yraelis',
            'mvFbM25qlhmShTffMLLmojdlafz51+dz7M7eZWBlKaA=',
            1,
            '01/01/2024',
           'yraelias@gmail.com'
           ,1)
GO

INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           ,[Approbate]
           )
     VALUES
           (1
           ,1
           ,5
           ,'01/01/2024'
           ,'Commentaire sur Star Wars'
           ,1)
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary],
           [Approbate]
           )
     VALUES
           (2
           ,1
           ,2
           ,'01/01/2024'
           ,'Commentaire sur Star Wars Yralis'
           ,0)
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           ,[Approbate]
           )
     VALUES
           (1
           ,2
           ,6
           ,'01/01/2024'
           ,'Commentaire sur Gladiator'
           ,0)
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           ,[Approbate]
           )
     VALUES
           (2
           ,2
           ,6
           ,'01/01/2024'
           ,'Commentaire sur Gladiator Yralis'
           ,1)
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           ,[Approbate]
           )
     VALUES
           (1
           ,3
           ,5
           ,'01/01/2024'
           ,'Commentaire Pikachu'
           ,1)
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
