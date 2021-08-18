using Ex03.GarageLogic.Com.Team.DTO.Constructor;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Truck
{
    public class Truck : Vehicle
    {
        private const int k_TiresAmount = 16;

        public Truck(VehicleConstructorDTO i_VehicleConstructorDTO,
            StandardEngine
                i_StandardEngine, bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos)
            : base(i_VehicleConstructorDTO)
        {
            StandardEngine = i_StandardEngine;

            IsContainingDangerousMaterials = i_IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
        }

        public Truck(TruckConstructorDTO i_TruckConstructorDTO)
        {
            StandardEngine = i_TruckConstructorDTO.StandardEngine;
            ModelName = i_TruckConstructorDTO.ModelName;
            LicensePlate = i_TruckConstructorDTO.LicensePlate;

            IsContainingDangerousMaterials = i_TruckConstructorDTO
                .IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos =
                i_TruckConstructorDTO.MaxCarryingCapabilityInKilos;
        }

        public StandardEngine StandardEngine { get; }

        public bool IsContainingDangerousMaterials { get; }

        /// <summary>
        ///     Measured in `Kilo` units.
        /// </summary>
        public float MaxCarryingCapabilityInKilos { get; }


        public override string ToString()
        {
            return
                $"{base.ToString()}, {nameof(IsContainingDangerousMaterials)}:" +
                $" {IsContainingDangerousMaterials}," +
                $" {nameof(MaxCarryingCapabilityInKilos)}: {MaxCarryingCapabilityInKilos}";
        }
    }
}
