namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int DefaultInterfaceStandard = 10045;
        private const int DefaultBatteryUsage = 10000;
        

        public SpecializedArm() : base(DefaultInterfaceStandard, DefaultBatteryUsage)
        {
        }
    }
}