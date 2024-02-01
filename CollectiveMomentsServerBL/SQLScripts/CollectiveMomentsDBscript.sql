
--scaffold-Dbcontext "Server=localhost\sqlexpress;Database=CollectiveMomentsDB;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models -Context CollectiveMomentsDbContext -force 
Use master

Create Database CollectiveMomentsDB

Go

Use CollectiveMomentsDB

Go

Create Table Users (

ID int Identity primary key,

Email nvarchar(100),

FirstName nvarchar(30),

LastName nvarchar(30),

Passwrd nvarchar(30) Not null,

UserName nvarchar(30) Not null,




CONSTRAINT UC_Email UNIQUE(Email)

)

Create Table Album (

ID int Identity primary key,

AlbumCover nvarchar(100),

Longitude nvarchar(30),

Latitude nvarchar(30),

AdminID INT NOT NULL, 

AlbumTitle nvarchar(30)



)
CREATE TABLE [dbo].[AlbumMedia]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [albumid] INT NOT NULL, 
    [mediaurl] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_AlbumMedia_ToAlbum] FOREIGN KEY ([albumid]) REFERENCES [Album]([Id])
)

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName]) VALUES (1, N'A', N'A', N'A', N'123', N'A')
SET IDENTITY_INSERT [dbo].[Users] OFF



Go


GO