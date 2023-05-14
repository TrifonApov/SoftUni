namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const int CargoVanMaxMileage = 450;
        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, CargoVanMaxMileage, licensePlateNumber)
        {
        }
    }
}