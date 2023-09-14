CREATE TABLE [T_Movie]
(
 [Id_Movie]  int NOT NULL IDENTITY ,
 [Name]      varchar(50) NOT NULL ,
 [Id_Studio] int NULL ,
 [Synopsis]  varchar(MAX) NOT NULL ,
 [Year]      int NOT NULL ,

 
 CONSTRAINT [FK_6] FOREIGN KEY ([Id_Studio])  REFERENCES [T_Studio]([Id_Studio]), 
    CONSTRAINT [PK_T_Movie] PRIMARY KEY ([Id_Movie])
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_Movie] 
 (
  [Id_Studio] ASC
 )

GO
