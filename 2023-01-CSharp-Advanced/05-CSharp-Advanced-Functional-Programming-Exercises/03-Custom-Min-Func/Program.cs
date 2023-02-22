Func<int[], int> minNumber = numberss =>
{
    int minNumber = int.MaxValue;
    foreach (int number in numberss)
    {
        if (number < minNumber)
            minNumber = number;
    }

    return minNumber;
};

int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.None).Select(int.Parse).ToArray();

Console.WriteLine(minNumber(numbers));


//static int MinNumber(int[] numbers)
//{
//    int minNumber = int.MaxValue;
//    foreach (int number in numbers)
//    {
//        if (number < minNumber)
//            minNumber = number;
//    }

//    return minNumber;
//}