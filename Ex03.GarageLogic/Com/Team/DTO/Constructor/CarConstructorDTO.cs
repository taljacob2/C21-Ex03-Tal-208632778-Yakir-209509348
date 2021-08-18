using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Car;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class CarConstructorDTO : VehicleConstructorDTO
    {
        public CarConstructorDTO(string i_ModelName, string i_LicensePlate,
            float i_TiresMaxAirPressure,
            Car.eColor i_Color,
            Car.eDoorsAmount i_DoorsAmount, StandardEngine i_StandardEngine) :
            base(i_ModelName,
                i_LicensePlate, i_TiresMaxAirPressure)
        {
            Color = i_Color;
            DoorsAmount = i_DoorsAmount;
            StandardEngine = i_StandardEngine;
        }

        public Car.eColor Color { get; }

        public Car.eDoorsAmount DoorsAmount { get; }

        public StandardEngine StandardEngine { get; }
    }
}
