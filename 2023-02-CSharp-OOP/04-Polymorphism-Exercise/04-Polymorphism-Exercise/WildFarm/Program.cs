using WildFarm.Core;
using WildFarm.Factory;
using WildFarm.Factory.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalFactory();

            Engine engine = new Engine(reader, writer, animalFactory);

            engine.Run();
        }
    }
}