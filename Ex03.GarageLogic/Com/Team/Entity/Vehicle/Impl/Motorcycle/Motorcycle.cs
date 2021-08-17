using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Extended;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Motorcycle
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }

        public const int k_TiresAmount = 2;

        public Motorcycle(VehicleConstructorDTO i_VehicleConstructorDTO,
            eLicenseType i_LicenseType, ExtendedEngine i_ExtendedEngine) : base(
            i_VehicleConstructorDTO)
        {
            LicenseType = i_LicenseType;
            ExtendedEngine = i_ExtendedEngine;
        }

        public Motorcycle(MotorcycleConstructorDTO i_MotorcycleConstructorDTO)
        {
            ExtendedEngine = i_MotorcycleConstructorDTO.ExtendedEngine;
            ModelName = i_MotorcycleConstructorDTO.ModelName;
            LicensePlate = i_MotorcycleConstructorDTO.LicensePlate;

            LicenseType = i_MotorcycleConstructorDTO.LicenseType;
        }

        public ExtendedEngine ExtendedEngine { get; }

        public eLicenseType LicenseType { get; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(LicenseType)}: {LicenseType}";
        }
    }
}
