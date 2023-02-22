using System;
using System.Numerics;
class Problem02
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        string[] date = input[0].Split('.');
        BigInteger day = BigInteger.Parse(date[0]);
        BigInteger month = BigInteger.Parse(date[1]);
        BigInteger year = BigInteger.Parse(date[2]);
        string name = input[1];

        BigInteger weight = (BigInteger)(day * month * year);
        if (month % 2 == 1)
        {
            weight = weight * weight;
        }
        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] >= 'A' && name[i] <= 'Z')
            {
                weight += (BigInteger)((name[i] - 'A' + 1) * 2);
            }
            else if (name[i] >= 'a' && name[i] <= 'z')
            {
                weight += (BigInteger)(name[i] - 'a' + 1);
            }
            else if (name[i] >= '0' && name[i] <= '9')
            {
                weight += (BigInteger)(name[i] - '0');
            }
        }
        BigInteger digit = 0;
        BigInteger celestial = 0;
        BigInteger result = 0;
        while (weight >= 1)
        {
            digit = weight % 10;
            weight /= 10;
            celestial += digit;
            result = celestial;
        }
        //result = 1999;

        while (result > 13)
        {
            result = (result / 1000) + (result / 100) % 10 + (result / 10) % 10 + (result % 10);
        }
        Console.WriteLine(result);
    }
}
