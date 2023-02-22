using System;

using System.Linq;

int[] matrixDimensions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
int[,] matrix = new int[matrixDimensions[0], matrixDimensions[1]];

for (int i = 0; i < matrixDimensions[0]; i++)
{
    int[] rowElement = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
    for (int j = 0; j < matrixDimensions[1]; j++)
    {
        matrix[i, j] = rowElement[j];
    }
}

for (int cols = 0; cols < matrixDimensions[1]; cols++)
{
    int sum = 0;
    for (int rows = 0; rows < matrixDimensions[0]; rows++)
    {
        sum += matrix[rows, cols];
    }
    Console.WriteLine(sum);
}
