namespace GenericSwapMethod;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        //List<int> elements = new();
        List<string> elements = new();
        for (int i = 0; i < numberOfLines; i++)
        {
            //elements.Add(int.Parse(Console.ReadLine()));
            elements.Add(Console.ReadLine());
        }
        int[] swapPositions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Swap(elements, swapPositions[0], swapPositions[1]);
        foreach (var element in elements)
        {
            Console.WriteLine($"{element.GetType()}: {element}");
        }
    }

    public static List<T> Swap<T>(List<T> list, int n, int m)
    {
        T first = list[n];
        T second = list[m];
        list[n] = second;
        list[m] = first;
        return list;
    }
}