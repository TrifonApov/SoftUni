namespace HTMLDispatcher
{
    using System;

    public class HTMLDispatcherMain
    {
        public static void Main()
        {
            ElementBuilder div =
            new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div);

            Console.WriteLine(div * 2);

            var image = HTMLDispatcher.CreateImage("image.jpg", "nekaf pic", "Picture");
            Console.WriteLine(image.ToString());

            var url = HTMLDispatcher.CreateURL(@"https://softuni.bg", "SoftUni", "SoftUni");
            Console.WriteLine(url.ToString());

            var input = HTMLDispatcher.CreateInput("submit", "submit", "OK");
            Console.WriteLine(input.ToString());
        }
    }
}