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
USE [DDYDLS_CineClubDb]
GO

INSERT INTO [dbo].[T_Studio]
           ([Name])
     VALUES
           ('LucasFilm')
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Id_Studio]
           ,[Synopsis]
           ,[Year])
     VALUES
           ('Star Wars IV',1,'La guerre civile fait rage entre l Empire galactique et l Alliance rebelle. Capturée par les troupes de choc de l Empereur menées par le sombre et impitoyable Dark Vador, la princesse Leia Organa dissimule les plans de l Etoile Noire.',1977)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Id_Studio]
           ,[Synopsis]
           ,[Year])
     VALUES
           ('Star Wars VII',1,'Plus de 30 ans après la bataille d Endor, la galaxie n en a pas fini avec la tyrannie et l oppression. Les membres de l Alliance rebelle, devenus la "Résistance," combattent les vestiges de l Empire réunis sous la bannière du "Premier Ordre." Un mystérieux guerrier, Kylo Ren, semble vouer un culte à Dark Vador.',2015)
GO

GO
PRINT N'Mise à jour terminée.';


GO
