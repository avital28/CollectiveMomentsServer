Use master

Create Database CollectiveMomentsDB

Go

Use CollectiveMomentsDB

Go

Create Table Users (

ID int Identity primary key,

Email nvarchar(100) not null,

FirstName nvarchar(30) not null,

LastName nvarchar(30) not null,

Passwrd nvarchar(30) not null,

UserName nvarchar(30) not null,

Birthday datetime not null,


CONSTRAINT UC_Email UNIQUE(Email)

)

Go


GO