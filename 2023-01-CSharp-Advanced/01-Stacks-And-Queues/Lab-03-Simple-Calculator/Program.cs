string[] input = Console.ReadLine().Split();
string[] reversedInput = input.Reverse().ToArray();
Stack<string> stack = new Stack<string>(reversedInput);
int sum = int.Parse(stack.Pop());

while (stack.Count > 0)
{
    if (stack.Pop() == "+")
    {
        sum += int.Parse(stack.Pop());
    }
    else
    {
        sum -= int.Parse(stack.Pop());
    }
}

Console.WriteLine(sum);
