int[] numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Console.WriteLine(numbers.Length);
Console.WriteLine(numbers.Sum());