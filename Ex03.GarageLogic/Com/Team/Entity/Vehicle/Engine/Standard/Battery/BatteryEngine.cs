namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Battery
{
    public sealed class BatteryEngine : StandardEngine, ISelfRecharger
    {
        /// <summary>
        ///     Note: Capacity is measured in `Hour` units.
        /// </summary>
        /// <param name="i_MaxEnergyAsCapacityInHours">
        ///     Sets the <see cref="Engine.MaxEnergy" />
        /// </param>
        public BatteryEngine(float i_MaxEnergyAsCapacityInHours)
        {
            MaxEnergy = i_MaxEnergyAsCapacityInHours;
        }

        public void RechargeSelf(float i_MinutesToAdd)
        {
            throw new System.NotImplementedException();
        }
    }
}
