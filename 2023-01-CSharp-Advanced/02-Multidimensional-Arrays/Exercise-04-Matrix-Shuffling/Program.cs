using System;
using System.Linq;

string[,] matrix = FillMatrix();

string inputCommand = Console.ReadLine();

while (inputCommand != "END")
{
    string[] commandTokens = inputCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (!IsTokensValid(commandTokens, matrix.GetLength(0), matrix.GetLength(1)))
    {
        Console.WriteLine("Invalid input!");
        inputCommand = Console.ReadLine();
        continue;
    }

    int firstRow = int.Parse(commandTokens[1]);
    int firstCol = int.Parse(commandTokens[2]);
    int secondRow = int.Parse(commandTokens[3]);
    int secondCol = int.Parse(commandTokens[4]);
    string first = matrix[firstRow, firstCol];
    string second = matrix[secondRow, secondCol];
    matrix[firstRow, firstCol] = second;
    matrix[secondRow, secondCol] = first;

    PrintMatrix(matrix);

    inputCommand = Console.ReadLine();
}

static string[,] FillMatrix()
{
    int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    string[,] matrix = new string[matrixDimensions[0], matrixDimensions[1]];

    for (int row = 0; row < matrixDimensions[0]; row++)
    {
        string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        for (int col = 0; col < matrixDimensions[1]; col++)
        {
            matrix[row, col] = inputRow[col];
        }
    }

    return matrix;
}

bool IsTokensValid(string[] tokens, int rows, int cols)
{
    if (tokens.Length != 5) return false;

    if (tokens[0] != "swap") return false;

    int firstRow;
    int firstCol;
    int secondRow;
    int secondCol;

    try
    {
        firstRow = int.Parse(tokens[1]);
        firstCol = int.Parse(tokens[2]);
        secondRow = int.Parse(tokens[3]);
        secondCol = int.Parse(tokens[4]);
    }
    catch (Exception)
    {
        return false;
    }

    if (firstRow < 0 || firstRow >= rows) return false;
    if (firstCol < 0 || firstCol >= cols) return false;
    if (secondRow < 0 || secondRow >= rows) return false;
    if (secondCol < 0 || secondCol >= cols) return false;

    return true;
}


void PrintMatrix(string[,] strings)
{
    for (int i = 0; i < strings.GetLength(0); i++)
    {
        for (int j = 0; j < strings.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }

        Console.WriteLine();
    }
}
