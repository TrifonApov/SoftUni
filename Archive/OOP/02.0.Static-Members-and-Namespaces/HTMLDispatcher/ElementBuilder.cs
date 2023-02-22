namespace HTMLDispatcher
{
    using System;
    using System.Collections.Generic;

    public class ElementBuilder : Element
    {
        public ElementBuilder(string name)
            : base(name)
        {
        }

        public void AddAttribute(string attributeName, string attributeValue)
        {
            var attribute = new Attribute(attributeName, attributeValue);
            this.attributes.Add(attribute);
        }

        public void AddContent(string contentToAdd)
        {
            this.content = contentToAdd;
        }

        public static string operator *(ElementBuilder element, int num)
        {
            List<string> elements = new List<string>();
            for (int i = 0; i < num; i++)
            {
                elements.Add(element.ToString());
            }
            return String.Join("", elements);
        }
    }
}