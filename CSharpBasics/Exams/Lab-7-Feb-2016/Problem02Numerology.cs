using System;

class Numerology
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split('.', ' ');
        int day = int.Parse(input[0]);
        int month = int.Parse(input[1]);
        int year = int.Parse(input[2]);
        string username = input[3];

        long sum = day * month * year;
        
        if (month % 2 != 0)
        {
            sum *= sum;
        }

        for (int i = 0; i < username.Length; i++)
        {
            char cuffChar = username[i];
            if (cuffChar >= 'a' && cuffChar <= 'z')
            {
                sum += cuffChar - 'a' + 1;
            }
            else if (cuffChar >= 'A' && cuffChar <= 'Z')
            {
                sum += (cuffChar - 'A' + 1) * 2;
            }
            else if (cuffChar >= '0' && cuffChar <= '9')
            {
                sum += cuffChar - '0';
            }
        }

        long num = 0;
        while (sum > 13)
        {
            num = 0;
            while (sum > 0)
            {
                num += sum % 10;
                sum /= 10;
            }
            sum = num;
        }

        Console.WriteLine(num);
    }
}
