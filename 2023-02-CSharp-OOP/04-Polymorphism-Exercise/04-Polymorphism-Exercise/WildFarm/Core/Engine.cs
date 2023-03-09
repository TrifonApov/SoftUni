using WildFarm.Core.Interfaces;
using WildFarm.Factory.Interfaces;
using WildFarm.IO.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IAnimalFactory heroFactory;

    public Engine(IReader reader, IWriter writer, IAnimalFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;
    }

    public void Run()
    {
        
    }
}