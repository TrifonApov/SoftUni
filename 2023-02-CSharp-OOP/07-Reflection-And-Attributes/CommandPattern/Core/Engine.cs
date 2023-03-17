using System;
using System.Linq;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core;

public class Engine : IEngine
{
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter command)
    {
        commandInterpreter = command;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string result = commandInterpreter.Read(input);
            
                Console.WriteLine(result);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                Console.WriteLine(invalidOperationException.Message);
            }
        }
    }
}