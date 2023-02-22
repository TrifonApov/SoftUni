using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.Members = new List<Person>();
        }

		public List<Person> Members { get; set; }

        public void AddMember(Person person)
        {
            this.Members.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
        }
	}
}
