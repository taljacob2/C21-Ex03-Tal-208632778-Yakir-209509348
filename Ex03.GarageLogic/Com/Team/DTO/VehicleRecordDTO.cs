using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract;

namespace Ex03.GarageLogic.Com.Team.DTO
{
    public class VehicleRecordDTO
    {
        public VehicleRecordDTO(Owner i_Owner, AbstractVehicle i_AbstractVehicle)
        {
            Owner = i_Owner;
            AbstractVehicle = i_AbstractVehicle;
        }

        public Owner Owner { get; }

        public AbstractVehicle AbstractVehicle { get; }
    }
}
