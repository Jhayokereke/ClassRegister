create database DatabaseDemo

alter database DatabaseDemo modify Name = TheBulbDB

use TheBulbDB
go

create table tblDotnetClass
(
Id nvarchar(17) not null primary key,
Firstname nvarchar(50) not null,
Middlename nvarchar(50) not null,
Lastname nvarchar(50) not null,
GenderId int not null,
StateId int not null
)

drop table tblDotnetClass

use TheBulbDB
select * from dbo.tblDotnetClass

insert into tblDotnetClass values ( '54rk-bde4', 'Chinazo', 'Ifedika', 'Olisa', 2, 5)
insert into tblDotnetClass values ( '54rk-bdz5', 'Ifunnanya', 'Williams', 'Onah', 1, 3)
insert into tblDotnetClass values ( '54rk-bda8', 'Uzor', 'Romanus', 'Nwachukwu', 1, 6)
insert into tblDotnetClass values ( '54rk-bdc9', 'Henry', 'Ekene', 'Iwekuba', 1, 6)
insert into tblDotnetClass values ( '54rk-bdd7', 'Emeka', 'Chidubem', 'Ewelike', 1, 4)
insert into tblDotnetClass values ( '54rk-bda2', 'Raphael', 'Chidiebere', 'Isaac', 1, 2)
insert into tblDotnetClass values ( '54rk-bdf1', 'Philip', 'Newman', 'Amadi', 1, 7)
insert into tblDotnetClass values ( '54rk-bdp0', 'Chukwuemeka', 'John', 'Okereke', 1, 2)

alter table tblDotnetClass
add constraint tblDotnetClass_GenderId_default
default 3 for GenderId

delete from tblDotnetClass where Firstname = 'Chukwuemeka'


create table tblGender
(
Id int not null primary key,
Gender nvarchar(20)
)

select * from tblGender

delete from tblGender where Id = 5

insert into tblGender(Id, Gender) values (1, 'Male')
insert into tblGender values (2, 'female')
insert into tblGender values (3, 'Other')
insert into tblGender values (7, 'Trans-Male')
insert into tblGender values (6, 'Trans-Female')

update tblGender
set Gender = 'Female'
where Gender = 'female'





CREATE TABLE tblState
(
Id INT NOT NULL identity(1,1) PRIMARY KEY,
[Name] NVARCHAR(25) NOT NULL,
Capital NVARCHAR(25) NOT NULL unique,
Region NVARCHAR(25) NOT NULL
)


create procedure sptblDotnetClass_FetchAll
as
select * from tblState
go

exec sptblDotnetClass_FetchAll
execute sptblDotnetClass_FetchAll
sptblDotnetClass_FetchAll


drop table tblState

INSERT INTO tblState values ('Ebonyi', 'Uburu', 'South-East')
INSERT INTO tblState values ('Abia', 'Umuahia', 'South-East')
INSERT INTO tblState values ('Enugu', 'Enugu', 'South-East')
INSERT INTO tblState values ('Imo', 'Owerri', 'South-East')
INSERT INTO tblState values ('Anambra', 'Awka', 'South-East')
INSERT INTO tblState values ('Delta', 'Asaba', 'South-South')
INSERT INTO tblState values ('Lagos', 'Ikeja', 'South-West')
INSERT INTO tblState values ('Osun', 'Osogbo', 'South-West')
INSERT INTO tblState values ('Plateau', 'Jos', 'North-Central')
INSERT INTO tblState values ('Kwara', 'Ilorin', 'North-Central')
INSERT INTO tblState values ('Kaduna', 'Kaduna', 'North-West')
INSERT INTO tblState values ('Borno', 'Maiduguri', 'North-East')
INSERT INTO tblState values ('Bayelsa', 'Yenogoa', 'South-South')
INSERT INTO tblState values ('Rivers', 'Port-Harcourt', 'South-South')
INSERT INTO tblState values ('Sokoto', 'Sokoto', 'North-West')
INSERT INTO tblState values ('Taraba', 'Jalingo', 'North-East')

alter table tblState
Add constraint unique_name 
unique([Name])

delete from tblState
where Capital = 'Uburu'

drop table tblDotnetClass

alter table tblDotnetClass
add constraint tblDotnetClass_GenderId_FK
foreign key (GenderId) references tblGender (Id)

alter table tblDotnetClass
add constraint tblDotnetClass_StateId_FK
foreign key (StateId) references tblState (Id)

create procedure sptblDotnetClass_FetchAllLike @Key nvarchar(max)
as
select * from tblDotnetClass where Firstname like @Key
go

drop procedure sptblDotnetClass_FetchAllLike

sptblDotnetClass_FetchAllLike @Key = '%vd%''; delete from tblGender where Id = 6--'


create procedure spFellowWithState
as 
select tblDotnetClass.Id, Firstname, Middlename, Lastname, Gender, tblState.Id as StateId, [Name], Capital, Region  
from tblDotnetClass
join tblState on StateId = tblState.Id
join tblGender on GenderId = tblGender.Id
go

create view vwFellowWithState
as 
select tblDotnetClass.Id, Firstname, Middlename, Lastname, Gender, StateId, [Name], Capital, Region  
from tblDotnetClass
join tblState on StateId = tblState.Id
join tblGender on GenderId = tblGender.Id
go

update tblDotnetClass
set Middlename = 'Alfred'
where Id = '54rk-bda8'

update tblDotnetClass
set StateId = 5
where Id = '54rk-bdf1'

sp_helptext vwFellowWithState