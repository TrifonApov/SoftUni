using System;
using System.Linq;
using Telephony.Interfaces;

namespace Telephony.Models;

public class Smartphone : ICall, IBrowse
{
    public string Call(string number)
    {
        if (!ValidateNumber(number))
            return "Invalid number!";
        
        return $"Calling... {number}";
    }

    public string Browse(string site)
    {
        if (ValidateSite(site))
            return "Invalid URL!";

        return $"Browsing: {site}!";
    }

    private bool ValidateNumber(string number)
    {
        return number.All(char.IsDigit);
    }

    private bool ValidateSite(string site)
    {
        return site.Any(char.IsDigit);
    }
}