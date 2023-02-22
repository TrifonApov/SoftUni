Console.WriteLine(string.Join(", ", Console.ReadLine()
    .Split(", ", StringSplitOptions.None)
    .Select(int.Parse)
    .Where(n => n % 2 == 0)
    .OrderBy(n => n)));