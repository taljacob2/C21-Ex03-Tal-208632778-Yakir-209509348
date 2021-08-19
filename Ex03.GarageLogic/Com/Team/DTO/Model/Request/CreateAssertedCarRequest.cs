using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract.Impl;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public class CreateAssertedCarRequest
    {
        public CreateAssertedCarRequest(Owner i_Owner, string i_ModelName,
            string i_LicensePlate, string i_TireManufacturerName,
            Car.eColor i_Color, Car.eDoorsAmount i_DoorsAmount,
            GarageEnums.eEngineType i_EngineType)
        {
            Owner = i_Owner;
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
            TireManufacturerName = i_TireManufacturerName;
            Color = i_Color;
            DoorsAmount = i_DoorsAmount;
            EngineType = i_EngineType;
        }

        public Owner Owner { get; }

        public string ModelName { get; }

        public string LicensePlate { get; }

        public string TireManufacturerName { get; }

        public Car.eColor Color { get; }

        public Car.eDoorsAmount DoorsAmount { get; }

        public GarageEnums.eEngineType EngineType { get; }
    }
}
