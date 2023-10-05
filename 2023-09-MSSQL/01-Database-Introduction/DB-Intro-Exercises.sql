--USE master
--GO

--CREATE DATABASE Minions

--USE Minions
--GO

--CREATE TABLE Minions (
--	Id INT NOT NULL,
--	[Name] VARCHAR NOT NULL,
--	Age INT
--)

--CREATE TABLE Towns (
--	Id INT NOT NULL,
--	[Name] VARCHAR NOT NULL
--)

--ALTER TABLE Minions
--ADD PRIMARY KEY (Id);

--ALTER TABLE Towns
--ADD PRIMARY KEY (Id);

--ALTER TABLE Minions
--ADD TownId INT

--ALTER TABLE Minions
--ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)
--USE Minions
--GO

--INSERT INTO Minions (Id, [Name], Age, TownId)
--VALUES 
--	(1, 'Kevin', 22, 1),
--	(2, 'Bob', 15, 3),
--	(3, 'Steward', null , 2);
	
--INSERT INTO Towns (Id, [Name])
--VALUES
--	(1, 'Sofia'),
--	(2, 'Plovdiv'),
--	(3, 'Varva');

--TRUNCATE TABLE Minions;
--SELECT * FROM Minions

--DELETE FROM Towns;
--SELECT * FROM Towns;

--DROP TABLE Minions
--DROP TABLE Towns


USE master

