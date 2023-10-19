USE Boardgames
GO

----5.	Boardgames by Year of Publication
--SELECT [Name], Rating FROM  Boardgames
--ORDER BY YearPublished, [Name] DESC

----6.	Boardgames by Category
--SELECT	
--	b.Id
--	,b.[Name]
--	,b.YearPublished
--	,c.[Name] AS 'CategoryName'
--FROM Boardgames AS b
--JOIN Categories AS c ON b.CategoryId = c.Id
--WHERE c.Name = 'Strategy Games' OR c.Name = 'Wargames'
--ORDER BY b.YearPublished DESC

----7.	Creators without Boardgames
--SELECT
--	c.Id,
--	CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName,
--	c.Email
--FROM Creators AS c
--LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
--WHERE cb.BoardgameId IS NULL
--ORDER BY CreatorName ASC

----8.	First 5 Boardgames
--SELECT TOP 5
--	b.[Name]
--	,b.Rating
--	,c.[Name] AS 'CategoryName'
--FROM Boardgames AS b
--JOIN Categories AS c ON b.CategoryId = c.Id
--JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
--WHERE b.Rating > 7.00 AND b.[Name] LIKE '%a%'
-- OR b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
-- ORDER BY b.[Name], b.Rating DESC

----9.	Creators with Emails
--SELECT 
--	CONCAT_WS(' ', c.FirstName, c.LastName) AS FullName
--	,c.Email
--	,MAX(b.Rating)
--FROM Creators AS c
--JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
--JOIN Boardgames AS b ON b.Id = cb.BoardgameId
--GROUP BY c.FirstName, c.LastName, c.Email
--HAVING c.Email LIKE '%.com'
--ORDER BY FullName

----10.	Creators by Rating
--SELECT 
--	c.LastName
--	,CEILING(AVG(b.Rating)) AS 'AverageRating'
--	,p.[Name] AS 'PublisherName'
--FROM Creators AS c
--JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
--JOIN Boardgames AS b ON cb.BoardgameId = b.Id 
--JOIN Publishers AS p ON b.PublisherId = p.Id
--WHERE p.[Name] = 'Stonemaier Games'
--GROUP BY c.LastName, p.[Name]
--ORDER BY AVG(b.Rating) DESC

-- 11. Creator With Boargames
--CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
--RETURNS INT
--AS
--BEGIN
--	DECLARE @result INT = 
--	(
--		SELECT 
--			COUNT(*)
--		FROM Creators AS c
--		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
--		JOIN Boardgames AS b ON cb.BoardgameId = b.Id
--		WHERE c.FirstName = @name
--	)
--	RETURN @result
--END

---- 12.	Search for Boardgame with Specific Category
--CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
--AS

--	SELECT 
--		b.[Name]
--		, b.YearPublished
--		, b.Rating
--		, c.[Name] AS 'CategoryName'
--		, p.[Name] AS 'PublisherName'
--		, CONCAT(pr.PlayersMin, ' people') AS MinPlayers
--		, CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
--	FROM Boardgames AS b
--	JOIN Publishers AS p ON b.PublisherId = p.Id
--	JOIN Categories AS c ON b.CategoryId = c.Id
--	JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
--	WHERE c.[Name] = 'Children Games'
--	ORDER BY p.[Name], b.YearPublished DESC

