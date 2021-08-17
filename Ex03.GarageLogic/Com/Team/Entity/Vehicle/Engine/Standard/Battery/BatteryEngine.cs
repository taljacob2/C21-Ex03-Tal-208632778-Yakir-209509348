namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Battery
{
    public class BatteryEngine : StandardEngine
    {
        public BatteryEngine(float i_CapacityInHours)
        {
            CapacityInHours = i_CapacityInHours;
        }

        /// <summary>
        ///     Measured in `Hour` units.
        /// </summary>
        public float CapacityInHours { get; }
    }
}
