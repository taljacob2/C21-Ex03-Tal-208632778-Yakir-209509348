using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl
{
    public class AssertedBatteryCar : AssertedVehicle
    {
        public AssertedBatteryCar(string i_ModelName, string i_LicensePlate,
            Car.eColor i_Color,
            Car.eDoorsAmount i_DoorsAmount,
            string i_TireManufacturerName)
        {
            Car.SetTires(new Tire(i_TireManufacturerName,
                32, 0), Car.k_TiresAmount);
            Car.ModelName = i_ModelName;
            Car.LicensePlate = i_LicensePlate;
            Car.Color = i_Color;
            Car.DoorsAmount = i_DoorsAmount;
        }

        /// <summary>
        ///     Must be <see langword="public" /> for reflection.
        /// </summary>
        public Car Car { get; } =
            new Car(new BatteryEngine(3.2F));

        public string LicensePlate => Car.LicensePlate;

        public string ModelName => Car.ModelName;

        public BatteryEngine Engine => (BatteryEngine) Car.EngineContainer;

        public Car.eColor Color => Car.Color;

        public Car.eDoorsAmount DoorsAmount => Car.DoorsAmount;

        public void AddSelfValue(float i_MinutesToAdd)
        {
            Engine.AddSelfValue(i_MinutesToAdd);
        }
    }
}
