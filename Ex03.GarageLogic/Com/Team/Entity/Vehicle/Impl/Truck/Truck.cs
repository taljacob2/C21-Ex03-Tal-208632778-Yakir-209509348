using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Truck
{
    public class Truck : Vehicle
    {
        private const int k_TiresAmount = 16;

        public Truck(TruckConstructorDTO i_TruckConstructorDTO)
        {
            Engine = i_TruckConstructorDTO.Engine;
            ModelName = i_TruckConstructorDTO.ModelName;
            LicensePlate = i_TruckConstructorDTO.LicensePlate;
            IsContainingDangerousMaterials = i_TruckConstructorDTO
                .IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos =
                i_TruckConstructorDTO.MaxCarryingCapabilityInKilos;
            SetTires(i_TruckConstructorDTO.TireToSetForAllTires,
                k_TiresAmount);
        }

        public bool IsContainingDangerousMaterials { get; }

        /// <summary>
        ///     Measured in `Kilo` units.
        /// </summary>
        public float MaxCarryingCapabilityInKilos { get; }


        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
