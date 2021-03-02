create table _User(
UserID int primary key identity(1, 1),
FullName nvarchar(50),
Username nvarchar(50) unique,
Email varchar(50) unique,
Password nvarchar(50),
UserType varchar(6), 
Charge float(2));

insert into _User values('Test', 'a', 'testa@gmail.com', 'a', 'Admin', 500); 
insert into _User values('Test', 'u', 'testu@gmail.com', 'u', 'User', 1567); 



create table Product(
ProdID int primary key identity(1, 1),
ProdName nvarchar(30) unique,
Type nvarchar(30),
Origin nvarchar(30),
Mass nvarchar(30),
Length nvarchar(30),
Caliber nvarchar(30),
Diameter nvarchar(30),
Filling nvarchar(30),
Quantity int,
Price float(2));



create table Sale(
SaleID int primary key identity(1, 1),
UserId int foreign key references _User(UserID) on delete cascade on update cascade,
ProdId int foreign key references Product(ProdID) on delete cascade on update cascade,
SoldPrice float(2),
Quantity int,
SoldDate date);



select * from _User;
select * from Product;
select * from Sale;



--con : Data Source=LAPTOP-I7DVMHCL\SQLSERVER2019;Initial Catalog=Hezbollah;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

--Server Location : SELECT * FROM sys.database_files;