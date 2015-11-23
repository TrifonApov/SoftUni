namespace PcCatalog
{
    using System.Collections.Generic;
    using System.Linq;

    public class PcCatalog
    {
        private ICollection<Computer> computers;

        public PcCatalog()
        {
            this.Computers = new HashSet<Computer>();
        }

        public ICollection<Computer> Computers
        {
            get { return this.computers; }
            set { this.computers = value; }
        }

    }
}