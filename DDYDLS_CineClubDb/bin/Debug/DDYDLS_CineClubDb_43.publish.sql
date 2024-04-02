﻿/*
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
USE [$(DatabaseName)];


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
           ('Pokémon Detective Pikachu'
           ,2019
           ,447404)
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
            '0000',
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
            '0000',
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
           )
     VALUES
           (2
           ,1
           ,5
           ,'01/01/2024'
           ,'Commentaire sur Star Wars')
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           )
     VALUES
           (3
           ,1
           ,2
           ,'01/01/2024'
           ,'Commentaire sur Star Wars Yralis')
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           )
     VALUES
           (2
           ,3
           ,6
           ,'01/01/2024'
           ,'Commentaire sur Gladiator')
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           )
     VALUES
           (3
           ,1
           ,6
           ,'01/01/2024'
           ,'Commentaire sur Gladiator Yralis')
GO
INSERT INTO [dbo].[T_Rating]
           ([Id_User]
           ,[Id_Movie]
           ,[Rating]
           ,[Date]
           ,[Commentary]
           )
     VALUES
           (2
           ,1
           ,5
           ,'01/01/2024'
           ,'Commentaire Pikachu')
GO

GO
PRINT N'Mise à jour terminée.';


GO