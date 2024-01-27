namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Extensions;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            string result;

            var creatorsWithTheirBoardgame = context.Creators
                .Where(c=>c.Boardgames.Any())
                .Select(c=> new ExportCreatorsDTO
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames
                        .Select(b=> new ExportBoargdameDTO
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished,
                        })
                        .ToArray()
                })
                .OrderByDescending(c=>c.Boardgames.Length)
                .ThenBy(c=>c.CreatorName)
                .ToArray();

            result = creatorsWithTheirBoardgame.SerializeToXml("Creators");

            return result.TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersWithMostBoardgames = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bg =>
                    bg.Boardgame.YearPublished >= year &&
                    bg.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(b => new
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s=>s.Boardgames.Length)
                .ThenBy(b => b.Name)
                .Take(5)
                .ToArray();

            var result = sellersWithMostBoardgames.SerializeToJson();

            
            return result.TrimEnd();
        }
    }
}