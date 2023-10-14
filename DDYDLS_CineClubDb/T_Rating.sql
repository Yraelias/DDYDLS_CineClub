CREATE TABLE [T_Rating]
(
 [ID_Rating] int NOT NULL IDENTITY ,
 [Id_User]   int NOT NULL ,
 [Id_Movie]  int NOT NULL ,
 [Rating]    int NOT NULL ,
 [Date]      datetime NOT NULL ,



 CONSTRAINT [FK_10] FOREIGN KEY ([Id_Movie])  REFERENCES [T_Movie]([Id_Movie]),
 CONSTRAINT [FK_9] FOREIGN KEY ([Id_User])  REFERENCES [T_User]([Id_User]), 
    CONSTRAINT [PK_T_Rating] PRIMARY KEY ([ID_Rating])
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_Rating] 
 (
  [Id_User] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_3] ON [T_Rating] 
 (
  [Id_Movie] ASC
 )

GO