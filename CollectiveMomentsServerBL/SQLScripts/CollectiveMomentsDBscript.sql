
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
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName], [ProfilePicture]) VALUES (1, N'Avital.p@gmail.com', N'Avital', N'Persky', N'284', N'Avitalp', N'emptyprofilepicture.jpg')
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName], [ProfilePicture]) VALUES (2, N'roni.n@gmail.com', N'Roni', N'Nativ', N'242', N'Roninativ', N'emptyprofilepicture.jpg')
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName], [ProfilePicture]) VALUES (3, N'roni.jacobovsky@gmail.com', N'Roni', N'j', N'192', N'Ronija', N'emptyprofilepicture.jpg')
INSERT INTO [dbo].[Users] ([ID], [Email], [FirstName], [LastName], [Passwrd], [UserName], [ProfilePicture]) VALUES (4, N'yali.e@gmail.com', N'Yali', N'Eldar', N'121', N'Yali', N'emptyprofilepicture.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Album] ON
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (1, N'coldplaycover.jpg', N'-122.084', N'37.421998333333335', 1, N'Coldplay', 5)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (2, N'faircover.jpeg', N'-122.084', N'37.421998333333335', 1, N'Fair', 4)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (3, N'picniccover1.jpeg', N'-122.084', N'37.421998333333335', 1, N'Picnic', 3)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (4, N'poolpartycover.jpeg', N'-122.084', N'37.421998333333335', 2, N'Pool Party', 0)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle],[MediaCount]) VALUES (5, N'taylorconcertcover.jpg', N'-122.084',  N'37.421998333333335', 1, N'The eras tour',8)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (6, N'bdaycover.jpeg', N'-234.084', N'54.921998333333335', 2, N'Birthday', 7)
INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (7, N'coachellacover.jpeg', N'-234.084', N'54.921998333333335', 2, N'Coachella',5)
--INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (8, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 4',0)
--INSERT INTO [dbo].[Album] ([ID], [AlbumCover], [Longitude], [Latitude], [AdminID], [AlbumTitle] ,[MediaCount]) VALUES (9, N'cover4.jpg', N'-234.084', N'54.921998333333335', 2, N'Album 5',0)


SET IDENTITY_INSERT [dbo].[Album] OFF

SET IDENTITY_INSERT [dbo].[Media] ON
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (1, 1, 0,  N'concert1.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (2, 1, 0,  N'concert2.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (3, 1, 0,  N'concert3.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (4, 1, 0,  N'concert4.jpg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (5, 1, 0,  N'erastour1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (6, 1, 0,  N'erastour2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (7, 1, 0,  N'coldplay1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (8, 1, 0,  N'coldplay2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (9, 1, 0,  N'coldplay3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (10, 1, 0,  N'coldplay4.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (11, 1, 0,  N'coldplay5.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (12, 1, 0,  N'fair1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (13, 1, 0,  N'fair2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (14, 1, 0,  N'fair3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (15, 1, 0,  N'fair4.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (16, 1, 0,  N'picnic1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (17, 1, 0,  N'picnic2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (18, 1, 0,  N'picnic3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (19, 1, 0,  N'bday1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (20, 1, 0,  N'bday1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (21, 1, 0,  N'bday2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (22, 1, 0,  N'bday3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (23, 1, 0,  N'bday4.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (24, 1, 0,  N'bday5.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (25, 1, 0,  N'bday6.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (26, 1, 0,  N'bday7.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (27, 1, 0,  N'coachella1.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (28, 1, 0,  N'coachella2.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (29, 1, 0,  N'coachella3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (30, 1, 0,  N'coachella4.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (31, 1, 0,  N'coachella5.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (32, 1, 0,  N'erastour3.jpeg')
INSERT INTO [dbo].[Media] ([ID], [IsImage], [IsVideo], [Sources]) VALUES (33, 1, 0,  N'erastour4.jpeg')

SET IDENTITY_INSERT [dbo].[Media] OFF


INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (1,5, 1)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (2,5, 2)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (3,5, 3)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (4,5, 4)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (5,5, 5)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (6,5, 6)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (7,5, 32)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (8,5, 33)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (9,1, 7)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (10,1, 8)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (11,1, 9)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (12,1, 10)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (13,1, 11)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (14,2, 12)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (15,2, 13)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (16,2, 14)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (17,2, 15)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (18,3, 16)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (19,3, 17)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (20,3, 18)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (21,6, 20)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (22,6, 21)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (23,6, 22)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (24,6, 23)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (25,6, 24)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (26,6, 25)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (27,6, 26)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (28,6, 27)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (29,6, 28)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (30,6, 29)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (31,6, 30)
INSERT INTO [dbo].[MediaItem] ([ID], [AlbumID], [MediaID]) VALUES (32,6, 31)

INSERT INTO [dbo].[Members] ([ID] , [UserID], [AlbumID]) VALUES (1,2, 1)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (2,2, 2)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (3,3, 3)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (4,2, 5)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (5,3, 1)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (6,3, 2)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (7,3, 7)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (8,3, 5)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (9,4, 3)
INSERT INTO [dbo].[Members] ([ID], [UserID], [AlbumID]) VALUES (10,2, 4)





Go


GO