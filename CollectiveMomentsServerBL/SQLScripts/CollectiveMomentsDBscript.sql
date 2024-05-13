
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
    [MediaCount] INT NULL,
    [AlbumTitle] NVARCHAR (30)  NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC), 
   
);

CREATE TABLE [dbo].[MediaItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AlbumID] INT NULL, 
    [MediaID] INT  NULL, 
    CONSTRAINT [FK_MediaItem_Media] FOREIGN KEY ([MediaID]) REFERENCES [Media]([ID]), 
    CONSTRAINT [FK_MediaItem_Album] FOREIGN KEY (AlbumID) REFERENCES [Album](ID), 
    
)
CREATE TABLE [dbo].[AlbumMedia]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [albumid] INT NOT NULL, 
    [mediaurl] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_AlbumMedia_ToAlbum] FOREIGN KEY ([albumid]) REFERENCES [Album]([Id])
)

CREATE TABLE [dbo].[Members]
(
	[ID] INT NOT NULL PRIMARY KEY , 
    [AlbumID] INT NULL, 
    [UserID] INT  NULL, 
    CONSTRAINT [FK_UsersAlbum_User] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]), 
    CONSTRAINT [FK_UsersAlbum_Album] FOREIGN KEY (AlbumID) REFERENCES [Album](ID), 
   
)
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName]) VALUES (1, N'A', N'A', N'A', N'123', N'A')
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Album] ON
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (1, N'cover1.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (2, N'cover2.jpg', N'-122.084', N'37.421998333333335', 1, NULL)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (3, N'cover3.jpg', N'-122.084', N'37.421998333333335', 1, N'Album 2')
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (4, N'cover4.jpg', N'-122.084', N'37.421998333333335', 2, N'Album 1')
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle],[MediaCount]) VALUES (5, N'cover6.jpg', N'-234.084', N'54.921998333333335', 1, N'Concert',4)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (6, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 2')
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (7, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 3')
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (8, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 4')
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle]) VALUES (9, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 5')


SET IDENTITY_INSERT [dbo].[Album] OFF

SET IDENTITY_INSERT [dbo].[Media] ON
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (1, 1, 0,  N'concert1.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (2, 1, 0,  N'concert2.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (3, 1, 0,  N'concert3.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (4, 1, 0,  N'concert4.jpg')
SET IDENTITY_INSERT [dbo].[Media] OFF


INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (1,5, 1)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (2,5, 2)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (3,5, 3)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (4,5, 4)




INSERT INTO [dbo].[Members] ([ID] , [UserID], [AlbumID]) VALUES (1,1, 7)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (2,1, 6)






Go


GO