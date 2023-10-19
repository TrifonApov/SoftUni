-- 05
--SELECT CONVERT(VARCHAR, b.ArrivalDate, 23), b.AdultsCount, b.ChildrenCount FROM Bookings AS b
--JOIN Rooms AS r ON b.RoomId = r.Id
--ORDER BY r.Price DESC, b.ArrivalDate

-- 06
--SELECT h.Id, h.[Name] FROM Hotels AS h
--JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
--JOIN Rooms AS r ON r.Id = hr.RoomId
--JOIN Bookings AS b ON b.HotelId = h.Id
--WHERE r.Type = 'VIP Apartment'
--GROUP BY h.Id, h.[Name] 
--ORDER BY COUNT(b.Id) DESC

-- 07
--SELECT t.Id, t.[Name], t.PhoneNumber FROM Tourists AS t
--LEFT JOIN Bookings AS b ON t.Id = b.TouristId
--WHERE b.ID IS NULL
--ORDER BY [Name]

-- 08
--SELECT TOP 10
--	h.[Name] AS 'HotelName'
--	, d.[Name] AS 'DestinationName'
--	, c.[Name] AS 'CountryName'
--FROM Bookings AS b
--JOIN Hotels AS h ON b.HotelId = h.Id
--JOIN Destinations AS d ON h.DestinationId = d.Id
--JOIN Countries AS c ON d.CountryId = c.Id
--WHERE h.Id % 2 = 1 AND b.ArrivalDate < '2023-12-31'
--ORDER BY c.[Name], b.ArrivalDate

-- 09
--SELECT 
--	h.[Name] AS 'HotelName'
--	,r.Price AS 'RoomPrice'
--FROM Tourists AS t
--  JOIN Bookings AS b ON t.Id = b.TouristId
--  JOIN Hotels AS h ON b.HotelId = h.Id
--  JOIN Rooms AS r ON b.RoomId = r.Id
--WHERE t.[Name] NOT LIKE '%EZ'
--ORDER BY 'RoomPrice' DESC

-- 10
--SELECT 
--	h.[Name] AS 'HotelName'
--	, SUM(DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate) * r.Price) AS 'HotelRevenue'
--FROM Bookings AS b
--JOIN Hotels AS h ON b.HotelId = h.Id
--JOIN Rooms AS r ON b.RoomId = r.Id
--GROUP BY h.[Name]
--ORDER BY 'HotelRevenue' DESC