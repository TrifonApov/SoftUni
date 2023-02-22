using System;
using System.Collections.Generic;
using System.Linq;

int pumpsCount = int.Parse(Console.ReadLine());
Queue<int> fuelToLoad = new();
Queue<int> kmToNextPump = new();

for (int i = 0; i < pumpsCount; i++)
{
    int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    fuelToLoad.Enqueue(tokens[0]);
    kmToNextPump.Enqueue(tokens[1]);
}

int loadedFuel = 0;
int startingPosition = 0;
int currentPosition = 0;

for (int i = startingPosition; i < pumpsCount+startingPosition; i++)
{
    loadedFuel += fuelToLoad.Peek();
    
    if (loadedFuel < kmToNextPump.Peek())
    {
        startingPosition++;
        for (int j = 0; j < pumpsCount-startingPosition; j++)
        {
            fuelToLoad.Enqueue(fuelToLoad.Dequeue());
            kmToNextPump.Enqueue(kmToNextPump.Dequeue());
        }
        currentPosition = startingPosition;
        loadedFuel = 0;
        continue;
    }

    loadedFuel -= kmToNextPump.Peek();
    fuelToLoad.Enqueue(fuelToLoad.Dequeue());
    kmToNextPump.Enqueue(kmToNextPump.Dequeue());
    currentPosition++;
}

Console.WriteLine(startingPosition);