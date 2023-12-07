
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

Birthday DATE,


CONSTRAINT UC_Email UNIQUE(Email)

)

Go


GO