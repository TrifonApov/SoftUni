using System;

class Gambling
{
    static void Main()
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        string[] houseHand = Console.ReadLine().Split();
        int houseStrength = 0;
        foreach (var card in houseHand)
        {
            switch (card)
            {
                case "J": houseStrength += 11; break;
                case "Q": houseStrength += 12; break;
                case "K": houseStrength += 13; break;
                case "A": houseStrength += 14; break;
                default: houseStrength += int.Parse(card); break;
            }
        }
        int totalHands = 0;
        int winners = 0;
        for (int card1 = 2; card1 <= 14; card1++)
        {
            for (int card2 = 2; card2 <= 14; card2++)
            {
                for (int card3 = 2; card3 <= 14; card3++)
                {
                    for (int card4 = 2; card4 <= 14; card4++)
                    {
                        totalHands++;
                        int currHand = card1 + card2 + card3 + card4;
                        if (houseStrength < currHand)
                        {
                            winners++;
                        }
                    }
                }
            }
        }
        double ratio = (double)winners / totalHands;
        Console.WriteLine(ratio < 0.5 ? "FOLD" : "DRAW");
        Console.WriteLine("{0:F2}",(decimal)ratio * 2 *cash);
        

    }
}
