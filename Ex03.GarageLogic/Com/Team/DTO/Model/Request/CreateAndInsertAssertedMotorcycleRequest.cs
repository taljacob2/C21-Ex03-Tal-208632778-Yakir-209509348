using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public class CreateAndInsertAssertedMotorcycleRequest
    {
        public CreateAndInsertAssertedMotorcycleRequest(Owner i_Owner,
            string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName,
            Motorcycle.eLicenseType i_LicenseType,
            int i_ExtendedEngineVolumeInCC,
            GarageEnums.eEngineType i_EngineType)
        {
            Owner = i_Owner;
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
            TireManufacturerName = i_TireManufacturerName;
            LicenseType = i_LicenseType;
            ExtendedEngineVolumeInCC = i_ExtendedEngineVolumeInCC;
            EngineType = i_EngineType;
        }

        public Owner Owner { get; }

        public string ModelName { get; }

        public string LicensePlate { get; }

        public string TireManufacturerName { get; }

        public Motorcycle.eLicenseType LicenseType { get; }

        public int ExtendedEngineVolumeInCC { get; }

        public GarageEnums.eEngineType EngineType { get; }
    }
}
