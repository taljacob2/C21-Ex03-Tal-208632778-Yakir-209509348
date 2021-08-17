using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Motorcycle;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class MotorcycleConstructorDTO : VehicleConstructorDTO
    {
        public MotorcycleConstructorDTO(string i_ModelName,
            string i_LicensePlate, float i_TiresMaxAirPressure,
            Motorcycle.eLicenseType i_LicenseType,
            ExtendedEngine i_ExtendedEngine) : base(
            i_ModelName, i_LicensePlate, i_TiresMaxAirPressure)
        {
            LicenseType = i_LicenseType;
            ExtendedEngine = i_ExtendedEngine;
        }

        public Motorcycle.eLicenseType LicenseType { get; }

        public ExtendedEngine ExtendedEngine { get; }
    }
}
