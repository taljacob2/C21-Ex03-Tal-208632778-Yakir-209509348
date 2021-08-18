namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Battery
{
    public sealed class BatteryEngine : StandardEngine
    {
        /// <summary>
        ///     Note: Capacity is measured in `Hour` units.
        /// </summary>
        /// <param name="i_MaxCapacityInHours">
        ///     Sets the <see cref="Engine.MaxEnergy" />
        /// </param>
        public BatteryEngine(float i_MaxCapacityInHours)
        {
            MaxEnergy = i_MaxCapacityInHours;
        }

    }
}
