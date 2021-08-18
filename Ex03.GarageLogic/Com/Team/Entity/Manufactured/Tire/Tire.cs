namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire
{
    /// <summary>
    ///     <see cref="Manufactured.Value" /> is measured in `PSI`.
    /// </summary>
    public class Tire : Manufactured
    {
        public Tire(string i_ManufacturerName,
            float i_ManufacturerMaxAirPressure,
            float i_AirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            ManufacturerMaxValue = i_ManufacturerMaxAirPressure;
            Value = i_AirPressure;
        }

        public string ManufacturerName { get; }

        public override string ToString()
        {
            return
                $"{nameof(ManufacturerName)}: {ManufacturerName}," +
                $" {nameof(ManufacturerMaxValue)}: {ManufacturerMaxValue}," +
                $" {nameof(Value)}: {Value}";
        }

        public void AddPressure(float i_PSIToAdd)
        {
            this.AddSelfValue(i_PSIToAdd);
        }
    }
}
