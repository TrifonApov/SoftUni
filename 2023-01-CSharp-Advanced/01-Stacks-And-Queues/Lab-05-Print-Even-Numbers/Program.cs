string[] input = Console.ReadLine().Split();
Queue<int> numbers = new Queue<int>();
foreach (string s in input)
{
    numbers.Enqueue(int.Parse(s));
}

List<int> evenNumbers = new List<int>();
while (numbers.Count > 0)
{
    int currernNumber = numbers.Dequeue();
    if (currernNumber % 2 == 0)
    {
        evenNumbers.Add(currernNumber);
    }
}

Console.WriteLine(string.Join(", ", evenNumbers));