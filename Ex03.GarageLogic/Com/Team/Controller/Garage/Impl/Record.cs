using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public struct Record
    {
        public enum eState
        {
            InProgress,
            Fixed,
            Payed // FIXME: what is this? and when? can't be in parallel -> limitation.
        }

        public Record(AbstractVehicle i_AbstractVehicle, Owner i_Owner)
        {
            AbstractVehicle = i_AbstractVehicle;
            Owner = i_Owner;
            State = eState.InProgress;
        }

        public Owner Owner { get; }

        public AbstractVehicle AbstractVehicle { get; }

        public eState State { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
