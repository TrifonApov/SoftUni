using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[rows][];

for (int i = 0; i < rows; i++)
{
    jaggedArray[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}

string commandInput = Console.ReadLine();

while (commandInput != "END")
{
    string[] commandTokens = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    string command = commandTokens[0];
    int rowToChange = int.Parse(commandTokens[1]);
    int colToChange = int.Parse(commandTokens[2]);
    int value = int.Parse(commandTokens[3]);

    switch (command)
    {
        case "Add":
            try
            {
                jaggedArray[rowToChange][colToChange] += value;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Invalid coordinates");
            }
            break;
        case "Subtract":
            try
            {
                jaggedArray[rowToChange][colToChange] -= value;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Invalid coordinates");
            }
            break;
    }
    
    commandInput = Console.ReadLine();
}

foreach (int[] ints in jaggedArray)
{
    Console.WriteLine(string.Join(" ", ints));
}