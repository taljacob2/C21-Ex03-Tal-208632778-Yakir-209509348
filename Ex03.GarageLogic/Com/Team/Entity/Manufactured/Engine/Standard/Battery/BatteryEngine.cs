using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard.Battery
{
    public sealed class BatteryEngine : StandardEngine
    {
        /// <summary>
        ///     Note: Capacity is measured in `Hour` units.
        /// </summary>
        /// <param name="i_ManufacturerMaxCapacityInHours">
        ///     Sets the <see cref="Manufactured.ManufacturerMaxValue" />
        /// </param>
        public BatteryEngine(float i_ManufacturerMaxCapacityInHours)
        {
            ManufacturerMaxValue = i_ManufacturerMaxCapacityInHours;
        }

        public void AddCharge(float i_MinutesToAdd)
        {
            AddSelfValue(i_MinutesToAdd);
        }
        
        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
