CREATE TABLE [T_MovieToGenre]
(
 [Id_MovieToGenre] int  NOT NULL ,
 [Id_Movie]        int NOT NULL ,
 [Id_Genre]        int NOT NULL ,


 CONSTRAINT [FK_4] FOREIGN KEY ([Id_Movie])  REFERENCES [T_Movie]([Id_Movie]),
 CONSTRAINT [FK_5] FOREIGN KEY ([Id_Genre])  REFERENCES [T_Genre]([Id_Genre]), 
    CONSTRAINT [PK_T_MovieToGenre] PRIMARY KEY ([Id_MovieToGenre])
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_MovieToGenre] 
 (
  [Id_Movie] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_3] ON [T_MovieToGenre] 
 (
  [Id_Genre] ASC
 )

GO
