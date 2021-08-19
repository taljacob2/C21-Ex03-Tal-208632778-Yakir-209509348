using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Asserted
{
    public class AssertedFuelCar
    {
        public AssertedFuelCar(string i_TireManufacturerName, float
            i_TireManufacturerMaxAirPressure)
        {
            Car.SetTires(new Tire(i_TireManufacturerName,
                i_TireManufacturerMaxAirPressure, 0), Car.k_TiresAmount);
        }

        protected Car Car { get; } =
            new Car(new FuelEngine(eType.Octan95, 45));

        public FuelEngine FuelEngine => (FuelEngine) Car.Engine;

        public Car.eColor Color => Car.Color;

        public Car.eDoorsAmount DoorsAmount => Car.DoorsAmount;
    }
}
