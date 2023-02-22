using System;
using System.Collections.Generic;
using System.Linq;

string inputData = Console.ReadLine();
List<Vlogger> vloggers = new List<Vlogger>();
while (inputData != "Statistics")
{
    string[] info = inputData.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vloggerName = info[0];
    string command = info[1];
    string commandTarget = info[2];

    if (command == "joined")
    {
        if (!vloggers.Any(x => x.Name == vloggerName))
        {
            vloggers.Add(
                new Vlogger
                {
                    Name = vloggerName,
                    Followers = new(),
                    Following = new()
                });
        }
    }
    else
    {
        if (!vloggers.Any(x => x.Name == vloggerName) || !vloggers.Any(x => x.Name == commandTarget))
        {
            inputData = Console.ReadLine();
            continue;
        }

        if (vloggerName == commandTarget)
        {
            inputData = Console.ReadLine();
            continue;
        }
        vloggers.First(x => x.Name == vloggerName).Following.Add(commandTarget);
        vloggers.First(x => x.Name == commandTarget).Followers.Add(vloggerName);
    }

    inputData = Console.ReadLine();
}

Vlogger mostFollowed = vloggers.OrderByDescending(x=>x.Followers.Count).ThenBy(x=>x.Following.Count).First();
List<Vlogger> sortedVloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();

Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
Console.WriteLine($"1. {mostFollowed.Name} : {mostFollowed.Followers.Count} followers, {mostFollowed.Following.Count} following");

foreach (string mostFollowedFollower in mostFollowed.Followers)
{
    Console.WriteLine($"*  {mostFollowedFollower}");
}

int count = 2;
foreach (Vlogger vlogger in sortedVloggers)
{
    if (vlogger == mostFollowed)
    {
        continue;
    }

    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

    count++;
}




class Vlogger
{
    public string Name { get; set; }
    public SortedSet<string> Followers { get; set; }
    public SortedSet<string> Following { get; set; }
}