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
:setvar DefaultDataPath "D:\SQLServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "D:\SQLServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

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
PRINT N'Création de Table [dbo].[T_Casting]...';


GO
CREATE TABLE [dbo].[T_Casting] (
    [Id_Casting] INT NOT NULL,
    [Id_Movie]   INT NOT NULL,
    [Id_Role]    INT NOT NULL,
    [Id_Person]  INT NOT NULL,
    CONSTRAINT [PK_T_Casting] PRIMARY KEY CLUSTERED ([Id_Casting] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_Casting].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_Casting]([Id_Movie] ASC);


GO
PRINT N'Création de Index [dbo].[T_Casting].[FK_3]...';


GO
CREATE NONCLUSTERED INDEX [FK_3]
    ON [dbo].[T_Casting]([Id_Person] ASC);


GO
PRINT N'Création de Index [dbo].[T_Casting].[FK_4]...';


GO
CREATE NONCLUSTERED INDEX [FK_4]
    ON [dbo].[T_Casting]([Id_Role] ASC);


GO
PRINT N'Création de Table [dbo].[T_Country]...';


GO
CREATE TABLE [dbo].[T_Country] (
    [Id_Country] INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_Country] PRIMARY KEY CLUSTERED ([Id_Country] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Genre]...';


GO
CREATE TABLE [dbo].[T_Genre] (
    [Id_Genre] INT          NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_Genre] PRIMARY KEY CLUSTERED ([Id_Genre] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Movie]...';


GO
CREATE TABLE [dbo].[T_Movie] (
    [Id_Movie]  INT          NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Id_Studio] INT          NULL,
    [Synopsis]  VARCHAR (50) NOT NULL,
    [Year]      INT          NOT NULL,
    CONSTRAINT [PK_T_Movie] PRIMARY KEY CLUSTERED ([Id_Movie] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_Movie].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_Movie]([Id_Studio] ASC);


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
    [Id_Person] INT          NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_Person] PRIMARY KEY CLUSTERED ([Id_Person] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Rating]...';


GO
CREATE TABLE [dbo].[T_Rating] (
    [ID_Rating] INT      NOT NULL,
    [Id_User]   INT      NOT NULL,
    [Id_Movie]  INT      NOT NULL,
    [Rating]    INT      NOT NULL,
    [Date]      DATETIME NOT NULL,
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
PRINT N'Création de Table [dbo].[T_Role]...';


GO
CREATE TABLE [dbo].[T_Role] (
    [Id_Role] INT          NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_Role] PRIMARY KEY CLUSTERED ([Id_Role] ASC)
);


GO
PRINT N'Création de Table [dbo].[T_Studio]...';


GO
CREATE TABLE [dbo].[T_Studio] (
    [Id_Studio]  INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Id_Country] INT          NOT NULL,
    CONSTRAINT [PK_T_Studio] PRIMARY KEY CLUSTERED ([Id_Studio] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_Studio].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_Studio]([Id_Country] ASC);


GO
PRINT N'Création de Table [dbo].[T_User]...';


GO
CREATE TABLE [dbo].[T_User] (
    [Id_User]     INT          NOT NULL,
    [Username]    VARCHAR (50) NOT NULL,
    [ID_UserRole] INT          NOT NULL,
    [Password]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED ([Id_User] ASC)
);


GO
PRINT N'Création de Index [dbo].[T_User].[FK_2]...';


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [dbo].[T_User]([ID_UserRole] ASC);


GO
PRINT N'Création de Table [dbo].[T_UserRole]...';


GO
CREATE TABLE [dbo].[T_UserRole] (
    [ID_UserRole] INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_1] PRIMARY KEY CLUSTERED ([ID_UserRole] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_1]...';


GO
ALTER TABLE [dbo].[T_Casting]
    ADD CONSTRAINT [FK_1] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_2]...';


GO
ALTER TABLE [dbo].[T_Casting]
    ADD CONSTRAINT [FK_2] FOREIGN KEY ([Id_Person]) REFERENCES [dbo].[T_Person] ([Id_Person]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_3]...';


GO
ALTER TABLE [dbo].[T_Casting]
    ADD CONSTRAINT [FK_3] FOREIGN KEY ([Id_Role]) REFERENCES [dbo].[T_Role] ([Id_Role]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_6]...';


GO
ALTER TABLE [dbo].[T_Movie]
    ADD CONSTRAINT [FK_6] FOREIGN KEY ([Id_Studio]) REFERENCES [dbo].[T_Studio] ([Id_Studio]);


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
PRINT N'Création de Clé étrangère [dbo].[FK_7]...';


GO
ALTER TABLE [dbo].[T_Studio]
    ADD CONSTRAINT [FK_7] FOREIGN KEY ([Id_Country]) REFERENCES [dbo].[T_Country] ([Id_Country]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_8]...';


GO
ALTER TABLE [dbo].[T_User]
    ADD CONSTRAINT [FK_8] FOREIGN KEY ([ID_UserRole]) REFERENCES [dbo].[T_UserRole] ([ID_UserRole]);


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
