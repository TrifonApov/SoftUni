using System;

int rows = int.Parse(Console.ReadLine());
ulong[][] pascalTriangle = new ulong[rows][];

for (int i = 1; i <= rows; i++)
{
    pascalTriangle[i - 1] = new ulong[i];
}

pascalTriangle[0][0] = 1;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        if (row == 0 && col == 0)
        {
            continue;
        }

        ulong top = 0;
        ulong topLeft = 0;
        try
        {
            top = pascalTriangle[row - 1][col];
        }
        catch (IndexOutOfRangeException) { }

        try
        {
            topLeft = pascalTriangle[row - 1][col - 1];
        }
        catch (IndexOutOfRangeException) { }

        pascalTriangle[row][col] = top + topLeft;
    }
}

foreach (ulong[] row in pascalTriangle)
{
    Console.WriteLine(string.Join(" ", row));
}