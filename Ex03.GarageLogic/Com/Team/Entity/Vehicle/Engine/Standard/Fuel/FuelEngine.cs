using System.ComponentModel;
using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Fuel
{
    public sealed class FuelEngine : StandardEngine, ISelfRefueler
    {
        /// <summary>
        ///     Note: Capacity is measured in `Liter` units.
        /// </summary>
        /// <param name="i_ManufacturerFuelType">
        ///     Determines the Manufacturer's fuel type for this engine.
        /// </param>
        /// <param name="i_ManufacturerMaxEnergyAsVolumeOfFuelTankInLiters">
        ///     Sets the <see cref="Engine.ManufacturerMaxEnergy" />
        /// </param>
        public FuelEngine(eType i_ManufacturerFuelType,
            float i_ManufacturerMaxEnergyAsVolumeOfFuelTankInLiters)
        {
            ManufacturerFuelType = i_ManufacturerFuelType;
            ManufacturerMaxEnergy =
                i_ManufacturerMaxEnergyAsVolumeOfFuelTankInLiters;
        }

        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public eType ManufacturerFuelType { get; }

        public void RefuelSelf(eType i_Type, float i_LitersToAdd)
        {
            ValueOutOfRangeException rangeException =
                new ValueOutOfRangeException(ManufacturerMaxEnergy, 0);

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

            // Assert minimum:
            if (i_LitersToAdd < 0)
            {
                throw rangeException;
            }

            // Assert maximum:
            if (ManufacturerMaxEnergy > Energy + i_LitersToAdd)
            {
                throw rangeException;
            }

            Energy += i_LitersToAdd;
        }
    }
}
