namespace _05_Date_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string d1 = Console.ReadLine();
            string d2 = Console.ReadLine();

            var tsBetweenDates = DateModifier.CalculateDifferenceBetweenDates(d1, d2);

            Console.WriteLine($"{tsBetweenDates.Days}");
        }
    }
}