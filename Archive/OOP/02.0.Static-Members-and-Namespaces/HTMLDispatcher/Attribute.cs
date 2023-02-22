namespace HTMLDispatcher
{
    using System;

    public class Attribute
    {
        private string name;
        private string value;

        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}=\"{1}\"",
                this.name,
                this.value);
        }
    }
}