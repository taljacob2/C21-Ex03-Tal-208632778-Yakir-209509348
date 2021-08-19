using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;

namespace Ex03.GarageLogic.Com.Team.DTO
{
    public class VehicleRecordDTO
    {
        public VehicleRecordDTO(Owner i_Owner,
            ComponentVehicle i_ComponentVehicle)
        {
            Owner = i_Owner;
            ComponentVehicle = i_ComponentVehicle;
        }

        public Owner Owner { get; }

        public ComponentVehicle ComponentVehicle { get; }
    }
}
