using System;

class Beers
{
    static void Main(string[] args)
    {
        int allBeers = 0;
        while (true)
        {
            string[] currLine = Console.ReadLine().Split();
            if (currLine[0] == "End")
            {
                break;
            }
            int measure = int.Parse(currLine[0]);
            string singleBeers = currLine[1];

            if (singleBeers == "stacks")
            {
                allBeers += 20 * measure;
            }
            else
            {
                allBeers += measure;
            }
        }

        Console.WriteLine("{0} stacks + {1} beers", allBeers/20, allBeers%20);
    }
}
