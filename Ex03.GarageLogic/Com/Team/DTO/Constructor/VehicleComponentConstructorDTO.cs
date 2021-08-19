namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class VehicleComponentConstructorDTO
    {
        public VehicleComponentConstructorDTO(string i_ModelName, string i_LicensePlate)
        {
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
        }

        public string LicensePlate { get; }

        public string ModelName { get; }
    }
}
