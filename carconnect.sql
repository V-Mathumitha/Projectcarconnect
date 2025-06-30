create database carconnect;
use carconnect;
CREATE TABLE Customer (CustomerID INT PRIMARY KEY, FirstName VARCHAR(100),LastName VARCHAR(100),Email VARCHAR(150),PhoneNumber VARCHAR(20),Address TEXT,
    Username VARCHAR(100) NOT NULL UNIQUE,Password VARCHAR(255) NOT NULL,RegistrationDate DATE);
CREATE TABLE Vehicle ( VehicleID INT PRIMARY KEY,Model VARCHAR(100),Make VARCHAR(100),VehicleYear INT,Color VARCHAR(50),RegistrationNumber VARCHAR(50) UNIQUE,
    Availability TINYINT,DailyRate DECIMAL(10,2));
CREATE TABLE Reservation (ReservationID INT PRIMARY KEY,CustomerID INT,VehicleID INT,StartDate DATE,EndDate DATE,TotalCost DECIMAL(10,2),
    Status VARCHAR(50),FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID));
CREATE TABLE AdminTable (AdminID INT PRIMARY KEY,FirstName VARCHAR(100),LastName VARCHAR(100),Email VARCHAR(100),PhoneNumber VARCHAR(20),Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,Role VARCHAR(100),JoinDate DATE);
INSERT INTO Customer(CustomerID, FirstName, LastName, Email, PhoneNumber, Address, Username, Password, RegistrationDate)
VALUES (3, 'anu', 'abi', 'aa@example.com', '1234567890', '123 Main St', 'anuabi', 'password123', GETDATE());
select * from Customer;
INSERT INTO AdminTable 
(AdminID, FirstName, LastName, Email, PhoneNumber, Username, Password, Role, JoinDate)
VALUES 
(2, 'sush', 'mitha', 'sushmitha@example.com', '9876543210', 'sushmitha', 'admin456', 'Manager', GETDATE());
select * from AdminTable;
INSERT INTO Vehicle 
(VehicleID, Model, Make, VehicleYear, Color, RegistrationNumber, Availability, DailyRate)
VALUES 
(1, 'Swift', 'Maruti', 2022, 'Red', 'TN01AB1234', 1, 1500.00);
select * from Vehicle;
select * from Reservation;
INSERT INTO Reservation (ReservationID, CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status)
VALUES 
(1, 1, 1, '2025-07-01', '2025-07-05', 5000.00, 'Booked');
SELECT * FROM Customer WHERE UserName ='wronguser';




