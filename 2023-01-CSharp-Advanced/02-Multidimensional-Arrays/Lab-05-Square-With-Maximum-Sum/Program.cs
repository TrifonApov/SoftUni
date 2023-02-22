using System;
using System.Linq;

int[] matrixDimentions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
int[,] matrix = new int[matrixDimentions[0], matrixDimentions[1]];

for (int i = 0; i < matrixDimentions[0]; i++)
{
    int[] rowElement = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
    for (int j = 0; j < matrixDimentions[1]; j++)
    {
        matrix[i, j] = rowElement[j];
    }
}

int biggestSum = matrix[0, 0] + matrix[0, 1] + matrix[1, 0] + matrix[1, 1];
int[,] biggestSquare = new int[,]
{
    { matrix[0, 0], matrix[0, 1] },
    { matrix[1, 0], matrix[1, 1] }
};

for (int row = 0; row < matrixDimentions[0] - 1; row++)
{
    for (int col = 0; col < matrixDimentions[1] - 1; col++)
    {
        int sum = matrix[row, col] + matrix[row, col + 1]
            + matrix[row + 1, col] + matrix[row + 1, col + 1];
        if (sum > biggestSum)
        {
            biggestSum = sum;
            biggestSquare[0, 0] = matrix[row, col];
            biggestSquare[0, 1] = matrix[row, col + 1];
            biggestSquare[1, 0] = matrix[row + 1, col];
            biggestSquare[1, 1] = matrix[row + 1, col + 1];
        }
    }
}


for (int row = 0; row < 2; row++)
{
    for (int col = 0; col < 2; col++)
    {
        Console.Write($"{biggestSquare[row,col]} ");
    }
    Console.WriteLine();
}

Console.WriteLine(biggestSum);