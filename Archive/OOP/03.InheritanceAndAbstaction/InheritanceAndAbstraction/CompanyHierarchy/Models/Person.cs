namespace CompanyHierarchy.Models
{
    using Interfaces;

    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                Validation.Validate.IsNegative("Id", value);
                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                Validation.Validate.IsNullOrEmpty("First name", value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                Validation.Validate.IsNullOrEmpty("Last name", value);
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2}", this.Id, this.FirstName, this.LastName);
        }
    }
}