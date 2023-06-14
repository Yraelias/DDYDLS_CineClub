CREATE TABLE [T_User]
(
 [Id_User]           int NOT NULL ,
 [Username]          varchar(50) NOT NULL ,
 [Password]          varchar(50) NOT NULL ,
 [Country]           varchar(50) NULL ,
 [IsActive]          bit NOT NULL ,
 [Registration_Date] datetime NOT NULL ,
 [Language]          varchar(50) NULL ,
 [Email]             varchar(50) NULL ,
 [Is_Admin]          bit NOT NULL ,
 [Is_Moderator]      bit NOT NULL ,
 

    CONSTRAINT [PK_T_User] PRIMARY KEY ([Id_User])
);

GO
