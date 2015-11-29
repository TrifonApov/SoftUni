namespace BookStore
{
    using Engine;
    using Interfaces;
    using UI;

    public class BookStoreMain
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();

            BookStoreEngine engine = new BookStoreEngine(renderer, inputHandler);

            engine.Run();
        }
    }
}
