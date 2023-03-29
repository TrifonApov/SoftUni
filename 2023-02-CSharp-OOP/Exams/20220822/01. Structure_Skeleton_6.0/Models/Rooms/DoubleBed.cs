namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int DoubleBedCapacity = 2;

        public DoubleBed() : base(DoubleBedCapacity)
        {
        }
    }
}