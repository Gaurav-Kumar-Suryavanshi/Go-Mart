use GoMartDB;

create table tbAdmin(
AdminID nvarchar(50),
[Password] nvarchar(50),
FullName nvarchar(50)
);
select * from tbAdmin;

select top 1 AdminID,Password,FullName from tbAdmin where AdminID=@AdminID and Password=@Password

create table tblSeller
(
SellerID int identity(1,1) primary key,
SellerName nvarchar(50) Unique,
SellerAge int,
SellerPhone nvarchar(10),
SellerPass nvarchar(50)
);

select * from tblSeller

select top 1 SellerName,SellerPass from tblSeller where SellerName=@SellerName and SellerPass=@SellerPass


create table tblCategory
(
CatID int identity(1,1) primary key not null,
CategoryName nvarchar(50),
CategoryDesc nvarchar(50)
)

select * from tblCategory

insert into tblCategory (CategoryName,CategoryDesc) values(@CategoryName,@CategoryDesc)

create procedure spCatInsert
(
@CategoryName nvarchar(50),
@CategoryDesc nvarchar(50)
)
as
begin
insert into tblCategory (CategoryName,CategoryDesc) values(@CategoryName,@CategoryDesc)
end

----
select CategoryName from tblCategory where CategoryName=@CategoryName

select  CatID as CategoryID,CategoryName,CategoryDesc as CategoryDescription from tblCategory

-----

create procedure spCatUpdate
(
@CatID int,
@CategoryName nvarchar(50),
@CategoryDesc nvarchar(50)
)
as
begin
update tblCategory set CategoryName=@CategoryName,CategoryDesc=@CategoryDesc where CatID=@CatID
end

----

create procedure spCatDelete
(
@CatID int 
)
as
begin
Delete from tblCategory where CatID=@CatID
end

----
select * from tblSeller
