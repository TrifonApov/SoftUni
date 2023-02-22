using System;
using System.Linq;

int[] fieldDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] field = new char[fieldDimensions[0], fieldDimensions[1]];
field = ReadField(fieldDimensions);

int[] playerPosition = FindPlayerPosition(field);

string commands = Console.ReadLine();
bool isPlayerOut = false;
bool isDead = false;

foreach (char command in commands)
{
    switch (command)
    {
        case 'D':
            if (playerPosition[0] + 1 >= fieldDimensions[0])
            {
                isPlayerOut = true;
                field[playerPosition[0], playerPosition[1]] = '.';
            }
            else
            {
                playerPosition[0]++;
            }
            break;
        case 'U':
            if (playerPosition[0] - 1 < 0)
            {
                isPlayerOut = true;
                field[playerPosition[0], playerPosition[1]] = '.';
            }
            else
            {
                playerPosition[0]--;
            }
            break;
        case 'L':
            if (playerPosition[1] - 1 < 0)
            {
                isPlayerOut = true;
                field[playerPosition[0], playerPosition[1]] = '.';
            }
            else
            {
                playerPosition[1]--;
            }
            break;
        case 'R':
            if (playerPosition[1] + 1 >= fieldDimensions[1])
            {
                isPlayerOut = true;
                field[playerPosition[0], playerPosition[1]] = '.';
            }
            else
            {
                playerPosition[1]++;
            }
            break;
    }

    field = SpreadBunnies(fieldDimensions[0], fieldDimensions[1], field);
    if (field[playerPosition[0], playerPosition[1]] == 'B')
    {
        
        isDead = true;
    }

    if (isDead || isPlayerOut)
    {
        break;
    }
}

PrintField(field);

if (isPlayerOut)
{
    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
}
else if (isDead)
{
    Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
}





char[,] ReadField(int[] ints)
{
    char[,] chars;
    chars = new char[ints[0], ints[1]];

    for (int i = 0; i < ints[0]; i++)
    {
        string inputFieldRow = Console.ReadLine();
        for (int j = 0; j < ints[1]; j++)
        {
            chars[i, j] = inputFieldRow[j];
        }
    }

    return chars;
}

int[] FindPlayerPosition(char[,] chars)
{
    int[] positions = new int[2];
    for (int i = 0; i < chars.GetLength(0); i++)
    {
        for (int j = 0; j < chars.GetLength(1); j++)
        {
            if (chars[i, j] == 'P')
            {
                positions[0] = i;
                positions[1] = j;
            }
        }
    }

    return positions;
}

char[,] SpreadBunnies(int rows, int cols, char[,] bunnies)
{
    char[,] newField = new char[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            newField[row, col] = bunnies[row, col];
        }
    }

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (bunnies[row, col] == 'B')
            {
                if (row - 1 >= 0)
                {
                    newField[row - 1, col] = 'B';
                }

                if (row + 1 < rows)
                {
                    newField[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    newField[row, col - 1] = 'B';
                }

                if (col + 1 < cols)
                {
                    newField[row, col + 1] = 'B';
                }
            }
        }
    }

    return newField;
}

void PrintField(char[,] chars)
{
    for (int i = 0; i < chars.GetLength(0); i++)
    {
        for (int j = 0; j < chars.GetLength(1); j++)
        {
            if (chars[i,j] == 'P')
            {
                chars[i, j] = '.';
            }
            Console.Write(chars[i, j]);
        }
        Console.WriteLine();
    }
}