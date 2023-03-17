using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] arguments = args.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        string commandName = arguments[0];

        string[] commandArguments = arguments.Skip(1).ToArray();

        Type commandType = Assembly
            .GetEntryAssembly()
            .GetTypes()
            .FirstOrDefault(t=>t.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new InvalidOperationException("Command not found.");
        }

        ICommand command = Activator.CreateInstance(commandType) as ICommand;
        

        return command.Execute(commandArguments);
    }
}