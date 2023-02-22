string expression = Console.ReadLine();

Stack<int> bracketsPositions = new Stack<int>();

for (int i = 0; i < expression.Length; i++)
{
    if (expression[i] == '(')
    {
        bracketsPositions.Push(i);
    }
    else if (expression[i] == ')')
    {
        string output = "";
        int startPosition = bracketsPositions.Pop();
        for (int j = startPosition; j <= i; j++)
        {
            output += expression[j];
        }

        Console.WriteLine(output);
    }
}