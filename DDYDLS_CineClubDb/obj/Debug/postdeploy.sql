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
