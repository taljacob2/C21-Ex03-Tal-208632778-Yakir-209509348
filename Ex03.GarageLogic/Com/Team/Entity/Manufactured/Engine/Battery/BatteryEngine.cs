using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery
{
    public sealed class BatteryEngine : Engine
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

        public void AddMinutes(float i_MinutesToAdd)
        {
            const int k_MinutesInAnHour = 60;
            float hoursToAdd = i_MinutesToAdd / k_MinutesInAnHour;
            AddSelfValue(hoursToAdd); // Adding hours here.
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
