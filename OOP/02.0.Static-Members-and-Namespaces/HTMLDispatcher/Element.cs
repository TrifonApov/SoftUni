namespace HTMLDispatcher
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Element
    {
        protected string name;
        protected List<Attribute> attributes;
        protected string content;

        public Element(string name)
        {
            this.name = name;
            this.attributes = new List<Attribute>();
            this.content = null;
        }

        public override string ToString()
        {
            StringBuilder element = new StringBuilder();
            element.AppendFormat("<{0}", this.name);
            
            if (this.attributes.Any())
            {
                foreach (var attribute in this.attributes)
                {
                    element.AppendFormat(" {0}",
                        attribute.ToString());
                }
            }

            if (string.IsNullOrWhiteSpace(this.content))
            {
                element.Append(">\n");
            }
            else
            {
                element.AppendFormat(">\n    {0}\n</{1}>\n",
                    this.content,
                    this.name);
            }

            return element.ToString();
        }
    }
}