namespace Humans.Models
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName,decimal weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary", "Salary cannot be negative.");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 1 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("WorkHourPerDay", "Work hours per day cannot be zero or more than 24.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return (this.WeekSalary / 5) / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}{2}",
                this.GetType().Name.PadRight(7),
                (this.FirstName + " " + this.LastName).PadRight(20, '-'),
                this.MoneyPerHour().ToString("C3").PadLeft(15,'-'));
        }
    }
}