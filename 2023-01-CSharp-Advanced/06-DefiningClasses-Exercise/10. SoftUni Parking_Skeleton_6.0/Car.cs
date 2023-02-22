﻿using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        //•	Make: string
        //•	Model: string
        //•	HorsePower: int
        //•	RegistrationNumber: string

        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make,string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.Append($"RegistrationNumber: {this.RegistrationNumber}");

            return sb.ToString();
        }
    }
}
