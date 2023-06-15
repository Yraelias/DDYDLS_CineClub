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
USE [$(DatabaseName)];


GO
PRINT N'Suppression de Clé étrangère [dbo].[FK_9]...';


GO
ALTER TABLE [dbo].[T_Rating] DROP CONSTRAINT [FK_9];


GO
PRINT N'Suppression de Clé étrangère [dbo].[FK_T_User_ToTable]...';


GO
ALTER TABLE [dbo].[T_User] DROP CONSTRAINT [FK_T_User_ToTable];


GO
PRINT N'Début de la régénération de la table [dbo].[T_User]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_T_User] (
    [Id_User]           INT          IDENTITY (1, 1) NOT NULL,
    [Username]          VARCHAR (50) NOT NULL,
    [Password]          VARCHAR (50) NOT NULL,
    [IsActive]          BIT          NOT NULL,
    [Registration_Date] DATETIME     NOT NULL,
    [Email]             VARCHAR (50) NULL,
    [ID_UserRole]       INT          NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_T_User1] PRIMARY KEY CLUSTERED ([Id_User] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[T_User])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_User] ON;
        INSERT INTO [dbo].[tmp_ms_xx_T_User] ([Id_User], [Username], [Password], [IsActive], [Registration_Date], [Email], [ID_UserRole])
        SELECT   [Id_User],
                 [Username],
                 [Password],
                 [IsActive],
                 [Registration_Date],
                 [Email],
                 [ID_UserRole]
        FROM     [dbo].[T_User]
        ORDER BY [Id_User] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_User] OFF;
    END

DROP TABLE [dbo].[T_User];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_User]', N'T_User';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_T_User1]', N'PK_T_User', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_9]...';


GO
ALTER TABLE [dbo].[T_Rating] WITH NOCHECK
    ADD CONSTRAINT [FK_9] FOREIGN KEY ([Id_User]) REFERENCES [dbo].[T_User] ([Id_User]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_T_User_ToTable]...';


GO
ALTER TABLE [dbo].[T_User] WITH NOCHECK
    ADD CONSTRAINT [FK_T_User_ToTable] FOREIGN KEY ([ID_UserRole]) REFERENCES [dbo].[T_Role] ([Id_Role]);


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[T_Rating] WITH CHECK CHECK CONSTRAINT [FK_9];

ALTER TABLE [dbo].[T_User] WITH CHECK CHECK CONSTRAINT [FK_T_User_ToTable];


GO
PRINT N'Mise à jour terminée.';


GO
