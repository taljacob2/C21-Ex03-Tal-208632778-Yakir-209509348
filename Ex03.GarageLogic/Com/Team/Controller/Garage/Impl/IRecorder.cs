using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public interface IRecorder
    {
        bool Insert(AbstractVehicle i_AbstractVehicle, Owner i_Owner);
    }
}
