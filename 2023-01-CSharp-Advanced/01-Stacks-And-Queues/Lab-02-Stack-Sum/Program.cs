string initialNumbersInput = Console.ReadLine();
int[] initialInput = initialNumbersInput.Split(' ').Select(int.Parse).ToArray();
Stack<int> numbersStack = new Stack<int>(initialInput);

string command = Console.ReadLine().ToLower();
while (command != "end")
{
    string[] commandParameters = command.Split();
    if (commandParameters[0] == "add")
    {
        numbersStack.Push(int.Parse(commandParameters[1]));
        numbersStack.Push(int.Parse(commandParameters[2]));
    }
    else
    {
        if (int.Parse(commandParameters[1]) > numbersStack.Count)
        {
            command = Console.ReadLine().ToLower();
            continue;
        }

        for (int i = 0; i < int.Parse(commandParameters[1]); i++)
        {
            numbersStack.Pop();
        }
    }
    command = Console.ReadLine().ToLower();
}

int stackSum = 0;
while (numbersStack.Count>0)
{
    stackSum += numbersStack.Pop();
}

Console.WriteLine($"Sum: {stackSum}");