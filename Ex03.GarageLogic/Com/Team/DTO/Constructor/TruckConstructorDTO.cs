using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class TruckConstructorDTO : VehicleConstructorDTO
    {
        public TruckConstructorDTO(string i_ModelName,
            string i_LicensePlate, float i_TiresMaxAirPressure,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            StandardEngine i_StandardEngine) : base(
            i_ModelName, i_LicensePlate, i_TiresMaxAirPressure)
        {
            IsContainingDangerousMaterials = i_IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
            StandardEngine = i_StandardEngine;
        }

        public bool IsContainingDangerousMaterials { get; }

        public float MaxCarryingCapabilityInKilos { get; }

        public StandardEngine StandardEngine { get; }
    }
}
