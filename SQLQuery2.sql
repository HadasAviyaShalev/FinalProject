create database HealthyMenu
go 
use HealthyMenu

create table statuses(
	id int primary key identity(1,1),
	age varchar(20),
	description varchar(50)
)

create table Users(
	id int identity(1,1) primary key,
	userId varchar(9) unique not null,
	firstName varchar(255),
	lastName varchar(255),
	email varchar(255),
	userPassword varchar(10),
	bornDate date,
	phone varchar(10),
	statusCode int foreign key references statuses(id),
	myWeight float,
	height float,
	vegetarian bit,
	vegan bit
)

create table UnitsOfMeasurement(
	id int identity(1,1) primary key,
	unitName varchar(255),
	ratioToGram float,
)

create table ageDimensions(
	id int identity(1,1) primary key,
	statusCode int foreign key references statuses(id),
	UnitsOfMeasurementCode int foreign key references UnitsOfMeasurement(id),
	RecommendedDose float,
	MaxDose float,
	highMissing float
)

create table ingredients(
	id int identity(1,1) not null primary key,
	CDescription varchar(225),
	RecommendedDoseMale float,
	RecommendedDoseFemale float,
	UnitCode int foreign key references UnitsOfMeasurement(id)
)
create table userNutrition(
	id int primary key identity(1,1),
	userId int foreign key references Users(id) ,
	inserDate datetime,
	yourName varchar(50)
)
create table suitableTo(
	id int primary key identity(1,1),
	statusDescription varchar(255)
)

create table menu(
		id int primary key identity(1,1),
		userNutritionCode int foreign key references userNutrition(id),
		foodCode int foreign key references Food(id),
		amount float,
		suitableToId int foreign key references suitableTo(id)
		)




create table Food(
	id int primary key identity(1,1),
	foodName varchar(50),
	picture varchar(255),
	suitableToID int foreign key references suitableTo(id),
	cosher varchar(25),
	category varchar(25)
)
create table ingredientsInPro(
	id int primary key identity(1,1),
	foodID int foreign key references Food(id),
	ingredientsId int foreign key references ingredients(id),
	countFor100gr float 
)
create table foodToMeal(
	id int primary key identity(1,1),
	foodCode int foreign key references Food(id),
	suitableToId int foreign key references suitableTo(id)
)



