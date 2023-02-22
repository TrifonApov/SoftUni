int leftFood = int.Parse(Console.ReadLine());
int[] customersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> customers = new Queue<int>(customersInput);
Console.WriteLine(customersInput.Max());
while (customers.Count > 0)
{
    if (customers.Peek() <= leftFood)
    {
        leftFood -= customers.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", customers)}");
        return;
    }
}

Console.WriteLine("Orders complete");