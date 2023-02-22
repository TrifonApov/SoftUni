using System;
using System.Linq;

int matrixDimensions = int.Parse(Console.ReadLine());
int[,] matrix = new int[matrixDimensions, matrixDimensions];
int sum = 0;
for (int i = 0; i < matrixDimensions; i++)
{
    int[] rowElement = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
    for (int j = 0; j < matrixDimensions; j++)
    {
        matrix[i,j] = rowElement[j];
        if (i == j)
        {
            sum += rowElement[j];
        }
    }
}

Console.WriteLine(sum);