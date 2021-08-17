namespace Ex03.GarageLogic.Com.Team.DTO.Constructor
{
    public class VehicleConstructorDTO
    {
        public VehicleConstructorDTO(string i_ModelName, string i_LicensePlate,
            float i_TiresMaxAirPressure)
        {
            ModelName = i_ModelName;
            LicensePlate = i_LicensePlate;
            TiresMaxAirPressure = i_TiresMaxAirPressure;
        }

        public string LicensePlate { get; }

        public string ModelName { get; }

        public float TiresMaxAirPressure { get; }
    }
}
