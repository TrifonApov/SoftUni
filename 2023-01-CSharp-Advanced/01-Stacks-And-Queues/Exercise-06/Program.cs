int[] inputValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> clothes = new Stack<int>(inputValues);
int rackCapacity = int.Parse(Console.ReadLine());
int racks = 0;

while (clothes.Count > 0)
{
    racks++;
    int sum = clothes.Pop();
    if (clothes.Count <= 0) break;
    var peek = clothes.Peek() + sum;
    while (sum < rackCapacity && peek <= rackCapacity && clothes.Count > 0)
    {
        sum += clothes.Pop();
        if (clothes.Count <= 0) break;
        peek = clothes.Peek() + sum;
    }
}

Console.WriteLine(racks);