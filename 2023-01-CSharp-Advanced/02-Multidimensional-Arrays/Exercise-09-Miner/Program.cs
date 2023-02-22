using System;
using System.Linq;

int dimensions = int.Parse(Console.ReadLine());
string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[][] field = new string[dimensions][];
int[] startPosition = new int[2];
int[] endPosition = new int[2];
int allCoals = 0;

for (int row = 0; row < dimensions; row++)
{
    string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    field[row] = inputRow;
    for (int col = 0; col < dimensions; col++)
    {
        switch (inputRow[col])
        {
            case "s":
                startPosition[0] = row;
                startPosition[1] = col;
                break;
            case "c":
                allCoals++;
                break;
            case "e":
                endPosition[0] = row;
                endPosition[1] = col;
                break;
        }
    }
}


int currentRow = startPosition[0];
int currentCol = startPosition[1];
foreach (string command in commands)
{
    switch (command)
    {
        case "up":
            try
            {
                currentRow--;
                if (field[currentRow][currentCol] == "c")
                {
                    field[currentRow][currentCol] = "*";
                    allCoals--;
                    if (allCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }

                if (field[currentRow][currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
                break;
            }
            catch (IndexOutOfRangeException e)
            {
                currentRow++;
            }
            break;
        case "down":
            try
            {
                currentRow++;
                if (field[currentRow][currentCol] == "c")
                {
                    field[currentRow][currentCol] = "*";
                    allCoals--;
                    if (allCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                if (field[currentRow][currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                currentRow--;
            }
            break;
        case "left":
            try
            {
                currentCol--;
                if (field[currentRow][currentCol] == "c")
                {
                    field[currentRow][currentCol] = "*";
                    allCoals--;
                    if (allCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                if (field[currentRow][currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                currentCol++;
            }
            break;
        case "right":
            try
            {
                currentCol++;
                if (field[currentRow][currentCol] == "c")
                {
                    field[currentRow][currentCol] = "*";
                    allCoals--;
                    if (allCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                if (field[currentRow][currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                currentCol--;
            }
            break;
    }
}

Console.WriteLine($"{allCoals} coals left. ({currentRow}, {currentCol})");