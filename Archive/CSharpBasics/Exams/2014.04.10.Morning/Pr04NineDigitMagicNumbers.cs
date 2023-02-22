using System;

class Pr04NineDigitMagicNumbers
{
    static void Main()
    {
        ulong sum = ulong.Parse(Console.ReadLine());
        ulong diff = ulong.Parse(Console.ReadLine());
        ulong abc = 0;
        ulong def = 0;
        ulong ghi = 0;
        bool isFound = false;
        for (int a = 1; a <= 7; a++)
        {
            for (int b = 1; b <= 7; b++)
            {
                for (int c = 1; c <= 7; c++)
                {
                    abc = (ulong)(a * 100 + b * 10 + c);
                    for (int d = 1; d <= 7; d++)
                    {
                        for (int e = 1; e <= 7; e++)
                        {
                            for (int f = 1; f <= 7; f++)
                            {
                                def = (ulong)(d * 100 + e * 10 + f);
                                for (int g = 1; g <= 7; g++)
                                {
                                    for (int h = 1; h <= 7; h++)
                                    {
                                        for (int i = 1; i <= 7; i++)
                                        {
                                            ghi = (ulong)(g * 100 + h * 10 + i);
                                            if (abc <= def && def <= ghi)
                                            {
                                                if (ghi - def == diff && 
                                                    def - abc == diff && 
                                                    (ulong)(a + b + c + d + e + f + g + h + i) == sum)
                                                {
                                                    Console.WriteLine("{0}{1}{2}", abc,def,ghi);
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