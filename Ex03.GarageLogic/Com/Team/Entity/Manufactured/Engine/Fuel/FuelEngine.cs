using System.ComponentModel;
using Ex03.GarageLogic.Com.Team.Misc;

// ReSharper disable once FlagArgument
namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel
{
    public sealed class FuelEngine : Engine
    {
        /// <summary>
        ///     Note: Capacity is measured in `Liter` units.
        /// </summary>
        /// <param name="i_ManufacturerFuelType">
        ///     Determines the Manufacturer's fuel type for this engine.
        /// </param>
        /// <param name="i_ManufacturerMaxVolumeOfFuelTankInLiters">
        /// </param>
        public FuelEngine(eType i_ManufacturerFuelType,
            float i_ManufacturerMaxVolumeOfFuelTankInLiters)
        {
            ManufacturerFuelType = i_ManufacturerFuelType;
            ManufacturerMaxValue = i_ManufacturerMaxVolumeOfFuelTankInLiters;
        }

        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public eType ManufacturerFuelType { get; }

        public void AddFuelByManualRequest(eType i_Type, float i_Liters)
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

            AddSelfValue(i_Liters);
        }

        public override string ToString()
        {
            return $"{nameof(FuelEngine)}: " + this.ToStringExtension();
        }
    }
}
