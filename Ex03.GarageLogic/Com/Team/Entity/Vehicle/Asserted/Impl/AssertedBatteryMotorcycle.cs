using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl
{
    public class AssertedBatteryMotorcycle : AssertedVehicle
    {
        public AssertedBatteryMotorcycle(string i_ModelName,
            string i_LicensePlate,
            Motorcycle.eLicenseType i_LicenseType, int i_EngineVolumeInCC,
            string i_TireManufacturerName)
        {
            Motorcycle =
                new Motorcycle(new ExtendedEngine(new BatteryEngine(1.8F),
                    i_EngineVolumeInCC));
            Motorcycle.SetTires(new Tire(i_TireManufacturerName,
                30, 0), Motorcycle.k_TiresAmount);
            Motorcycle.ModelName = i_ModelName;
            Motorcycle.LicensePlate = i_LicensePlate;
            Motorcycle.LicenseType = i_LicenseType;
        }

        /// <summary>
        ///     Must be <see langword="public" /> for reflection.
        /// </summary>
        public Motorcycle Motorcycle { get; }

        public string LicensePlate => Motorcycle.LicensePlate;

        public string ModelName => Motorcycle.ModelName;

        public BatteryEngine Engine =>
            (BatteryEngine) Motorcycle.EngineContainer;

        public Motorcycle.eLicenseType LicenseType => Motorcycle.LicenseType;

        public void AddSelfValue(float i_MinutesToAdd)
        {
            Engine.AddSelfValue(i_MinutesToAdd);
        }
    }
}
