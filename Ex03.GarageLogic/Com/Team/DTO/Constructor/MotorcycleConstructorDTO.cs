using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Motorcycle;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class MotorcycleConstructorDTO : VehicleConstructorDTO
    {
        public MotorcycleConstructorDTO(string i_ModelName,
            string i_LicensePlate, Tire i_TireToSetForAllTires,
            Motorcycle.eLicenseType i_LicenseType,
            ExtendedEngine i_ExtendedEngine) : base(
            i_ModelName, i_LicensePlate)
        {
            TireToSetForAllTires = i_TireToSetForAllTires;
            LicenseType = i_LicenseType;
            ExtendedEngine = i_ExtendedEngine;
        }

        public Motorcycle.eLicenseType LicenseType { get; }

        public ExtendedEngine ExtendedEngine { get; }

        public Tire TireToSetForAllTires { get; }
    }
}
