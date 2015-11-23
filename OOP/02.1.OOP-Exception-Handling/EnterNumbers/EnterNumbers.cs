namespace EnterNumbers
{
    using System;
    using System.Threading;

    class EnterNumbers
    {
        private const int Count = 10;
        private const int Start = 1;
        private const int End = 100;
        static void Main()
        {
            ReadNumber(Start, End);
        }

        private static void ReadNumber(int start, int end)
        {
            int count = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter valid integer in range [{0} ... {1}]: ", start, end);
                    int number = int.Parse(Console.ReadLine());

                    if (number < start || number > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    count += 1;
                    start = number;
                    if (count == Count)
                    {
                        Console.WriteLine("Good bye!");
                        break;
                    }

                }
                catch (FormatException)
                {
                    Console.Write("Invalid number. Enter a valid integer number: ");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.Write("Number should be in the range [{0} ... {1}]. Try again: ", start, end);
                }
            }
        }
    }
}

