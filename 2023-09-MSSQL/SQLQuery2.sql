--USE SoftUni
--GO
----Problem 02
--SELECT * FROM Departments

----Problem 03
--SELECT [Name] FROM Departments

----Problem 04

--SELECT FirstName, LastName, Salary FROM Employees

----Problem 05
--SELECT FirstName, MiddleName, LastName FROM Employees

----Problem 06
--SELECT CONCAT(e.FirstName, '.',e.LastName, '@softuni.bg') AS 'Full Email Address' FROM Employees AS e

----Problem 07
--SELECT DISTINCT Salary FROM Employees

----Problem 08
--SELECT * FROM Employees AS e
--	WHERE e.JobTitle = 'Sales Representative'

----Problem 09
--SELECT e.FirstName, e.LastName, e.JobTitle FROM Employees AS e
--	WHERE e.Salary >= 20000 AND e.Salary <= 30000

----Problem 10
--SELECT CONCAT(e.FirstName, ' ', e.MiddleName, ' ', e.LastName) AS 'Full Name' 
--	FROM Employees AS e
--	WHERE e.Salary = 25000 OR e.Salary = 14000 OR e.Salary = 12500 OR e.Salary = 23600

----Problem 11
--SELECT e.FirstName, e.LastName FROM Employees AS e
--	WHERE e.ManagerID IS NULL

----Problem 12
--SELECT e.FirstName, e.LastName, e.Salary
--	FROM Employees AS e
--	WHERE e.Salary > 50000
--	ORDER BY e.Salary DESC


----Problem 13
--SELECT TOP 5 e.FirstName, e.LastName
--	FROM Employees AS e
--	ORDER BY e.Salary DESC

----Problem 14
--SELECT e.FirstName, e.LastName
--	FROM Employees AS e
--	WHERE e.DepartmentID != 4

----Problem 15
--SELECT * FROM Employees AS e
--	ORDER BY e.Salary DESC, e.FirstName, e.LastName DESC

----Problem 16
--CREATE VIEW V_EmployeesSalaries
--AS
--SELECT e.FirstName, e.LastName, e.Salary FROM Employees AS e

----Problem 17
--CREATE VIEW V_EmployeeNameJobTitle
--AS
--SELECT CONCAT(e.FirstName, ' ',COALESCE(e.MiddleName, ''), ' ', e.LastName) AS 'Full Name', e.JobTitle 
--	FROM Employees AS e

--SELECT * FROM V_EmployeeNameJobTitle

----Problem 18
--SELECT DISTINCT e.JobTitle FROM Employees AS e

----Problem 19
--SELECT TOP 10 * FROM Projects
--	ORDER BY StartDate, [Name]

----Problem 20
--SELECT TOP 7 FirstName, LastName, HireDate FROM Employees
--	ORDER BY HireDate DESC

----Problem 21 
--UPDATE Employees
--SET Salary = 1.12 * Salary
--WHERE DepartmentID IN (1, 2, 4, 11)

--SELECT Salary FROM Employees

--USE Geography
--GO
----Problem 22
--SELECT PeakName FROM Peaks
--ORDER BY PeakName

----Problem 23
--SELECT TOP 30 CountryName, Population FROM Countries
--WHERE ContinentCode = 'EU'
--ORDER BY Population DESC, CountryName


----Problem 24
--SELECT * FROM Countries
--SELECT c.CountryName, 
--	   c.CountryCode, 
--	   CASE 
--		WHEN c.CurrencyCode = 'EUR' 
--		THEN 'Euro' 
--		ELSE 'Not Euro'
--		END 
--		AS Currencies 
--FROM Countries AS c
--ORDER BY c.CountryName


--Problem 25
USE Diablo
GO
SELECT [Name] FROM Characters
ORDER BY [Name]






