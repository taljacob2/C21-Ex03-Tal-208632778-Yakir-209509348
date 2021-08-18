using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Battery
{
    public sealed class BatteryEngine : StandardEngine, ISelfRecharger
    {
        /// <summary>
        ///     Note: Capacity is measured in `Hour` units.
        /// </summary>
        /// <param name="i_ManufacturerMaxEnergyAsCapacityInHours">
        ///     Sets the <see cref="Engine.ManufacturerMaxEnergy" />
        /// </param>
        public BatteryEngine(float i_ManufacturerMaxEnergyAsCapacityInHours)
        {
            ManufacturerMaxEnergy = i_ManufacturerMaxEnergyAsCapacityInHours;
        }

        public void RechargeSelf(float i_MinutesToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(ManufacturerMaxEnergy, 0);

            // Assert minimum:
            if (i_MinutesToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (ManufacturerMaxEnergy > Energy + i_MinutesToAdd)
            {
                throw exception;
            }

            Energy += i_MinutesToAdd;
        }
    }
}
