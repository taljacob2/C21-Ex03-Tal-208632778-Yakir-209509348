using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class TruckConstructorDTO : VehicleConstructorDTO
    {
        public TruckConstructorDTO(string i_ModelName,
            string i_LicensePlate, Tire i_TireToSetForAllTires,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            StandardEngine i_StandardEngine) : base(
            i_ModelName, i_LicensePlate)
        {
            TireToSetForAllTires = i_TireToSetForAllTires;
            IsContainingDangerousMaterials = i_IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
            StandardEngine = i_StandardEngine;
        }

        public Tire TireToSetForAllTires { get; }

        public bool IsContainingDangerousMaterials { get; }

        public float MaxCarryingCapabilityInKilos { get; }

        public StandardEngine StandardEngine { get; }
    }
}
