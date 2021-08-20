using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl
{
    public class Motorcycle : ComponentVehicle
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
            EngineContainer = i_MotorcycleConstructorDTO.ExtendedEngine;
            SetTires(i_MotorcycleConstructorDTO.TireToSetForAllTires,
                k_TiresAmount);
        }

        public Motorcycle(ExtendedEngine i_ExtendedEngine)
        {
            EngineContainer = i_ExtendedEngine;
        }

        // public ExtendedEngine ExtendedEngine { get; }

        public eLicenseType LicenseType { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
