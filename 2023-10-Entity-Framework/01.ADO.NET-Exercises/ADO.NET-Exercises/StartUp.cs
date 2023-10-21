using Microsoft.Data.SqlClient;

namespace ADO.NET_Exercises
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionSting);
            sqlConnection.Open();

            Console.WriteLine("Kur");
            using SqlCommand command = new SqlCommand(
                @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                    FROM Villains AS v 
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                    GROUP BY v.Id, v.Name 
                    HAVING COUNT(mv.VillainId) > 3 
                    ORDER BY COUNT(mv.VillainId)", sqlConnection);

            using SqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine($"{result["Name"]} - {result["MinionsCount"]}");
            }
        }
    }
}