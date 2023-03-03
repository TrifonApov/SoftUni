using System;
using Telephony.Interfaces;
using Telephony.Models;

namespace Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        ICall iCall;

        foreach (string phoneNumber in phoneNumbers)
        {
            if (phoneNumber.Length == 10)
            {
                iCall = new Smartphone();
                Console.WriteLine(iCall.Call(phoneNumber));
            }
            else if (phoneNumber.Length == 7)
            {
                iCall = new StationaryPhone();
                Console.WriteLine(iCall.Call(phoneNumber));
            }
        }

        IBrowse iBrowse;

        foreach (string site in sites)
        {
            iBrowse = new Smartphone();
            Console.WriteLine(iBrowse.Browse(site));
        }
    }

    private static bool IsAllDigits(string phoneNumber)
    {
        foreach (char ch in phoneNumber)
        {
            if (!char.IsDigit(ch))
            {
                return false;
            }
        }
        return true;
    }
}