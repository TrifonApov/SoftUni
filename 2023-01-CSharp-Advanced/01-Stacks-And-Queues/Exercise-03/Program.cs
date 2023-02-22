int n = int.Parse(Console.ReadLine());

Stack<int> numbers = new Stack<int>();
for (int i = 0; i < n; i++)
{
    int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();

    switch (query[0])
    {
        case 1:
            numbers.Push(query[1]);
            break;
        
        case 2:
            if (numbers.Count > 0)
            {
                numbers.Pop();
            }
            break;
        
        case 3:
            if (numbers.Count > 0)
            {
                int max = numbers.ToArray().Max();
                Console.WriteLine(max);
            }
            break;
        
        case 4:
            if (numbers.Count > 0)
            {
                int min = numbers.ToArray().Min();
                Console.WriteLine(min);
            }
            break;
    }

}

Console.WriteLine(string.Join(", ", numbers));