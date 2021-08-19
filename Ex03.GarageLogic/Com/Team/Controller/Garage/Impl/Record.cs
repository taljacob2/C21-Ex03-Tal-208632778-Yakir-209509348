using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public struct Record
    {
        public enum eState
        {
            InProgress,
            Fixed,
            Payed
        }

        public Record(Vehicle i_Vehicle, Owner i_Owner)
        {
            Vehicle = i_Vehicle;
            Owner = i_Owner;
            State = eState.InProgress;
        }

        public Owner Owner { get; }

        public Vehicle Vehicle { get; }

        public eState State { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
