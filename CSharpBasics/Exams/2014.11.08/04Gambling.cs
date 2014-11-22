using System;

class Problem04
{
    static void Main()
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        string[] houseHand = Console.ReadLine().Split(' ');
        for (int i = 0; i < houseHand.Length; i++)
        {
            if (houseHand[i] == "A")
            {
                houseHand[i] = "14";
            }
            if (houseHand[i] == "K")
            {
                houseHand[i] = "13";
            }
            if (houseHand[i] == "Q")
            {
                houseHand[i] = "12";
            }
            if (houseHand[i] == "J")
            {
                houseHand[i] = "11";
            }

        }
        decimal[] houseHandInt = Array.ConvertAll(houseHand, decimal.Parse);
        decimal houseHandStreght = decimal.Parse(houseHand[0]) + decimal.Parse(houseHand[1]) + decimal.Parse(houseHand[2]) + decimal.Parse(houseHand[3]);
        decimal winners = 0;
        decimal allHand = 0;

        for (int c1 = 2; c1 <= 14; c1++)
        {
            for (int c2 = 2; c2 <= 14; c2++)
            {
                for (int c3 = 2; c3 <= 14; c3++)
                {
                    for (int c4 = 2; c4 <= 14; c4++)
                    {
                        allHand++;
                        if (c1 + c2 + c3 + c4 > houseHandStreght)
                        {
                            winners++;
                        }
                        
                    }
                }
            }
        }
        decimal chanceToWin = winners / allHand;
        if (chanceToWin < 0.5m)
        {
            Console.WriteLine("FOLD");
            Console.WriteLine("{0:0.00}", cash * 2 * chanceToWin);
        }
        else
        {
            Console.WriteLine("DRAW");
            Console.WriteLine("{0:0.00}", cash * 2 * chanceToWin);
        }
    }
}
