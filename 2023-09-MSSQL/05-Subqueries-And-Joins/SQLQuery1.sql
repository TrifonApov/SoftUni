--USE SoftUni
--GO

---- Problem 11
--SELECT 
--	MIN(a.Average) AS 'MinAverageSalary' 
--FROM (
--	SELECT 
--		AVG(e.Salary) AS 'Average'
--	  FROM Employees AS e
--	  JOIN Departments AS d
--		ON e.DepartmentID = d.DepartmentID
--	GROUP BY d.DepartmentID) AS a


-- Problem 12
--USE Geography
--GO

--SELECT 
--	c.CountryCode
--	, MountainRange
--	, p.PeakName
--	, p.Elevation 
--FROM Peaks AS p
-- JOIN Mountains AS m ON p.MountainId = m.Id
-- JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
-- JOIN Countries AS c ON mc.CountryCode = c.CountryCode
--WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
--ORDER BY p.Elevation DESC

---- Problem 13
--SELECT 
--	c.CountryCode , COUNT(m.MountainRange)
--FROM Countries AS c
--  JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
--  JOIN Mountains AS m ON mc.MountainId = m.Id
--WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
--GROUP BY c.CountryCode

-- Problem 14
--SELECT TOP 5
--	c.CountryName, r.RiverName
--FROM Countries AS c
--  LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
--  LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
--  JOIN Continents AS cn ON c.ContinentCode = cn.ContinentCode
--WHERE cn.ContinentName = 'Africa'
--ORDER BY c.CountryName


---- Problem 15
--SELECT 
--	cn.ContinentCode
--	, COUNT(cur.CurrencyCode)
--FROM Countries AS c
--  JOIN Continents AS cn ON c.ContinentCode = cn.ContinentCode
--  JOIN Currencies AS cur ON c.CurrencyCode = cur.CurrencyCode
--GROUP BY cn.ContinentCode

---- Problem 16
--SELECT COUNT(*) FROM Countries AS c
--  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
--WHERE mc.CountryCode IS NULL

---- Problem 17
--SELECT TOP 5
--	c.CountryName
--	, MAX(p.Elevation) AS 'HighestPeakElevation'
--	, MAX(r.[Length]) AS 'LongestRiverLength' 
--FROM Countries AS c
--  FULL JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
--  FULL JOIN Mountains AS m ON mc.MountainId = m.Id
--  FULL JOIN Peaks AS p ON m.Id = p.MountainId
--  FULL JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
--  FULL JOIN Rivers AS r ON cr.RiverId = r.Id
--GROUP BY c.CountryName
--ORDER BY 'HighestPeakElevation' DESC, 'LongestRiverLength' DESC

