/*
Script de déploiement pour DDYDLS_CineClub

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DDYDLS_CineClub"
:setvar DefaultFilePrefix "DDYDLS_CineClub"
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
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
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
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


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
    [Id_Person] INT           NOT NULL,
    [Name]      VARCHAR (50)  NOT NULL,
    [Country]   NVARCHAR (50) NULL,
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
    [Id_User]           INT          NOT NULL,
    [Username]          VARCHAR (50) NOT NULL,
    [Password]          VARCHAR (50) NOT NULL,
    [IsActive]          BIT          NOT NULL,
    [Registration_Date] DATETIME     NOT NULL,
    [Language]          VARCHAR (50) NULL,
    [Email]             VARCHAR (50) NULL,
    CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED ([Id_User] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_1]...';


GO
ALTER TABLE [dbo].[T_Casting] WITH NOCHECK
    ADD CONSTRAINT [FK_1] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_2]...';


GO
ALTER TABLE [dbo].[T_Casting] WITH NOCHECK
    ADD CONSTRAINT [FK_2] FOREIGN KEY ([Id_Person]) REFERENCES [dbo].[T_Person] ([Id_Person]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_3]...';


GO
ALTER TABLE [dbo].[T_Casting] WITH NOCHECK
    ADD CONSTRAINT [FK_3] FOREIGN KEY ([Id_Role]) REFERENCES [dbo].[T_Role] ([Id_Role]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_6]...';


GO
ALTER TABLE [dbo].[T_Movie] WITH NOCHECK
    ADD CONSTRAINT [FK_6] FOREIGN KEY ([Id_Studio]) REFERENCES [dbo].[T_Studio] ([Id_Studio]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_4]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_4] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_5]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_5] FOREIGN KEY ([Id_Genre]) REFERENCES [dbo].[T_Genre] ([Id_Genre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_10]...';


GO
ALTER TABLE [dbo].[T_Rating] WITH NOCHECK
    ADD CONSTRAINT [FK_10] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_9]...';


GO
ALTER TABLE [dbo].[T_Rating] WITH NOCHECK
    ADD CONSTRAINT [FK_9] FOREIGN KEY ([Id_User]) REFERENCES [dbo].[T_User] ([Id_User]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_7]...';


GO
ALTER TABLE [dbo].[T_Studio] WITH NOCHECK
    ADD CONSTRAINT [FK_7] FOREIGN KEY ([Id_Country]) REFERENCES [dbo].[T_Country] ([Id_Country]);


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[T_Casting] WITH CHECK CHECK CONSTRAINT [FK_1];

ALTER TABLE [dbo].[T_Casting] WITH CHECK CHECK CONSTRAINT [FK_2];

ALTER TABLE [dbo].[T_Casting] WITH CHECK CHECK CONSTRAINT [FK_3];

ALTER TABLE [dbo].[T_Movie] WITH CHECK CHECK CONSTRAINT [FK_6];

ALTER TABLE [dbo].[T_MovieToGenre] WITH CHECK CHECK CONSTRAINT [FK_4];

ALTER TABLE [dbo].[T_MovieToGenre] WITH CHECK CHECK CONSTRAINT [FK_5];

ALTER TABLE [dbo].[T_Rating] WITH CHECK CHECK CONSTRAINT [FK_10];

ALTER TABLE [dbo].[T_Rating] WITH CHECK CHECK CONSTRAINT [FK_9];

ALTER TABLE [dbo].[T_Studio] WITH CHECK CHECK CONSTRAINT [FK_7];


GO
PRINT N'Mise à jour terminée.';


GO
