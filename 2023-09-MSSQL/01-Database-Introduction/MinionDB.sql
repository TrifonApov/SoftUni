--USE master
--GO

--CREATE DATABASE Minions;
--USE [Minions]
--CREATE TABLE [dbo].[Minions] (
--    Id INT NOT NULL,
--    [Name] NVARCHAR(255) NOT NULL,
--    Age INT,
--    PRIMARY KEY (Id)
--);

--CREATE TABLE [dbo].[Towns] (
--	Id INT NOT NULL,
--	[Name] NVARCHAR NOT NULL,
--	PRIMARY KEY (Id)
--);

--ALTER TABLE [Minions]
--    ADD TownId INT,
--    FOREIGN KEY(TownId) REFERENCES Towns(Id);

