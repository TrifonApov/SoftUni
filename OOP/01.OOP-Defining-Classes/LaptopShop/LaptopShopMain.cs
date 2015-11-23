namespace LaptopShop
{
    using System;

    class LaptopShopMain
    {
        static void Main()
        {
            Laptop laptop = new Laptop("ad",0.22m);
            Batery assBatery = new Batery("Li-Ion, 4-cells, 2550 mAh", 4.5);

            Laptop laptop2 = new Laptop(
                "Lenovo Yoga 2 Pro",
                2259m, 
                "Lenovo",
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                "8 GB",
                "Intel HD Graphics 4400",
                "128GB SSD",
                "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 
                assBatery);

            Laptop laptop3 = new Laptop("laptop3", 1202.23m, "Pravets");
            Laptop laptop4 = new Laptop("laptop4", 1202.23m, "Pravets",assBatery);
            

            Console.WriteLine(laptop.ToString());
            Console.WriteLine(laptop2.ToString());
            Console.WriteLine(laptop3.ToString());
            Console.WriteLine(laptop4.ToString());
            
        }
    }
}
