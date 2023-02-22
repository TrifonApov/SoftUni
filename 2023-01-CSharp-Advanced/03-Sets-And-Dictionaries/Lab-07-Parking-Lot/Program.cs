using System;
using System.Collections.Generic;

HashSet<string> cars = new HashSet<string>();
string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

while (input[0] != "END")
{
    string command = input[0];
    string carNumber = input[1];

    switch (command)
    {
        case "IN":
            cars.Add(carNumber);
            break;
        case "OUT":
            cars.Remove(carNumber);
            break;
    }



    input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
}

if (cars.Count > 0)
{
    foreach (string car in cars)
    {
        Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}