﻿using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Asserted
{
    public class AssertedBatteryMotorcycle
    {
        private AssertedBatteryMotorcycle(string i_TireManufacturerName)
        {
            Motorcycle.SetTires(new Tire(i_TireManufacturerName,
                30, 0), Motorcycle.k_TiresAmount);
        }

        public AssertedBatteryMotorcycle(string i_ModelName,
            string i_LicensePlate,
            Motorcycle.eLicenseType i_LicenseType, int i_EngineVolumeInCC,
            string i_TireManufacturerName) : this(i_TireManufacturerName)
        {
            Motorcycle =
                new Motorcycle(new ExtendedEngine(new BatteryEngine(1.8F),
                    i_EngineVolumeInCC));
            Motorcycle.ModelName = i_ModelName;
            Motorcycle.LicensePlate = i_LicensePlate;
            Motorcycle.LicenseType = i_LicenseType;
        }

        protected Motorcycle Motorcycle { get; }

        public BatteryEngine Engine => (BatteryEngine) Motorcycle.Engine;

        public Motorcycle.eLicenseType LicenseType => Motorcycle.LicenseType;

        public void AddCharge(float i_MinutesToAdd)
        {
            Engine.AddCharge(i_MinutesToAdd);
        }
    }
}
