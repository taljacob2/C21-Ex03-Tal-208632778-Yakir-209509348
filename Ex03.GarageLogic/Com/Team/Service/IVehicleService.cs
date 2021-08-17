using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;

namespace Ex03.GarageLogic.Com.Team.Service
{
    public interface IVehicleService
    {
        Record CreateRecord(Vehicle i_Vehicle, Owner i_Owner);

        void Fuel(FuelRequest i_Request);
    }
}
