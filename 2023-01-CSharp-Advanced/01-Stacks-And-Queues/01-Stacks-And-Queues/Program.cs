// See https://aka.ms/new-console-template for more information
string input = Console.ReadLine();

Stack<char> chars = new Stack<char>();

foreach (char letter in input)
{
    chars.Push(letter);
}

while (chars.Count > 0)
{
    Console.Write(chars.Pop());
}