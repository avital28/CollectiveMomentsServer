
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
ProfilePicture nvarchar(30),



CONSTRAINT UC_Email UNIQUE(Email)

)
Create Table Media (

ID int Identity primary key,

Sources nvarchar(100),

IsImage bit,

IsVideo bit,

)
CREATE TABLE [dbo].[Album] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [AlbumCover] NVARCHAR (100) NULL,
    [Longitude]  NVARCHAR (30)  NULL,
    [Latitude]   NVARCHAR (30)  NULL,
    [AdminID]    INT            NOT NULL,
    
    [AlbumTitle] NVARCHAR (30)  NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC), 
   
);

CREATE TABLE [dbo].[MediaItem]
(
	[Id] INT NOT NULL , 
    [AlbumID] INT NULL, 
    [MediaID] INT  NULL, 
    CONSTRAINT [FK_MediaItem_Media] FOREIGN KEY ([MediaID]) REFERENCES [Media]([ID]), 
    CONSTRAINT [FK_MediaItem_Album] FOREIGN KEY (AlbumID) REFERENCES [Album](ID), 
    PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[AlbumMedia]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [albumid] INT NOT NULL, 
    [mediaurl] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_AlbumMedia_ToAlbum] FOREIGN KEY ([albumid]) REFERENCES [Album]([Id])
)

CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL , 
    [AlbumID] INT NULL, 
    [UserID] INT  NULL, 
    CONSTRAINT [FK_UsersAlbum_User] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]), 
    CONSTRAINT [FK_UsersAlbum_Album] FOREIGN KEY (AlbumID) REFERENCES [Album](ID), 
    PRIMARY KEY ([Id])
)
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName]) VALUES (1, N'A', N'A', N'A', N'123', N'A')
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Album] ON
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (1, N'cover1.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (2, N'cover2.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (3, N'cover3.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (4, N'cover4.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (5, N'cover4.jpg', N'-234.084', N'54.921998333333335', 1, NULL)

SET IDENTITY_INSERT [dbo].[Album] OFF




Go


GO