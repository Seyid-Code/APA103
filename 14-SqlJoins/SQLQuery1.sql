create database Company;
use Company;

create table Countries (
    Id int primary key identity,
    Name nvarchar(50)
)

create table Cities (
    Id int primary key identity,
    Name nvarchar(50),
    CountryId int,
    foreign key (CountryId) references Countries(Id)
)

create table Employees (
    Id int primary key identity,
    Name nvarchar(50),
    Surname nvarchar(50),
    Age int,
    Salary decimal(10,2),
    Position nvarchar(50),
    IsDeleted bit,
    CityId int,
    CountryId int,
    foreign key (CityId) references Cities(Id),
    foreign key (CountryId) references Countries(Id)
)
insert into Countries (Name)
values 
('Azerbaijan'),
('Turkey'),
('Germany')

insert into Cities (Name, CountryId)
values
('Baku', 1),
('Ganja', 1),
('Istanbul', 2),
('Ankara', 2),
('Berlin', 3);

insert into Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId, CountryId)
values
('Ali', 'Aliyev', 25, 2500, 'Developer', 0, 1, 1),
('Leyla', 'Hasanova', 29, 3200, 'Manager', 0, 2, 1),
('Murad', 'Huseynov', 32, 1800, 'Reseption', 0, 3, 2),
('Aysel', 'Mammadova', 26, 2100, 'Designer', 1, 4, 2),
('John', 'Smith', 35, 4000, 'CEO', 0, 5, 3)


select e.Name, e.Surname, c.Name AS City, co.Name AS Country from Employees e
join Cities c on e.CityId = c.Id
join Countries co on e.CountryId = co.Id

select e.Name, co.Name AS Country from Employees e
join Countries co on e.CountryId = co.Id
where e.Salary > 2000

select c.Name AS City, co.Name AS Country from Cities c
join Countries co on c.CountryId = co.Id

select Name, Surname, Age, Salary, Position, IsDeleted, CityId, CountryId from Employees
where Position = 'Reseption'

select e.Name, e.Surname, c.Name AS City, co.Name AS Country from Employees e
join Cities c on e.CityId = c.Id
join Countries co on e.CountryId = co.Id
where e.IsDeleted = 1