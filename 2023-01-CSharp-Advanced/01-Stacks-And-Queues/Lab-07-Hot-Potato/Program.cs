string[] kids = Console.ReadLine().Split();
int tosses = int.Parse(Console.ReadLine());

Queue<string> kidsQueue = new Queue<string>(kids);

while (kidsQueue.Count > 1)
{
    for (int i = 1; i < tosses; i++)
    {
        kidsQueue.Enqueue(kidsQueue.Dequeue());
    }

    Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
    
}

Console.WriteLine($"Last is {kidsQueue.Dequeue()}");