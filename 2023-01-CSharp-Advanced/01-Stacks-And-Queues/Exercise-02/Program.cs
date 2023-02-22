int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> numbers = new Queue<int>(inputNumbers);

for (int i = 0; i < commands[1]; i++)
{
    numbers.Dequeue();
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
        int currentNumber = numbers.Dequeue();
        if (currentNumber < minNumber)
        {
            minNumber = currentNumber;
        }
    }

    Console.WriteLine(minNumber);
}