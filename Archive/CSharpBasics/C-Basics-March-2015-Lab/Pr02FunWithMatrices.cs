using System;

class FunWithMatrices
{
    static void Main(string[] args)
    {
        double start = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        double prevCellValue = start;
        double[,] matrix = new double[4, 4];

        //fill the matrix
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                matrix[row, col] = prevCellValue;
                prevCellValue += step;
            }
        }

        //perform the comands
        while (true)
        {
            string[] currentLine = Console.ReadLine().Split(' ');
            if (currentLine[0] == "Game")
            {
                break;
            }
            int neededRow = int.Parse(currentLine[0]);
            int neededCol = int.Parse(currentLine[1]);
            string comand = currentLine[2];
            double number = double.Parse(currentLine[3]);

            if (comand == "multiply")
            {
                matrix[neededRow, neededCol] *= number;
            }
            if (comand == "sum")
            {
                matrix[neededRow, neededCol] += number;
            }
            if (comand == "power")
            {
                matrix[neededRow, neededCol] = Math.Pow(matrix[neededRow, neededCol], number);
            }
        }

        //find the max sum
        double maxSum = double.MinValue;
        string output = "";

        //rows max sum
        for (int row = 0; row < 4; row++)
        {
            if (matrix[row, 0] + matrix[row, 1] + matrix[row, 2] + matrix[row, 3] > maxSum)
            {
                maxSum = matrix[row, 0] + matrix[row, 1] + matrix[row, 2] + matrix[row, 3];
                output = "ROW[" + row + "] = ";
            }
        }

        //cols max sum
        for (int col = 0; col < 4; col++)
        {
            if (matrix[0, col] + matrix[1, col] + matrix[2, col] + matrix[3, col] > maxSum)
            {
                maxSum = matrix[0, col] + matrix[1, col] + matrix[2, col] + matrix[3, col];
                output = "COLUMN[" + col + "] = ";
            }
        }

        //left diagonal sum
        if (matrix[0, 0] + matrix[1, 1] + matrix[2, 2] + matrix[3, 3] > maxSum)
        {
            maxSum = matrix[0, 0] + matrix[1, 1] + matrix[2, 2] + matrix[3, 3];
            output = "LEFT-DIAGONAL = ";
        }

        //right diagonal sum
        if (matrix[0, 3] + matrix[1, 2] + matrix[2, 1] + matrix[3, 0] > maxSum)
        {
            maxSum = matrix[0, 3] + matrix[1, 2] + matrix[2, 1] + matrix[3, 0];
            output = "RIGHT-DIAGONAL = ";
        }
        Console.Write(output);
        Console.WriteLine("{0:0.00}", maxSum);
    }
}