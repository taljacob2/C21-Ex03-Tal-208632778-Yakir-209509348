using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted
{
    public abstract class AssertedVehicle
    {
        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
