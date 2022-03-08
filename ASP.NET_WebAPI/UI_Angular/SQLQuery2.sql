create table dbo.Department(
DepartmentId int identity(1,1),
DepartmentName varchar(500)
)

select * from dbo.Department

insert into dbo.Department values
('HR')