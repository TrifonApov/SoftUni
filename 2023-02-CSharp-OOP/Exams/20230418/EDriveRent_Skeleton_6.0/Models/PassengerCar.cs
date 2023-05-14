namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        private const int PassengerCarMaxMileage = 450;
        public PassengerCar(string brand, string model, string licensePlateNumber) 
            : base(brand, model, PassengerCarMaxMileage, licensePlateNumber)
        {
        }
    }
}