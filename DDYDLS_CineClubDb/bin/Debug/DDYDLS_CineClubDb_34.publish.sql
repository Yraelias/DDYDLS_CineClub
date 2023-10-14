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
PRINT N'Suppression de Clé étrangère [dbo].[FK_4]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] DROP CONSTRAINT [FK_4];


GO
PRINT N'Suppression de Clé étrangère [dbo].[FK_10]...';


GO
ALTER TABLE [dbo].[T_Rating] DROP CONSTRAINT [FK_10];


GO
PRINT N'Début de la régénération de la table [dbo].[T_Movie]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_T_Movie] (
    [Id_Movie] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Year]     INT          NOT NULL,
    [TMDB_Id]  INT          NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_11] PRIMARY KEY CLUSTERED ([Id_Movie] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[T_Movie])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_Movie] ON;
        INSERT INTO [dbo].[tmp_ms_xx_T_Movie] ([Id_Movie], [Name], [Year], [TMDB_Id])
        SELECT   [Id_Movie],
                 [Name],
                 [Year],
                 [TMDB_Id]
        FROM     [dbo].[T_Movie]
        ORDER BY [Id_Movie] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_T_Movie] OFF;
    END

DROP TABLE [dbo].[T_Movie];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_Movie]', N'T_Movie';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_11]', N'PK_1', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_4]...';


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH NOCHECK
    ADD CONSTRAINT [FK_4] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_10]...';


GO
ALTER TABLE [dbo].[T_Rating] WITH NOCHECK
    ADD CONSTRAINT [FK_10] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[T_Movie] ([Id_Movie]);


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
GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[T_MovieToGenre] WITH CHECK CHECK CONSTRAINT [FK_4];

ALTER TABLE [dbo].[T_Rating] WITH CHECK CHECK CONSTRAINT [FK_10];


GO
PRINT N'Mise à jour terminée.';


GO
