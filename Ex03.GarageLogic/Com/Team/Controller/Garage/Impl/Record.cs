using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public class Record
    {
        public enum eState
        {
            InProgress,
            Fixed,
            Payed
        }

        public Record(AssertedVehicle i_AssertedVehicle, Owner i_Owner)
        {
            AssertedVehicle = i_AssertedVehicle;
            Owner = i_Owner;
            State = eState.InProgress;
        }

        public Owner Owner { get; }

        public AssertedVehicle AssertedVehicle { get; }

        public eState State { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
