using System.ComponentModel;
using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard.Fuel
{
    public sealed class FuelEngine : StandardEngine
    {
        /// <summary>
        ///     Note: Capacity is measured in `Liter` units.
        /// </summary>
        /// <param name="i_ManufacturerFuelType">
        ///     Determines the Manufacturer's fuel type for this engine.
        /// </param>
        /// <param name="i_ManufacturerMaxVolumeOfFuelTankInLiters">
        ///     Sets the <see cref="Manufactured.ManufacturerMaxValue" />
        /// </param>
        public FuelEngine(eType i_ManufacturerFuelType,
            float i_ManufacturerMaxVolumeOfFuelTankInLiters)
        {
            ManufacturerFuelType = i_ManufacturerFuelType;
            ManufacturerMaxValue =
                i_ManufacturerMaxVolumeOfFuelTankInLiters;
        }

        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public eType ManufacturerFuelType { get; }

        public void AddFuel(eType i_Type, float i_Liters)
        {
            InvalidEnumArgumentException enumException =
                new InvalidEnumArgumentException(string.Format(
                    "Invalid request of Fuel-Type, Manufacturer Fuel-Type: {0}," +
                    " Requested Fuel-Type: {1}",
                    ManufacturerFuelType,
                    i_Type));

            // Assert Fuel-Type:
            if (i_Type != ManufacturerFuelType)
            {
                throw enumException;
            }

            this.AddSelfValue(i_Liters);
        }
    }
}
