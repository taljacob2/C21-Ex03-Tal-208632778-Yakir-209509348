﻿using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl
{
    public class AssertedFuelMotorcycle : AssertedVehicle
    {
        public AssertedFuelMotorcycle(string i_ModelName,
            string i_LicensePlate,
            Motorcycle.eLicenseType i_LicenseType, int i_EngineVolumeInCC,
            string i_TireManufacturerName)
        {
            Motorcycle = new Motorcycle(new ExtendedEngine(new FuelEngine(eType
                .Octan95, 45), i_EngineVolumeInCC));
            Motorcycle.SetTires(new Tire(i_TireManufacturerName,
                30, 0), Motorcycle.k_TiresAmount);
            Motorcycle.ModelName = i_ModelName;
            Motorcycle.LicensePlate = i_LicensePlate;
            Motorcycle.LicenseType = i_LicenseType;
        }

        public string LicensePlate => Motorcycle.LicensePlate;

        public string ModelName => Motorcycle.ModelName;

        /// <summary>
        ///     Must be <see langword="public" /> for reflection.
        /// </summary>
        public Motorcycle Motorcycle { get; }

        public FuelEngine FuelEngine => (FuelEngine) Motorcycle.EngineContainer;

        public Motorcycle.eLicenseType LicenseType => Motorcycle.LicenseType;

        public void AddFuel(eType i_Type, float i_Liters)
        {
            FuelEngine.AddFuelByManualRequest(i_Type, i_Liters);
        }
    }
}
