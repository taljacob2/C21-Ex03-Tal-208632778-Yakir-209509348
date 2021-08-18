using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class TruckConstructorDTO : VehicleConstructorDTO
    {
        public TruckConstructorDTO(string i_ModelName,
            string i_LicensePlate, Tire i_TireToSetForAllTires,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            Engine i_Engine) : base(
            i_ModelName, i_LicensePlate)
        {
            TireToSetForAllTires = i_TireToSetForAllTires;
            IsContainingDangerousMaterials = i_IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
            Engine = i_Engine;
        }

        public Tire TireToSetForAllTires { get; }

        public bool IsContainingDangerousMaterials { get; }

        public float MaxCarryingCapabilityInKilos { get; }

        public Engine Engine { get; }
    }
}
