using System;
using System.Collections.Generic;

string parentheses = Console.ReadLine();

Stack<char> openParentheses = new();

foreach (char parenthese in parentheses)
{
    switch (parenthese)
    {
        case '{':
        case '[':
        case '(':
            openParentheses.Push(parenthese);
            break;
        default:
            if (openParentheses.Count <= 0)
            {
                Console.WriteLine("NO");
                return;
            }
            switch (parenthese)
            {
                case '}' when openParentheses.Peek() == '{':
                case ']' when openParentheses.Peek() == '[':
                case ')' when openParentheses.Peek() == '(':
                    openParentheses.Pop();
                    break;
                default:
                    Console.WriteLine("NO");
                    return;
            }
            break;
    }
}
if (openParentheses.Count > 0)
{
    Console.WriteLine("NO");
    return;
}
Console.WriteLine("YES");