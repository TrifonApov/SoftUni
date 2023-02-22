Action<string> print = PrintNames;
string[] names = Console.ReadLine().Split(" ", StringSplitOptions.None);

Array.ForEach(names, n => print(n));


static void PrintNames(string name)
{
    Console.WriteLine($"Sir {name}");
}