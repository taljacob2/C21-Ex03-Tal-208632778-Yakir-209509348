using Ex03.GarageLogic.Com.Team.Entity.Vehicle;

namespace Ex03.GarageLogic.Com.Team.DTO
{
    public class VehicleRecordDTO
    {
        public VehicleRecordDTO(Owner i_Owner, Vehicle i_Vehicle)
        {
            Owner = i_Owner;
            Vehicle = i_Vehicle;
        }

        public Owner Owner { get; }

        public Vehicle Vehicle { get; }
    }
}
