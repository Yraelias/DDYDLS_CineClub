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
