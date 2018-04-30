create database CodingChallenge;

create schema Inventory;

create table Inventory.Product
(
	[id] int primary key identity,
	[name] nvarchar(50) not null,
	price decimal(6,2) not null
)

create table Inventory.Customer
(
	[id] int primary key identity,
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
	cardNumber nvarchar(16) not null
)

create table Inventory.[Order]
(
	[id] int primary key identity,
	productid int foreign key references Inventory.Product(id),
	customerid int foreign key references Inventory.Customer(id)
)

insert into Inventory.Product ([name], price) values ('iPhone', 200);
insert into Inventory.Product ([name], price) values ('PS4', 300);
insert into Inventory.Product ([name], price) values ('Macbook', 1000);

insert into Inventory.Customer (firstName, lastName, cardNumber) values ('Tina', 'Smith', 1234567812345678);
insert into Inventory.Customer (firstName, lastName, cardNumber) values ('Tony', 'Smith', 2234567812345678);
insert into Inventory.Customer (firstName, lastName, cardNumber) values ('Tom', 'Smith', 3234567812345678);

insert into Inventory.[Order] (productid, customerid) values (1, 1);
insert into Inventory.[Order] (productid, customerid) values (1, 2);
insert into Inventory.[Order] (productid, customerid) values (2, 1);

SELECT Inventory.Customer.firstName, Inventory.Customer.lastName, Inventory.Product.[name]
FROM Inventory.Customer
INNER JOIN Inventory.[Order] ON Inventory.Customer.id = Inventory.[Order].customerid
INNER JOIN Inventory.Product ON Inventory.[Order].productid = Inventory.Product.id
where firstName = 'Tina' and lastName = 'Smith'

SELECT Sum(Inventory.Product.price)
FROM Inventory.Customer
INNER JOIN Inventory.[Order] ON Inventory.Customer.id = Inventory.[Order].customerid
INNER JOIN Inventory.Product ON Inventory.[Order].productid = Inventory.Product.id
where Inventory.Product.name='iPhone'

UPDATE Inventory.Product
SET price = 250
WHERE [name] = 'iPhone';

