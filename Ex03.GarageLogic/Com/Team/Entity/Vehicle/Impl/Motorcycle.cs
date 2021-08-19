using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl
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

        public Motorcycle(MotorcycleConstructorDTO i_MotorcycleConstructorDTO)
        {
            ModelName = i_MotorcycleConstructorDTO.ModelName;
            LicensePlate = i_MotorcycleConstructorDTO.LicensePlate;
            LicenseType = i_MotorcycleConstructorDTO.LicenseType;
            ExtendedEngine = i_MotorcycleConstructorDTO.ExtendedEngine;
            SetTires(i_MotorcycleConstructorDTO.TireToSetForAllTires,
                k_TiresAmount);
        }

        public Motorcycle(ExtendedEngine i_ExtendedEngine)
        {
            ExtendedEngine = i_ExtendedEngine;
        }

        public ExtendedEngine ExtendedEngine { get; }

        public eLicenseType LicenseType { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
