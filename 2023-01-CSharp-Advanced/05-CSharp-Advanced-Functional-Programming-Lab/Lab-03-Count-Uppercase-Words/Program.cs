Console.WriteLine(
    string.Join("\n", 
        Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(w => Char.IsUpper(w[0]))));