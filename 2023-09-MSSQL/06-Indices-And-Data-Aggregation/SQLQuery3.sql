USE Gringotts
GO

--SELECT COUNT(*) FROM WizzardDeposits

--SELECT TOP 2 DepositGroup FROM WizzardDeposits
--GROUP BY DepositGroup
--ORDER BY AVG(MagicWandSize)


--SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum' FROM WizzardDeposits
--GROUP BY DepositGroup, MagicWandCreator
--HAVING MagicWandCreator = 'Ollivander Family' AND SUM(DepositAmount) < 150000
--ORDER BY SUM(DepositAmount) DESC

--SELECT 
--	DepositGroup
--	, MagicWandCreator
--	, MIN(DepositCharge) AS 'MinDepositCharge'
--FROM WizzardDeposits
--GROUP BY DepositGroup, MagicWandCreator
--ORDER BY MagicWandCreator, DepositGroup