namespace PcCatalog
{
    using System;
    using System.Linq;

    class PcCatalogMain
    {
        public static void Main()
        {

            Computer myPc = new Computer("Lenovo G50-30");
            myPc.Components.Add(new Component("Motherboard", 100.99m));
            myPc.Components.Add(new Component("Video card", 100.99m, "Nqkva typa det si balo mamata"));
            myPc.Components.Add(new Component("RAM", 100.99m, "4 GB"));
            myPc.Components.Add(new Component("Processor", 100.99m, "Intel Celeron 2 x 2,16 GHz"));
            myPc.Components.Add(new Component("Storage", 100.99m, "264 GB SSD"));
            myPc.Components.Add(new Component("Additional Storage", 100.99m, "HDD 1TB"));

            Computer myPc1 = new Computer("Lenovo G50-30");
            myPc1.Components.Add(new Component("Motherboard", 200.99m));
            myPc1.Components.Add(new Component("Video card", 120.99m, "Nqkva typa det si balo mamata"));
            myPc1.Components.Add(new Component("RAM", 102.99m, "4 GB"));
            myPc1.Components.Add(new Component("Processor", 100.99m, "Intel Celeron 2 x 2,16 GHz"));
            myPc1.Components.Add(new Component("Storage", 100.99m, "264 GB SSD"));
            myPc1.Components.Add(new Component("Additional Storage", 100.99m, "HDD 1TB"));

            Computer myPc2 = new Computer("My computer 2");
            myPc2.Components.Add(new Component("Motherboard", 200.99m));
            myPc2.Components.Add(new Component("Video card", 120.99m, "Nqkva typa det si balo mamata"));
            myPc2.Components.Add(new Component("RAM", 102.99m, "4 GB"));
            myPc2.Components.Add(new Component("Processor", 100.99m, "Intel Celeron 2 x 2,16 GHz"));
            myPc2.Components.Add(new Component("Storage", 100.99m, "264 GB SSD"));
            myPc2.Components.Add(new Component("Additional Storage", 100.99m, "HDD 1TB"));

            PcCatalog catalog = new PcCatalog();
            catalog.Computers.Add(myPc);
            catalog.Computers.Add(myPc1);
            catalog.Computers.Add(myPc2);

            foreach (var comp in catalog.Computers
                .OrderByDescending(c => c.Price)
                .ThenBy(c => c.Name))
            {
                Console.WriteLine(comp.ToString());
            }
        }
    }
}
