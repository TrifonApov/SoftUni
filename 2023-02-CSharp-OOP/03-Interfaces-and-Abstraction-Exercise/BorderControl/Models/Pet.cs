using System;

namespace BorderControl.Models
{
    public class Pet : IBirthday
    {
        private string name;
        private DateTime birthDay;

        public Pet(string name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public DateTime BirthDay
        {
            get => birthDay;
            set => birthDay = value;
        }
    }
}