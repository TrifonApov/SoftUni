using System;
using System.Numerics;
using System.Linq;
class LargestProductOfDigits
{
    static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine());
        string num = input.ToString();
        int[] digits = new int[num.Length];
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            BigInteger digit = input % 10;
            input /= 10;
            digits[i] = (int)digit;
        }

        int maxProduct = int.MinValue;
        
        for (int i = 0; i <= digits.Length - 6; i++)
        {
            int product = 1;
            for (int j = i; j <= i + 5; j++)
            {
                product = product * digits[j];
            }
            if (product >= maxProduct)
            {
                maxProduct = product;
            }
        }
        Console.WriteLine(maxProduct);
    }
}
