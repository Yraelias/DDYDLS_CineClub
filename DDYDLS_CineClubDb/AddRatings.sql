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

INSERT INTO [dbo].[T_Rating]
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
