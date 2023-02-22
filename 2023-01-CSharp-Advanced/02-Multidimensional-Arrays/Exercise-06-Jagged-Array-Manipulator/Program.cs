using System;
using System.Linq;

int numberOfRows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[numberOfRows][];

// Fill the array
for (int i = 0; i < numberOfRows; i++)
{
    jaggedArray[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}

// Analyzing the array
for (int i = 0; i < numberOfRows - 1; i++)
{
    if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            jaggedArray[i][j] *= 2;
            jaggedArray[i + 1][j] *= 2;
        }
    }
    else
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            jaggedArray[i][j] /= 2;
        }

        for (int j = 0; j < jaggedArray[i + 1].Length; j++)
        {
            jaggedArray[i + 1][j] /= 2;
        }
    }
}

// Manipulate the array

string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
while (commandTokens[0] != "End")
{
    try
    {
        int row = int.Parse(commandTokens[1]);
        int col = int.Parse(commandTokens[2]);
        int value = int.Parse(commandTokens[3]);

        switch (commandTokens[0])
        {
            case "Add":
                jaggedArray[row][col] += value;
                break;
            case "Subtract":
                jaggedArray[row][col] -= value;
                break;
        }
    }
    catch (IndexOutOfRangeException)
    {
        commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        continue; 
    }

    commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
}

// Print the array
for (int row = 0; row < jaggedArray.Length; row++)
{
    Console.WriteLine(string.Join(" ", jaggedArray[row]));
}
