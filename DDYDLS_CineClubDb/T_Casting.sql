CREATE TABLE [T_Casting]
(
 [Id_Casting] int NOT NULL ,
 [Id_Movie]   int NOT NULL ,
 [Id_Role]    int NOT NULL ,
 [Id_Person]  int NOT NULL ,


 CONSTRAINT [FK_1] FOREIGN KEY ([Id_Movie])  REFERENCES [T_Movie]([Id_Movie]),
 CONSTRAINT [FK_2] FOREIGN KEY ([Id_Person])  REFERENCES [T_Person]([Id_Person]),
 CONSTRAINT [FK_3] FOREIGN KEY ([Id_Role])  REFERENCES [T_Role]([Id_Role]), 
    CONSTRAINT [PK_T_Casting] PRIMARY KEY ([Id_Casting])
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_Casting] 
 (
  [Id_Movie] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_3] ON [T_Casting] 
 (
  [Id_Person] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_4] ON [T_Casting] 
 (
  [Id_Role] ASC
 )

GO
