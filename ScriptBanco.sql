CREATE TABLE "PurchaseHistory" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"IDClient"	INTEGER NOT NULL,
	"IDProduct"	INTEGER NOT NULL,
	"Quantities"	INTEGER NOT NULL,
	"PurchaseValue"	NUMERIC NOT NULL,
	"PurchaseDate"	DATE NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("IDClient") REFERENCES "Client"("ID")
);

CREATE TABLE "Client" ( 
	"ID" INTEGER NOT NULL UNIQUE, 
	"ClientName" TEXT NOT NULL, 
	"Balance" NUMERIC NOT NULL, 
	"Active" INTEGER NOT NULL, 
	PRIMARY KEY("ID" AUTOINCREMENT) 
);

CREATE TABLE "Category" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"NameCategory"	TEXT NOT NULL,
	"Active"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "Product" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"ProductName"	TEXT NOT NULL,
	"IDCategory"	INTEGER NOT NULL,
	"DueDate"	DATE NOT NULL,
	"Value"	NUMERIC NOT NULL,
	"Amount"	NUMERIC NOT NULL,
	"RegistrationDate"	DATE NOT NULL,
	"Active"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("IDCategory") REFERENCES "Category"("ID")
);

CREATE TABLE "Fees" ( 
	"ID" INTEGER NOT NULL UNIQUE, 
	"InitialValue" NUMERIC NOT NULL, 
	"FinalValue" INTEGER NOT NULL, 
	"Percentage" NUMERIC NOT NULL, 
	"RegistrationDate" DATE NOT NULL, 
	"Active" INTEGER NOT NULL, 
	PRIMARY KEY("ID" AUTOINCREMENT) 
);

CREATE TABLE "Login" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"LoginUser"	TEXT NOT NULL,
	"Password"	TEXT NOT NULL,
	"IDClient"	INTEGER,
	"RegistrationDate"	DATE NOT NULL,
	"Active"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);

CREATE TABLE "SecurityPass" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Pass"	TEXT NOT NULL,
	"Active"	TEXT NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);



-- inserts categorys

INSERT INTO Category (NameCategory, Active) VALUES ('Eletrônicos', 1);

INSERT INTO Category (NameCategory, Active) VALUES ('Automotivo', 1);

INSERT INTO Category (NameCategory, Active) VALUES ('Consumos', 1);


-- insert Login

INSERT INTO Login ("LoginUser", "Password", "IDClient", "RegistrationDate", "Active") 
VALUES ('adm', 'senhaAdm', NULL, CURRENT_DATE, 1);

INSERT INTO Login ("LoginUser", "Password", "IDClient", "RegistrationDate", "Active") 
VALUES ('Client1', '0000', 1, CURRENT_DATE, 1);

-- insert Client
INSERT INTO Client (ClientName, Balance, Active) VALUES ('Cliente 1', 100000.0, 1);


-- insert Product
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('IPHONE 15', 1, '2024-12-31', 5000.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('IPHONE 13', 1, '2024-08-31', 3000.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('IPHONE 14', 1, '2024-07-31', 4000.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('IPHONE 12', 1, '2024-02-31', 2000.0, 1000, CURRENT_DATE, 1);

INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Arrefecimento', 2, '2024-12-31', 50.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Oléo', 2, '2024-08-31', 30.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Fluido de freio', 2, '2024-07-31', 20.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Aditivo', 2, '2024-02-31', 10.0, 1000, CURRENT_DATE, 1);

INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Vinho', 3, '2024-12-31', 50.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Uísque', 3, '2024-08-31', 150.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Energetico', 3, '2024-07-31', 15.0, 1000, CURRENT_DATE, 1);
INSERT INTO Product (ProductName, IDCategory, DueDate, Value, Amount, RegistrationDate, Active)
VALUES ('Refrigerante', 3, '2024-02-31', 10.0, 1000, CURRENT_DATE, 1);






