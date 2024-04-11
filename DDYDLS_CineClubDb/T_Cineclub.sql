CREATE TABLE [dbo].[T_Cineclub]
(
	[Id_Cineclub] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_Movie_1] INT NOT NULL, 
    [Id_Movie_2] INT NOT NULL, 
    [Id_Movie_3] INT NOT NULL, 
    [Id_Movie_4] INT NOT NULL, 
    [Id_Movie_5] INT NULL, 
    [NumberOfCineclub] INT NOT NULL, 
    [Begin] DATE NOT NULL , 
    [End] DATE NULL, 
    [Link_Yt] NCHAR(10) NULL, 
    [Title] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Id_Movie_1_T_Movie] FOREIGN KEY ([Id_Movie_1]) REFERENCES [T_Movie]([Id_Movie]),
    CONSTRAINT [FK_Id_Movie_2_T_Movie] FOREIGN KEY ([Id_Movie_2]) REFERENCES [T_Movie]([Id_Movie]),
    CONSTRAINT [FK_Id_Movie_3_T_Movie] FOREIGN KEY ([Id_Movie_3]) REFERENCES [T_Movie]([Id_Movie]),
    CONSTRAINT [FK_Id_Movie_4_T_Movie] FOREIGN KEY ([Id_Movie_4]) REFERENCES [T_Movie]([Id_Movie]),
    CONSTRAINT [FK_Id_Movie_5_T_Movie] FOREIGN KEY ([Id_Movie_5]) REFERENCES [T_Movie]([Id_Movie])
)

GO
