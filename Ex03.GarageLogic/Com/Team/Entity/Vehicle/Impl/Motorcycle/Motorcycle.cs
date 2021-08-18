using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Misc;

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
            this.SetTires(k_TiresAmount);
        }

        public Motorcycle(MotorcycleConstructorDTO i_MotorcycleConstructorDTO)
        {
            ModelName = i_MotorcycleConstructorDTO.ModelName;
            LicensePlate = i_MotorcycleConstructorDTO.LicensePlate;
            LicenseType = i_MotorcycleConstructorDTO.LicenseType;
            ExtendedEngine = i_MotorcycleConstructorDTO.ExtendedEngine;
            this.SetTires(k_TiresAmount);
        }

        public ExtendedEngine ExtendedEngine { get; }

        public eLicenseType LicenseType { get; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
