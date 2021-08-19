using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;

namespace Ex03.GarageLogic.Com.Team.DTO
{
    public class VehicleRecordDTO
    {
        public VehicleRecordDTO(Owner i_Owner, VehicleComponent i_VehicleComponent)
        {
            Owner = i_Owner;
            VehicleComponent = i_VehicleComponent;
        }

        public Owner Owner { get; }

        public VehicleComponent VehicleComponent { get; }
    }
}
