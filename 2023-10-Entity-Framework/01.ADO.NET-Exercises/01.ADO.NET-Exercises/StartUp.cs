using Microsoft.Data.SqlClient;

namespace ADO.NET_Exercises
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionSting);
            sqlConnection.Open();

            // Problem 02
            // GetVillainsWithMoreThan3Minions(sqlConnection);

            // Problem 03
            // GetAllVilainMinions(sqlConnection);

            // Problem 04

        }

        private static void GetAllVilainMinions(SqlConnection sqlConnection)
        {
            int id = int.Parse(Console.ReadLine());

            using SqlCommand getVilainName = new SqlCommand(
                @$"SELECT Name FROM Villains WHERE Id = {id}", sqlConnection);

            using SqlCommand getVilainMinions = new SqlCommand(
                @$"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = {id}
                                ORDER BY m.Name", sqlConnection);

            var result = getVilainName.ExecuteScalar();
            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");

                return;
            }
            Console.WriteLine($"Villain: {result}");

            using SqlDataReader minions = getVilainMinions.ExecuteReader();

            if (!minions.Read())
            {
                Console.WriteLine("(no minions)");
            }
            else
            {
                while (minions.Read())
                {
                    Console.WriteLine($"{minions[0]}. {minions[1]} {minions[2]}");
                }
            }
        }

        private static void GetVillainsWithMoreThan3Minions(SqlConnection sqlConnection)
        {
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