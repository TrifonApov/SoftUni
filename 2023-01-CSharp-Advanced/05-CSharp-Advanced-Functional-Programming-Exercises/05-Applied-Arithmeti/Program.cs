using System;
using System.Linq;

Action<int[]> printResult = numbers => Console.WriteLine(string.Join(" ", numbers));

Func<string, int[], int[]> manipulateNumbers = (command, numbers) =>
{
    int[] result = new int[numbers.Length];

    for (int i = 0; i < numbers.Length; i++)
    {
        switch (command)
        {
            case "add":
                result[i] = numbers[i] + 1;
                break;
            case "multiply":
                result[i] = numbers[i] * 1;
                break;
            case "subtract":
                result[i] = numbers[i] - 1;
                break;
        }
    }

    return result;
};

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string command = Console.ReadLine();
while (command != "end")
{
    if (command == "print")
    {
        printResult(numbers);
    }
    else
    {
        numbers = manipulateNumbers(command, numbers);
    }

    command = Console.ReadLine();
}