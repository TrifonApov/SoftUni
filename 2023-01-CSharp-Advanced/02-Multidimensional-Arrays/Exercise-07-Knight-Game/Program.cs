using System;
using System.Runtime.InteropServices;

int dimensions = int.Parse(Console.ReadLine());

char[,] board = new char[dimensions, dimensions];
for (int i = 0; i < dimensions; i++)
{
    char[] row = Console.ReadLine().ToCharArray();

    for (int j = 0; j < dimensions; j++)
    {
        board[i, j] = row[j];
    }
}

int removedAttackers = 0;

for (int count = 0; count < dimensions*dimensions; count++)
{
    int mostAttacks = 0;
    int[] attackerPosition = new int[2];

    for (int i = 0; i < dimensions; i++)
    {
        for (int j = 0; j < dimensions; j++)
        {
            if (board[i, j] == 'K')
            {
                int attacks = 0;

                try { if (board[i, j] == board[i - 2, j + 1]) { attacks++; } }
                catch (IndexOutOfRangeException) { }

                try { if (board[i, j] == board[i - 2, j - 1]) { attacks++; } }
                catch (IndexOutOfRangeException) { }

                try { if (board[i, j] == board[i - 1, j - 2]) { attacks++; } }
                catch (IndexOutOfRangeException) { }

                try { if (board[i, j] == board[i - 1, j + 2]) { attacks++; } }
                catch (IndexOutOfRangeException) { }
                
                try { if (board[i, j] == board[i + 1, j - 2]) { attacks++; } }
                catch (IndexOutOfRangeException) { }
                
                try { if (board[i, j] == board[i + 1, j + 2]) { attacks++; } }
                catch (IndexOutOfRangeException) { }
                
                try { if (board[i, j] == board[i + 2, j - 1]) { attacks++; } }
                catch (IndexOutOfRangeException) { }
                
                try { if (board[i, j] == board[i + 2, j + 1]) { attacks++; } }
                catch (IndexOutOfRangeException) { }

                if (attacks >= mostAttacks)
                {
                    mostAttacks = attacks;
                    attackerPosition[0] = i;
                    attackerPosition[1] = j;
                }
            }
        }
    }

    if (mostAttacks>0)
    {
        removedAttackers++;
        board[attackerPosition[0], attackerPosition[1]] = '0';
    }
}


Console.WriteLine(removedAttackers);


