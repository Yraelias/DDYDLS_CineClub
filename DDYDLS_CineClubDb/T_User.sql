CREATE TABLE [T_User]
(
 [ID_User]           int NOT NULL IDENTITY ,
 [Username]          varchar(50) NOT NULL ,
 [Password]          varchar(50) NOT NULL ,
 [IsActive]          bit NOT NULL ,
 [Registration_Date] datetime NOT NULL ,
 [Email]             varchar(50) NULL ,
 [ID_UserRole]       int,
 

    CONSTRAINT [PK_T_User] PRIMARY KEY ([ID_User])
);

GO
