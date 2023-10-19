USE SoftUni
GO

-- PROBLEM 01

--SELECT TOP 5 e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
--FROM Employees AS e
--JOIN Addresses AS a
--ON e.AddressID = a.AddressID
--ORDER BY a.AddressID

-- PROBLEM 02
--SELECT TOP 50 e.FirstName, e.LastName, t.Name AS 'Town', a.AddressText FROM Employees AS e
--JOIN Addresses AS a ON e.AddressID = a.AddressID
--JOIN Towns AS t ON a.TownID = t.TownID
--ORDER BY e.FirstName, e.LastName

-- PROBLEM 03
--SELECT 
--	e.EmployeeID
--	, e.FirstName
--	, e.LastName
--	, d.[Name] AS 'DepartmentName' 
--FROM Employees AS e
--JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
--WHERE d.Name = 'Sales'
--ORDER BY e.EmployeeID

-- PROBLEM 04
--SELECT TOP 5
--	e.EmployeeID
--	, e.FirstName
--	, e.Salary
--	, d.[Name] AS 'DepartmentName' 
--FROM Employees AS e
--JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
--WHERE e.Salary > 15000
--ORDER BY d.DepartmentID

-- PROBLEM 05
--SELECT TOP 3 e.EmployeeID, e.FirstName FROM Employees AS e
--LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
--WHERE ep.EmployeeID IS NULL
--ORDER BY e.EmployeeID

-- PROBLEM 06
--SELECT 
--	e.FirstName
--	, e.LastName
--	, e.HireDate
--	, d.[Name] AS 'DeptName'	
--FROM Employees AS e
--JOIN Departments AS d 
--	ON e.DepartmentID = d.DepartmentID
--WHERE 
--	e.HireDate > '1999.1.1'
--	AND d.[Name] = 'Sales' 
--	OR d.[Name] = 'Finance'
--ORDER BY e.HireDate

-- PROBLEM 07
--SELECT TOP 5 
--	e.EmployeeID
--	, e.FirstName
--	, p.[Name] AS 'ProjectName'
--FROM Employees AS e
--LEFT JOIN EmployeesProjects AS ep 
--	ON e.EmployeeID = ep.EmployeeID
--LEFT JOIN Projects AS p
--	ON ep.ProjectID = p.ProjectID
--WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
--ORDER BY e.EmployeeID


-- PROBLEM 08
--SELECT 
--	e.EmployeeID
--	, e.FirstName
--	, CASE WHEN p.StartDate > '2005-01-01' THEN NULL ELSE p.[Name] END 'ProjectName'
--FROM Employees AS e
--LEFT OUTER JOIN EmployeesProjects AS ep 
--	ON e.EmployeeID = ep.EmployeeID
--LEFT OUTER JOIN Projects AS p
--	ON ep.ProjectID = p.ProjectID
--WHERE e.EmployeeID = 24 AND p.StartDate > '1900.01.01'

-- PROBLEM 09
--SELECT 
--	em.EmployeeID
--	, em.FirstName
--	, m.EmployeeID AS 'ManagerID'
--	, m.FirstName AS 'ManagerName'
--FROM Employees AS em
--JOIN Employees AS m 
--	ON em.ManagerID = m.EmployeeID
--WHERE m.EmployeeID = 3 OR m.EmployeeID = 7
--ORDER BY em.EmployeeID

-- PROBLEM 10
--SELECT TOP 50
--	em.EmployeeID
--	, CONCAT_WS(' ', em.FirstName, em.LastName) AS 'EmployeeName'
--	, CONCAT_WS(' ', m.FirstName, m.LastName) AS 'ManagerName'
--	, d.[Name] AS 'DepartmentName'
--FROM Employees AS em
--JOIN Employees AS m 
--	ON em.ManagerID = m.EmployeeID
--JOIN Departments AS d
--	ON em.DepartmentID = d.DepartmentID
--ORDER BY em.EmployeeID

-- PROBLEM 11

-- PROBLEM 12
-- PROBLEM 13
-- PROBLEM 14
-- PROBLEM 15
-- PROBLEM 16
-- PROBLEM 17
-- PROBLEM 18
