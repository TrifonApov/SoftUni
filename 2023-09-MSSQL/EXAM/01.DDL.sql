USE master
GO

CREATE DATABASE TouristAgency

USE TouristAgency
GO

CREATE TABLE Countries (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	CountryId INT NOT NULL,
	CONSTRAINT FK_Destinations_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Rooms (
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(40) NOT NULL,
	Price Decimal(18,2) NOT NULL,
	BedCount INT NOT NULL,
	CHECK (BedCount > 0 AND BedCount <=10)
)

CREATE TABLE Hotels (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DestinationId INT NOT NULL,
	CONSTRAINT FK_Hotels_Destination FOREIGN KEY (DestinationId) REFERENCES Destinations(Id)
)

CREATE TABLE Tourists (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	Email NVARCHAR(80),
	CountryId INT NOT NULL,
	CONSTRAINT FK_Toursists_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Bookings (
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL,
	ChildrenCount INT NOT NULL,
	TouristId INT NOT NULL,
	HotelId INT NOT NULL,
	RoomId INT NOT NULL,

	CHECK (AdultsCount >= 1 AND AdultsCount <=10),
	CHECK (ChildrenCount >= 0 AND AdultsCount <=9),
	CONSTRAINT FK_Bookings_Tourists FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
	CONSTRAINT FK_Bookings_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
	CONSTRAINT FK_Bookings_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms (
	HotelId INT NOT NULL,
	RoomId INT NOT NULL,
	CONSTRAINT PK_HotelsRooms PRIMARY KEY(HotelId, RoomId),
	CONSTRAINT FK_HotelsRooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels (Id),
	CONSTRAINT FK_HotelsRooms_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms (Id)
)