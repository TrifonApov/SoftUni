using System;
using System.Linq;

int[] matrixDimentions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
string[,] matrix = new string[matrixDimentions[0], matrixDimentions[1]];

for (int i = 0; i < matrixDimentions[0]; i++)
{
    string[] rowElement = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j < matrixDimentions[1]; j++)
    {
        matrix[i, j] = rowElement[j];
    }
}

int count = 0;

for (int row = 0; row < matrixDimentions[0] - 1; row++)
{
    for (int col = 0; col < matrixDimentions[1] - 1; col++)
    {
        bool isEquals = matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1];
        if (isEquals)
        {
            count++;
        }
    }
}

Console.WriteLine(count);