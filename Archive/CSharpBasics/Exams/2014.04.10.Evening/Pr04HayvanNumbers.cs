using System;

class Pr54HayvanNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        bool isFound = false;

        for (int a = 5; a <= 9; a++)
        {
            for (int b = 5; b <= 9; b++)
            {
                for (int c = 5; c <= 9; c++)
                {
                    int abc = a * 100 + b * 10 + c;
                    for (int d = 5; d <= 9; d++)
                    {
                        for (int e = 5; e <= 9; e++)
                        {
                            for (int f = 5; f <= 9; f++)
                            {
                                int def = d * 100 + e * 10 + f;
                                for (int g = 5; g <= 9; g++)
                                {
                                    for (int h = 5; h <= 9; h++)
                                    {
                                        for (int i = 5; i <= 9; i++)
                                        {
                                            int ghi = g * 100 + h * 10 + i;
                                            int abcdefghi = a + b + c + d + e + f + g + h + i;
                                            if (abc <= def & def <= ghi)
                                            {
                                                if (abcdefghi == sum &&
                                                    ghi - def == diff &&
                                                    def - abc == diff)
                                                {
                                                    Console.WriteLine("{0}{1}{2}", abc, def, ghi);
                                                    isFound = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!isFound)
        {
            Console.WriteLine("No");
        }
    }
}