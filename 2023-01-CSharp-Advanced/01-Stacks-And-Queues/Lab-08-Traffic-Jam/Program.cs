int passingOnGreen = int.Parse(Console.ReadLine());
string carCommand = Console.ReadLine();

int passedCars = 0;
Queue<string> cars = new Queue<string>();

while (carCommand != "end")
{
    if (carCommand != "green")
    {
        cars.Enqueue(carCommand);
    }
    else
    {
        for (int i = 0; i < passingOnGreen && cars.Count > 0; i++)
        {
            Console.WriteLine($"{cars.Dequeue()} passed!");
            passedCars++;
        }
    }
    carCommand = Console.ReadLine();
}
Console.WriteLine($"{passedCars} cars passed the crossroads.");