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
PRINT N'Suppression de Clé étrangère [dbo].[FK_5]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] DROP CONSTRAINT [FK_5];


GO
PRINT N'Début de la régénération de la table [dbo].[T_Genre]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_T_Genre] (
    [Id_Genre] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_T_Genre1] PRIMARY KEY CLUSTERED ([Id_Genre] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[T_Genre])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_Genre] ON;
        INSERT INTO [dbo].[tmp_ms_xx_T_Genre] ([Id_Genre], [Name])
        SELECT   [Id_Genre],
                 [Name]
        FROM     [dbo].[T_Genre]
        ORDER BY [Id_Genre] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_Genre] OFF;
    END

DROP TABLE [dbo].[T_Genre];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_Genre]', N'T_Genre';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_T_Genre1]', N'PK_T_Genre', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_5]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_5] FOREIGN KEY ([Id_Genre]) REFERENCES [dbo].[T_Genre] ([Id_Genre]);


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH CHECK CHECK CONSTRAINT [FK_5];


GO
PRINT N'Mise à jour terminée.';


GO
