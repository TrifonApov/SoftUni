-- 03-Table-Relations-Exercises

--USE [Table-Relation-Exercises]
--GO

-- Problem 01
--CREATE TABLE Passports(
--	PassportID INT PRIMARY KEY,
--	PassportNumber CHAR(8))

--CREATE TABLE Persons(
--	PersonID INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(30) NOT NULL,
--	Salary DECIMAL(7, 2),
--	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID));

--INSERT INTO [Passports]([PassportID], [PassportNumber]) VALUES
--(101, 'N34FG21B'),
--(102, 'K65LO4R7'),
--(103, 'ZE657QP2')

--INSERT INTO [Persons]([FirstName], [Salary], [PassportID]) VALUES
--('Roberto', 43300.00, 102),
--('Tom', 56100.00, 103),
--('Yana', 60200.00, 101)

--SELECT * FROM Persons
--SELECT * FROM Passports

--PROBLEM 2

--CREATE TABLE Manufacturers(
--	ManufacturerID INT PRIMARY KEY,
--	[Name] CHAR(8),
--	EstablishedOn DATE)

--CREATE TABLE Models(
--	ModelID INT PRIMARY KEY,
--	[Name] CHAR(8),
--	ManufacturerID INT 
--	CONSTRAINT FK_Peaks_Mountains
--	FOREIGN KEY (ManufacturerID)
--	REFERENCES Manufacturers(ManufacturerID))

--INSERT INTO Manufacturers (ManufacturerID, [Name], EstablishedOn) 
--VALUES 
--	(1,'BMW','07/03/1916'),
--	(2,'Tesla','01/01/2003'),
--	(3,'Lada','01/05/1966')

--INSERT INTO Models (ModelID, [Name], ManufacturerID) 
--VALUES
--	(101,'X1', 1),
--	(102,'i6', 1),
--	(103,'Model S', 1),
--	(104,'Model X', 1),
--	(105,'Model 3', 1),
--	(106,'Nova', 1)

--SELECT mo.[Name], ma.[Name], ma.EstablishedOn FROM Models AS mo 
--JOIN Manufacturers AS ma
--ON mo.ManufacturerID = ma.ManufacturerID

--PROBLEM 3

--CREATE TABLE Students (
--	StudentID INT PRIMARY KEY,
--	[Name] CHAR(5))

--CREATE TABLE Exams (
--	ExamID INT PRIMARY KEY,
--	[Name] CHAR(10))


--CREATE TABLE StudentsExams (
--	StudentID INT CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
--	ExamID INT CONSTRAINT FK_Exam FOREIGN KEY (ExamID) REFERENCES Exams (ExamID),
--	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID))


--INSERT INTO Students (StudentID, [Name])
--VALUES 
--	(1, 'Mila'),
--	(2, 'Toni'),
--	(3, 'Ron')

--INSERT INTO Exams (ExamID, [Name])
--VALUES
--	(101, 'SpringMVC'),
--	(102, 'Neo4j'),
--	(103, 'Oracle 11g')

--INSERT INTO StudentsExams (StudentID, ExamID)
--VALUES
--	( 1,101),
--	( 1,102),
--	( 2,101),
--	( 3,103),
--	( 2,102),
--	( 2,103)



-- PROBLEM 4

--CREATE TABLE Teachers (
--	TeacherID INT PRIMARY KEY,
--	[Name] NVARCHAR(30),
--	ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID))

--INSERT INTO Teachers (TeacherID, [Name], ManagerID)
--VALUES
--	(101, 'John', NULL),
--	(102, 'Maya', 106),
--	(103, 'Silvia', 106),
--	(104, 'Ted', 105),
--	(105, 'Mark', 101),
--	(106, 'Greta', 101)

-- PROBLEM 5

--CREATE TABLE Cities (
--	CityID INT PRIMARY KEY,
--	[Name] NVARCHAR(30))

--CREATE TABLE Customers (
--	CustomerID INT PRIMARY KEY,
--	[Name] NVARCHAR(30),
--	Birthday DATE,
--	CityID INT FOREIGN KEY REFERENCES Cities (CityID))

--CREATE TABLE Orders (
--	OrderID INT PRIMARY KEY,
--	CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID))

--CREATE TABLE ItemTypes (
--	ItemTypeID INT PRIMARY KEY,
--	[Name] NVARCHAR(30))

--CREATE TABLE Items (
--	ItemID INT PRIMARY KEY,
--	[Name] NVARCHAR (30),
--	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes (ItemTypeID))

--CREATE TABLE OrderItems (
--	OrderID INT CONSTRAINT FK_Order FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
--	ItemID INT CONSTRAINT FK_Item FOREIGN KEY (ItemID) REFERENCES Items (ItemID),
--	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID))




--	StudentID INT CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
--	ExamID INT CONSTRAINT FK_Exam FOREIGN KEY (ExamID) REFERENCES Exams (ExamID),
--	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID))

-- PROBLEM 6
--CREATE DATABASE UniversityDB
--GO
--USE UniversityDB
--GO

--CREATE TABLE Subjects (
--	SubjectID INT PRIMARY KEY,
--	SubjectName NVARCHAR (30))

--CREATE TABLE Majors (
--	MajorID INT PRIMARY KEY,
--	[Name] NVARCHAR (30))

--CREATE TABLE Students (
--	StudentID INT PRIMARY KEY,
--	StudentNumber INT,
--	StudentName NVARCHAR(30),
--	MajorID INT FOREIGN KEY REFERENCES Majors (MajorID))

--CREATE TABLE Payments (
--	PaymentID INT PRIMARY KEY,
--	PaymentDate DATE,
--	PaymentAmount DECIMAL,
--	StudentID INT FOREIGN KEY REFERENCES Students (StudentID))

--CREATE TABLE Agenda (
--	StudentID INT FOREIGN KEY REFERENCES Students (StudentID),
--	SubjectID INT FOREIGN KEY REFERENCES Subjects (SubjectID),
--	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID))

-- PROBLEM 9
--USE Geography
--GO

--SELECT m.MountainRange, p.PeakName, p.Elevation FROM Peaks as p
--JOIN Mountains as m ON p.MountainId = m.Id
--WHERE m.MountainRange = 'Rila'
--ORDER BY p.Elevation DESC
