CREATE TABLE [T_Person]
(
 [Id_Person] int NOT NULL IDENTITY ,
 [Name]      varchar(50) NOT NULL, 
    [Country] NVARCHAR(50) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_T_Person] PRIMARY KEY ([Id_Person]) ,


);
GO
