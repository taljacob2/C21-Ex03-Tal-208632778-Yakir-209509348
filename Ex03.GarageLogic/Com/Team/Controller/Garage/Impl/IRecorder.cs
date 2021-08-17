using Ex03.GarageLogic.Com.Team.Entity.Vehicle;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public interface IRecorder
    {
        bool Insert(Vehicle i_Vehicle, Owner i_Owner);
    }
}
