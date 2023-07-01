CREATE TABLE [T_Studio]
(
 [Id_Studio]  int NOT NULL ,
 [Name]       varchar(50) NOT NULL ,
 [Id_Country]  int NOT NULL ,


    CONSTRAINT [PK_T_Studio] PRIMARY KEY ([Id_Studio]) 
);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [T_Studio] 
 (
  [Id_Country] ASC
 )

GO
