CREATE TABLE [T_User]
(
 [Id_User]           int NOT NULL ,
 [Username]          varchar(50) NOT NULL ,
 [Password]          varchar(50) NOT NULL ,
 [IsActive]          bit NOT NULL ,
 [Registration_Date] datetime NOT NULL ,
 [Email]             varchar(50) NULL ,
 [ID_UserRole]       int,
 

    CONSTRAINT [PK_T_User] PRIMARY KEY ([Id_User]), 
    CONSTRAINT [FK_T_User_ToTable] FOREIGN KEY ([ID_UserRole]) REFERENCES [T_Role]([ID_Role])
);

GO
