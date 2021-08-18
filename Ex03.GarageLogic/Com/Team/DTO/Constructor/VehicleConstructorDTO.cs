using System.Linq.Expressions;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;

namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class VehicleConstructorDTO
    {
        public VehicleConstructorDTO(string i_ModelName, string i_LicensePlate,
            Tire i_TireToSetForAllTires)
        {
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
            TireToSetForAllTires = i_TireToSetForAllTires;
        }

        public string LicensePlate { get; }

        public Tire TireToSetForAllTires { get; }

        public string ModelName { get; }
    }
}
