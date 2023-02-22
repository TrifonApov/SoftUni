using System;
using System.Linq;

int matrixDimensions = int.Parse(Console.ReadLine());
char[,] matrix = new char[matrixDimensions, matrixDimensions];
bool isFound = false;
string result = "";

for (int i = 0; i < matrixDimensions; i++)
{
    string rowElement = Console.ReadLine();
    for (int j = 0; j < matrixDimensions; j++)
    {
        matrix[i, j] = rowElement[j];
    }
}

string symbol = Console.ReadLine();
for (int i = 0; i < matrixDimensions; i++)
{
    for (int j = 0; j < matrixDimensions; j++)
    {
        if (matrix[i, j] == symbol[0])
        {
            isFound = true;
            result = $"({i}, {j})";
            Console.WriteLine(result);
                
            return;
        }
    }
}

Console.WriteLine($"{symbol} does not occur in the matrix");