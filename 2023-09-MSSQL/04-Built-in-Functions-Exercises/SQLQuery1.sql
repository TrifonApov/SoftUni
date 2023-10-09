--USE SoftUni
--GO

-- PROBLEM 01
--SELECT FirstName, LastName FROM Employees
--WHERE LEFT(FirstName,2) = 'Sa'

-- PROBLEM 02
--SELECT FirstName, LastName FROM Employees
--WHERE LastName LIKE '%ei%'

-- PROBLEM 03
--SELECT FirstName FROM Employees
--WHERE HireDate BETWEEN '1995-01-01' AND '2005-12-31'
--	AND DepartmentID = 3 OR DepartmentID = 10

-- PROBLEM 04
--SELECT FirstName, LastName FROM Employees
--WHERE JobTitle NOT LIKE '%engineer%'

-- PROBLEM 05
--SELECT [Name] FROM Towns
--WHERE LEN([Name]) BETWEEN 5 AND 6
--ORDER BY [Name]

-- PROBLEM 06
--SELECT * FROM Towns
--WHERE [Name] LIKE 'M%' OR
--	  [Name] LIKE 'K%' OR 
--	  [Name] LIKE 'B%' OR 
--	  [Name] LIKE 'E%' 
--ORDER BY [Name]

-- PROBLEM 07
--SELECT * FROM Towns
--WHERE [Name] NOT LIKE 'R%' AND
--	  [Name] NOT LIKE 'B%' AND
--	  [Name] NOT LIKE 'D%' 
--ORDER BY [Name]

-- PROBLEM 08
--CREATE VIEW V_EmployeesHiredAfter2000 AS
--SELECT FirstName, LastName
--FROM Employees
--WHERE HireDate > '2000-12-31'

--SELECT * FROM V_EmployeesHiredAfter2000

-- PROBLEM 09
--SELECT FirstName, LastName FROM Employees
--WHERE LEN(LastName) = 5

-- PROBLEM 10
--SELECT 
--	EmployeeID,
--	FirstName,
--	LastName,
--	Salary,
--	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID ) AS [Rank] FROM Employees
--WHERE Salary BETWEEN 10000 AND 50000 
--ORDER BY Salary DESC

-- PROBLEM 11
--SELECT * FROM (SELECT 
--	EmployeeID,
--	FirstName,
--	LastName,
--	Salary,
--	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID ) AS [Rank] FROM Employees
--) AS viewrank
--WHERE Salary BETWEEN 10000 AND 50000 AND viewrank.[Rank] = 2
--ORDER BY Salary DESC


-- PROBLEM 12
--SELECT CountryName, IsoCode FROM Countries
--WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
--ORDER BY IsoCode

-- PROBLEM 13
--SELECT p.PeakName, 
--	   r.RiverName, 
--	   CONCAT(LOWER(LEFT(p.PeakName, LEN(p.PeakName) - 1)), LOWER(r.RiverName)) AS Mix 
--FROM Peaks AS p 
--JOIN 
--	Rivers AS r 
--ON RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
--ORDER BY Mix


USE Diablo
GO
-- PROBLEM 14
--SELECT TOP 50 [Name], CONVERT(VARCHAR(10), Start, 21) AS Start FROM Games
--WHERE Start BETWEEN '2011-01-01' AND '2012-12-31'
--ORDER BY Start, [Name]

-- PROBLEM 15
--SELECT 
--	Username,
--	SUBSTRING (Email, CHARINDEX( '@', Email) + 1, LEN(Email)) AS 'Email Provider' 
--FROM Users
--ORDER BY 'Email Provider', Username

-- PROBLEM 16
--SELECT Username, IpAddress FROM Users
--WHERE IpAddress LIKE '___.1%.%.___'
--ORDER BY Username

-- PROBLEM 17
se

SELECT 
	[Name] AS 'Game',
	
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Morning'
		ELSE 'Evening'
	END AS 'Part of the Day',

	CASE
		WHEN 
FROM Games
ORDER BY 'Game'
-- PROBLEM 18
