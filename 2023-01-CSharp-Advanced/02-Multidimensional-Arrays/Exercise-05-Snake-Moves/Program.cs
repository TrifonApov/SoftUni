using System;
using System.Collections.Generic;
using System.Linq;

int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];


for (int row = 0; row < matrixDimensions[0]; row++)
{
    if (row%2 == 0)
    {
        for (int col = 0; col < matrixDimensions[1]; col++)
        {
            char currentChar = snake.Peek();
            matrix[row, col] = currentChar;
            snake.Enqueue(snake.Dequeue());
        }
    }
    else
    {
        for (int col = matrixDimensions[1] - 1; col >= 0; col--)
        {
            char currentChar = snake.Peek();
            matrix[row, col] = currentChar;
            snake.Enqueue(snake.Dequeue());
        }
    }
}

for (int i = 0; i < matrixDimensions[0]; i++)
{
    for (int j = 0; j < matrixDimensions[1]; j++)
    {
        Console.Write(matrix[i,j]);
    }

    Console.WriteLine();
}