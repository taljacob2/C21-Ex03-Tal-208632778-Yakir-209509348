using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public class CreateAndInsertAssertedTruckRequest
    {
        public CreateAndInsertAssertedTruckRequest(Owner i_Owner,
            string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            GarageEnums.eEngineType i_EngineType)
        {
            Owner = i_Owner;
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
            TireManufacturerName = i_TireManufacturerName;
            IsContainingDangerousMaterials = i_IsContainingDangerousMaterials;
            MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
            EngineType = i_EngineType;
        }

        public Owner Owner { get; }

        public string ModelName { get; }

        public string LicensePlate { get; }

        public string TireManufacturerName { get; }

        public bool IsContainingDangerousMaterials { get; }

        public float MaxCarryingCapabilityInKilos { get; }

        public GarageEnums.eEngineType EngineType { get; }
    }
}
