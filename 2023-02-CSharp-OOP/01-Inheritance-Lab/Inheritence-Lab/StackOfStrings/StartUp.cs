using System.Collections.Generic;

namespace CustomStack;
public class StartUp
{
    static void Main(string[] args)
    {
        StackOfStrings customStack = new();
        customStack.Push("-3");
        customStack.Push("-2");
        customStack.Push("-1");
        customStack.Push("0");
        Stack<string> stack = new();
        stack.Push("1");
        stack.Push("2");
        stack.Push("3");
        stack.Push("4");
        stack.Push("5");
        stack.Push("6");

        customStack.AddRange(stack);
    }
}