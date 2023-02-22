using System;
using System.Linq;

int matrixDimensions = int.Parse(Console.ReadLine());
int[,] matrix = new int[matrixDimensions, matrixDimensions];

int leftDiagonalSum = 0;
int rightDiagonalSum = 0;

for (int i = 0; i < matrixDimensions; i++)
{
    int[] rowElement = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int j = 0; j < matrixDimensions; j++)
    {
        matrix[i, j] = rowElement[j];
    }
}

for (int row = 0; row < matrixDimensions; row++)
{
    leftDiagonalSum += matrix[row, row];
}


for (int row = 0; row < matrixDimensions; row++)
{
    rightDiagonalSum += matrix[row, matrixDimensions - row - 1];
}



Console.WriteLine(Math.Abs(leftDiagonalSum - rightDiagonalSum));