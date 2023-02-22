using System;
using System.Linq;

int[] matrixDimentions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
int[,] matrix = new int[matrixDimentions[0], matrixDimentions[1]];
int sum = 0;
for (int i = 0; i < matrixDimentions[0]; i++)
{
    int[] rowElement = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();
    for (int j = 0; j < matrixDimentions[1]; j++)
    {
        matrix[i,j]= rowElement[j];
        sum += rowElement[j];
    }
}

Console.WriteLine(matrixDimentions[0]);
Console.WriteLine(matrixDimentions[1]);
Console.WriteLine(sum);