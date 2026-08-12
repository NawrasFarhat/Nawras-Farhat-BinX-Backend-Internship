CREATE DATABASE OrderManagementDB;

USE OrderManagementDB;

CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Orders
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Total DECIMAL(18,2) NOT NULL,
    CustomerId INT NOT NULL,

    CONSTRAINT FK_Order_Customers
        FOREIGN KEY (CustomerId)
        REFERENCES Customers(Id)
);