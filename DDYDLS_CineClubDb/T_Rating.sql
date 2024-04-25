CREATE TABLE [T_Rating]
(
 [ID_Rating] int NOT NULL IDENTITY ,
 [ID_User]   int NOT NULL ,
 [Id_Movie]  int NOT NULL ,
 [Rating]    int NOT NULL ,
 [Date]      datetime NOT NULL ,



 [Commentary] VARCHAR(MAX) NULL, 
    [Approbate] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_10] FOREIGN KEY ([Id_Movie])  REFERENCES [T_Movie]([Id_Movie]),
 CONSTRAINT [FK_9] FOREIGN KEY ([ID_User])  REFERENCES [T_User]([ID_User]), 
    CONSTRAINT [PK_T_Rating] PRIMARY KEY ([ID_Rating])
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_Rating] 
 (
  [ID_User] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_3] ON [T_Rating] 
 (
  [Id_Movie] ASC
 )

GO