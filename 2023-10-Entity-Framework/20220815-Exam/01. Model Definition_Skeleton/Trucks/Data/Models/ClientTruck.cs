namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int TruckId { get; set; }

        public Truck Truck { get; set; }
    }
}
