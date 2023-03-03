using Telephony.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : ICall
{
    public string Call(string number)
    {
        return $"Dialing... {number}";
    }
}