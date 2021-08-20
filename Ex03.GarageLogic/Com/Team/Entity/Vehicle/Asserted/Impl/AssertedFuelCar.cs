using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl
{
    public class AssertedFuelCar : AssertedVehicle
    {
        public AssertedFuelCar(string i_ModelName, string i_LicensePlate,
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
            new Car(new FuelEngine(eType.Octan95, 45));

        public FuelEngine GetRefFuelEngine()
        {
            return (FuelEngine) Car.EngineContainer;
        }

        public Car.eColor GetColor()
        {
            return Car.Color;
        }

        public Car.eDoorsAmount GetDoorsAmount()
        {
            return Car.DoorsAmount;
        }

        public void AddFuel(eType i_Type, float i_Liters)
        {
            GetRefFuelEngine().AddFuelByManualRequest(i_Type, i_Liters);
        }

        public string GetLicensePlate()
        {
            return Car.LicensePlate;
        }

        public string GetModelName()
        {
            return Car.ModelName;
        }
    }
}
