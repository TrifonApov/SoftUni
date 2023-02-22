using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

int rows = int.Parse(Console.ReadLine());
int[][] field = new int[rows][];
for (int row = 0; row < rows; row++)
{
    field[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}

Queue<string> bombs = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));


while (bombs.Any())
{
    string[] bombCoordinates = bombs.Dequeue().Split(",", StringSplitOptions.RemoveEmptyEntries);
    int bombRow = int.Parse(bombCoordinates[0]);
    int bombCol = int.Parse(bombCoordinates[1]);
    int damage = field[bombRow][bombCol];
    if (damage <= 0)
    {
        continue;
    }

    for (int row = bombRow - 1; row <= bombRow + 1; row++)
    {
        for (int col = bombCol - 1; col <= bombCol + 1; col++)
        {
            try
            {
                if (field[row][col] > 0)
                {
                    field[row][col] -= damage;
                }
            }
            catch (IndexOutOfRangeException e)
            { }
        }
    }
}

StringBuilder sb = new StringBuilder();
int aliceCells = 0;
int sum = 0;
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < rows; col++)
    {
        if (field[row][col] > 0)
        {
            aliceCells++;
            sum += field[row][col];
        }
    }
}

Console.WriteLine($"Alive cells: {aliceCells}");
Console.WriteLine($"Sum: {sum}");
for (int row = 0; row < rows; row++)
{
    Console.WriteLine(string.Join(" ", field[row]));
}