using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }


        public bool AddChild(Child child)
        {
            if (Capacity == Registry.Count)
            {
                return false;
            }
            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] separateName = childFullName.Split(" ");
            Child childToRemove = Registry.FirstOrDefault(c => c.FirstName == separateName[0] && c.LastName == separateName[1]);
            return Registry.Remove(childToRemove);
        }

        public int ChildrenCount
        {
            get => Registry.Count;
        }

        public Child GetChild(string childFullName)
        {
            string[] separateName = childFullName.Split(" ");
            Child child = Registry.FirstOrDefault(c => c.FirstName == separateName[0] && c.LastName == separateName[1]);
            return child;
        }

        public string RegistryReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Registered children in {Name}:");
            foreach (Child child in Registry.OrderByDescending(c=>c.Age).ThenBy(c=>c.LastName).ThenBy(c=>c.FirstName))
            {
                report.AppendLine(child.ToString());
            }
            return report.ToString().Trim();
        }
    }
}
