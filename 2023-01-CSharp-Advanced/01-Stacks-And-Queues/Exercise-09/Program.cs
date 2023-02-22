using System;
using System.Collections.Generic;

string text = "";
int numberOfOperations = int.Parse(Console.ReadLine());
Stack<string[]> undoneCommands = new();

for (int i = 0; i < numberOfOperations; i++)
{
    string[] currentCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    switch (currentCommand[0])
    {
        case "1":
            text += currentCommand[1];
            undoneCommands.Push(currentCommand);
            break;
        case "2":
            string erasedText = text.Substring(text.Length - int.Parse(currentCommand[1]));
            text = text.Substring(0, text.Length - int.Parse(currentCommand[1]));
            undoneCommands.Push( new []{"2", erasedText});
            break;
        case "3":
            Console.WriteLine(text[int.Parse(currentCommand[1])-1]);
            break;
        case "4":
            string[] undoCommand = undoneCommands.Pop();
            switch (undoCommand[0])
            {
                case "1":
                    string stringToRemove = undoCommand[1];
                    text = text.Remove(text.LastIndexOf(stringToRemove));
                    break;
                case "2":
                    text += undoCommand[1];
                    break;
            }
            break;
    }

}

