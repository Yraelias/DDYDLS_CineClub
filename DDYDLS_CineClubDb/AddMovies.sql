﻿/*
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

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Elfe'
           ,2003
           ,10719)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Le Roi Lion'
           ,2019
           ,420818)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Le livre de la jungle'
           ,2016
           ,278927)
GO

INSERT INTO [dbo].[T_Movie]
           ([Name]
           ,[Year]
           ,[TMDB_Id])
     VALUES
           ('Zathura : Une aventure spatiale'
           ,2005
           ,6795)
GO

USE [DDYDLS_CineClubDb]
GO

INSERT INTO [dbo].[T_Cineclub]
           ([Id_Movie_1]
           ,[Id_Movie_2]
           ,[Id_Movie_3]
           ,[Id_Movie_4]
		   ,[Id_Movie_5]
           ,[NumberOfCineclub]
           ,[Begin]
           ,[End]
           ,[Title])
     VALUES
           (3,
           4,
           5,
           6,
           1,
           1,
           '01/06/2023',
           '30/06/2023'
           ,'Dark Fantasy')
GO

INSERT INTO [dbo].[T_Cineclub]
           ([Id_Movie_1]
           ,[Id_Movie_2]
           ,[Id_Movie_3]
           ,[Id_Movie_4]
           ,[Id_Movie_5]
           ,[NumberOfCineclub]
           ,[Begin]
           ,[End]
           ,[Title])
     VALUES
           (8,
            9,
           10,
           11,
           1,
           2,
           '19/07/2023',
           '23/08/2023'
           ,'Jon Favreau')
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

INSERT INTO [dbo].[T_User]
           ([Username]
           ,[Password]
           ,[IsActive]
           ,[Registration_Date]
           ,[Email]
           ,[ID_UserRole])
     VALUES
           ('Equinoxia',
            'mvFbM25qlhmShTffMLLmojdlafz51+dz7M7eZWBlKaA=',
            1,
            '01/01/2024',
           'obellissens@gmail.com'
           ,1)
GO

INSERT INTO [dbo].[T_Rating]
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
           ([ID_User]
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
