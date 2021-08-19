using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public interface IRecorder
    {
        bool Insert(VehicleComponent i_VehicleComponent, Owner i_Owner);
    }
}
