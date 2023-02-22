using System;

class AccountInformation
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int clientID = int.Parse(Console.ReadLine());
        decimal accountBalance = decimal.Parse(Console.ReadLine());
        string active = "yes";
        Console.WriteLine("Hello, {0} {1}", firstName, lastName);
        Console.WriteLine("Client id: {0}", clientID);
        Console.WriteLine("Total balance: {0:0.00}", accountBalance);
        if (accountBalance<0)
        {
            active = "no";
        }
        Console.WriteLine("Active: {0}", active);
    }
}
