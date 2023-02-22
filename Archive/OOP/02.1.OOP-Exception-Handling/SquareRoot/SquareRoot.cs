namespace SquareRoot
{
    using System;

    class SquareRoot
    {
        static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "number",
                        "Value cannot be negative.");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
