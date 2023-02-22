using System;
using System.Linq;

namespace Problem02
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            string[][] field = new string[size[0]][];
            int touchedPlayer = 0;
            int moves = 0;

            int[] position = new int[2];
            for (int i = 0; i < size[0]; i++)
            {

                string[] readLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (readLine.Contains("B"))
                {
                    position[0] = i;
                    position[1] = Array.IndexOf(readLine, "B");
                }

                field[i] = readLine;
            }




            string command = Console.ReadLine();
            while (command != "Finish" && touchedPlayer < 3)
            {
                switch (command)
                {
                    case "left":
                        if (position[1] - 1 < 0)
                        { command = Console.ReadLine(); continue; }
                        if (field[position[0]][position[1] - 1] == "O")
                        { command = Console.ReadLine(); continue; }

                        position[1]--;
                        moves++;
                        break;
                    case "right":
                        if (position[1] + 1 == size[1])
                        { command = Console.ReadLine(); continue; }
                        if (field[position[0]][position[1] + 1] == "O")
                        { command = Console.ReadLine(); continue; }

                        position[1]++;
                        moves++;
                        break;
                    case "up":
                        if (position[0] - 1 < 0)
                        { command = Console.ReadLine(); continue; }
                        if (field[position[0] - 1][position[1]] == "O")
                        { command = Console.ReadLine(); continue; }

                        position[0]--;
                        moves++;
                        break;


                    case "down":
                        if (position[0] + 1 == size[0])
                        { command = Console.ReadLine(); continue; }
                        if (field[position[0] + 1][position[1]] == "O")
                        { command = Console.ReadLine(); continue; }

                        position[0]++;
                        moves++;
                        break;
                }

                if (field[position[0]][position[1]] == "P")
                    touchedPlayer++;

                command = Console.ReadLine();
            }



            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedPlayer} Moves made: {moves}");
        }
    }
}