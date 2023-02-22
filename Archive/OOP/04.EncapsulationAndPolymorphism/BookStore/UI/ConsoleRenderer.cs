namespace BookStore.UI
{
    using System;
    using Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}