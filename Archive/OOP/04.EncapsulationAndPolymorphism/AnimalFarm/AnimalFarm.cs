namespace AnimalFarm
{
    using System;

    public class AnimalFarm
    {
        public static void Main()
        {
            Chicken chicken = new Chicken("Mara", 3);
            chicken.ProduceProduct();
            Console.WriteLine(chicken.ProductPerDay);
        }
    }
}
