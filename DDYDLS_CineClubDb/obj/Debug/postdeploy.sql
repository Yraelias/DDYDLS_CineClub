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
           (1
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
           (2
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
           (1
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
           (2
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
           (1
           ,1
           ,5
           ,'01/01/2024'
           ,'Commentaire Pikachu')
GO
