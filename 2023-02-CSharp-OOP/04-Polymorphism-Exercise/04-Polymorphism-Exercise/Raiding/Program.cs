using Raiding.Core;
using Raiding.Factory;
using Raiding.Factory.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding;

public class Program
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IHeroFactory heroFactory = new HeroFactory();

        Engine engine = new Engine(reader, writer, heroFactory);
        
        engine.Run();
    }
}

