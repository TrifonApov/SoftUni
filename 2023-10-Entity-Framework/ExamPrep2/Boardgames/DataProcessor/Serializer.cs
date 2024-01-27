namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {

            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bs=>bs.Boardgame.Rating <=rating || bs.Boardgame.YearPublished >= year))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers.Select(bs=>new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        bs.Boardgame.CategoryType
                    })
                    .OrderByDescending(g=>g.Rating)
                    .ThenBy(g=>g.Name)
                    .ToArray()
                })
                .OrderByDescending(s=>s.Boardgames.Count())
                .ThenBy(s=>s.Name)
                .ToArray();


            Console.WriteLine();
            return "";
            // Select the top 5 sellers that have at least one boardgame
            // that their year of publishing is greater or equal to the given year
            // and their rating is smaller or equal to the given rating.
            //
            // Select them with their boardgames who meet the same criteria (their year of publishing is greater or equals the given year and the rating is smaller or equal to the given rating). For each seller, export their name, website and their boardgames. For each boardgame, export their name, rating, mechanics and category type. Order the boardgames by rating (descending), then by name (ascending). Order the sellers by all boardgames (meeting above condition) count (descending), then by name (ascending).
            //
            // NOTE: You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 
            // 
        }
    }
}