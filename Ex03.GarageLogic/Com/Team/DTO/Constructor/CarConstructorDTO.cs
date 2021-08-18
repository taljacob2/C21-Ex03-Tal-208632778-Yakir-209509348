using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Car;

// ReSharper disable once TooManyDependencies
namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class CarConstructorDTO : VehicleConstructorDTO
    {
        public CarConstructorDTO(string i_ModelName, string i_LicensePlate,
            Tire i_TireToSetForAllTires,
            Car.eColor i_Color,
            Car.eDoorsAmount i_DoorsAmount, Engine i_Engine) :
            base(i_ModelName,
                i_LicensePlate)
        {
            TireToSetForAllTires = i_TireToSetForAllTires;
            Color = i_Color;
            DoorsAmount = i_DoorsAmount;
            Engine = i_Engine;
        }

        public Tire TireToSetForAllTires { get; }

        public Car.eColor Color { get; }

        public Car.eDoorsAmount DoorsAmount { get; }

        public Engine Engine { get; }
    }
}
