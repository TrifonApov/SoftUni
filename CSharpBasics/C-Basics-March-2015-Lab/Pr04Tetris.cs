using System;

class Tetris
{
    static void Main(string[] args)
    {
        //take the input
        string[] matrixSize = Console.ReadLine().Split();
        int matrixRows = int.Parse(matrixSize[0]);
        int matrixCols = int.Parse(matrixSize[1]);
        string[] inputLines = new string[matrixRows];
        for (int i = 0; i < matrixRows; i++)
        {
            inputLines[i] = Console.ReadLine();
        }

        //fill the matrix
        char[,] gameField = new char[matrixRows, matrixCols];
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                string currerntLine = inputLines[row];
                gameField[row, col] = currerntLine[col];
            }
        }

        //count the 'I'
        int countI = 0;
        for (int row = 0; row < matrixRows - 3; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row + 1, col] &&
                    gameField[row, col] == gameField[row + 2, col] &&
                    gameField[row, col] == gameField[row + 3, col])
                {
                    countI++;
                }
            }
        }
        //count the 'L'
        int countL = 0;
        for (int row = 0; row < matrixRows - 2; row++)
        {
            for (int col = 0; col < matrixCols - 1; col++)
            {
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row + 1, col] &&
                    gameField[row, col] == gameField[row + 2, col] &&
                    gameField[row, col] == gameField[row + 2, col + 1])
                {
                    countL++;
                }
            }
        }
        //count the 'J'
        int countJ = 0;
        for (int row = 0; row < matrixRows - 2; row++)
        {
            for (int col = 1; col < matrixCols; col++)
            {
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row + 1, col] &&
                    gameField[row, col] == gameField[row + 2, col] &&
                    gameField[row, col] == gameField[row + 2, col - 1])
                {
                    countJ++;
                }
            }
        }
        //count the 'O'
        int countO = 0;
        for (int row = 0; row < matrixRows - 1; row++)
        {
            for (int col = 0; col < matrixCols - 1; col++)
            {
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row, col + 1] &&
                    gameField[row, col] == gameField[row + 1, col] &&
                    gameField[row, col] == gameField[row + 1, col + 1])
                {
                    countO++;
                }
            }
        }
        //count the 'Z', 'S' and 'T'
        int countZ = 0, countS = 0, countT = 0;
        for (int row = 0; row < matrixRows - 1; row++)
        {
            for (int col = 0; col < matrixCols - 2; col++)
            {
                //Z
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row, col + 1] &&
                    gameField[row, col] == gameField[row + 1, col + 1] &&
                    gameField[row, col] == gameField[row + 1, col + 2])
                {
                    countZ++;
                }
                //S
                if (gameField[row, col + 1] == 'o' &&
                    gameField[row, col + 1] == gameField[row, col + 2] &&
                    gameField[row, col + 1] == gameField[row + 1, col] &&
                    gameField[row, col + 1] == gameField[row + 1, col + 1])
                {
                    countS++;
                }
                //T
                if (gameField[row, col] == 'o' &&
                    gameField[row, col] == gameField[row, col + 1] &&
                    gameField[row, col] == gameField[row, col + 2] &&
                    gameField[row, col] == gameField[row + 1, col + 1])
                {
                    countT++;
                }
            }
        }
        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", countI, countL, countJ, countO, countZ, countS, countT);
    }
}