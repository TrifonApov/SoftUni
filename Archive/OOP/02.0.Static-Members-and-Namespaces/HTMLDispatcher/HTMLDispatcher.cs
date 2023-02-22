namespace HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string source, string alt, string title)
        {
            var image = new ElementBuilder("img");
            image.AddAttribute("source",source);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title",title);
            return image;
        }

        public static ElementBuilder CreateURL(string url, string title, string text)
        {
            var urlElement = new ElementBuilder("a");
            urlElement.AddAttribute("href", url);
            urlElement.AddAttribute("title", title);
            urlElement.AddContent(text);
            return urlElement;
        }

        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            var input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", value);
            input.AddAttribute("value", value);
            var form = new ElementBuilder("form");
            form.AddContent(input.ToString().Trim());
            return form;
        }
    }
}
