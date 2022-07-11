--DataBase Created
create database Fundonote_adonet
--Using the DataBase
use Fundonote_adonet

--Creating table Users in Fundonotes DataBase
create table Users(
UserId int identity(1,1) primary key,
Firstname varchar(50),
Lastname varchar(50),
Email varchar(50) unique,
Password varchar(255),
CreatedDate datetime default getdate(),
ModifiedDate datetime default getdate()
)
insert into Users(Firstname,Lastname,Email,Password) values('Mistu','Megha','meghamistu@gmail.com','Megha@201')
select * from Users

drop table Users



--Created Stored Procedure
create procedure spAddUser(
@Firstname varchar(50), 
@Lastname varchar(50),
@Email varchar(50),
@password varchar(100)
)
As
Begin try
insert into Users(Firstname,Lastname,Email,password) values(@Firstname,@Lastname,@Email,@password)
--select * from Users where Email=@Email
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH



--executing the spAddUser stored procedure
exec spAddUser 'Shambhu','kumar','shambhu@gmail.com','Shumbhu@123'
--to get all records from table
select * from Users


--Created Stored Procedure to get all records
create procedure spGetAllUser
As
Begin try
select * from Users
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--Executing the spGetAllUser stored procedure
exec spGetAllUser
--to get all records from table
select * from Users
