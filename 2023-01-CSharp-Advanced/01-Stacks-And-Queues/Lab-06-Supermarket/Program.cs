string input = Console.ReadLine();
Queue<string> customers = new Queue<string>();

while (input != "End")
{
    if (input != "Paid")
    {
        customers.Enqueue(input);
    }
    else
    {
        while (customers.Count > 0)
        {
            Console.WriteLine(customers.Dequeue());
        }
    }

    input = Console.ReadLine();
}

int remainingCustomers = customers.Count;
Console.WriteLine($"{remainingCustomers} people remaining.");