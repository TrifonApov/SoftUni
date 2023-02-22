int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> numbers = new Stack<int>(inputNumbers);

for (int i = 0; i < commands[1]; i++)
{
    numbers.Pop();
}

if (numbers.Contains(commands[2]))
{
    Console.WriteLine("true");
}
else
{
    int minNumber = Int32.MaxValue;
    if (numbers.Count == 0)
    {
        minNumber = 0;
    }
    while (numbers.Count > 0)
    {
        int currentNumber = numbers.Pop();
        if (currentNumber < minNumber)
        {
            minNumber = currentNumber;
        }
    }

    Console.WriteLine(minNumber);
}