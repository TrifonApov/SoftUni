double[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n=>double.Parse(n)*1.2).ToArray();

foreach (double number in numbers)
{
    Console.WriteLine($"{number:f2}");
}
