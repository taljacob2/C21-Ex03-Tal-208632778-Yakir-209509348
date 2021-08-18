using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Tire
{
    public struct Tire : ISelfInflater
    {
        public Tire(string i_ManufacturerName, float i_ManufacturerMaxAirPressure,
            float i_AirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            ManufacturerMaxAirPressure = i_ManufacturerMaxAirPressure;
            AirPressure = i_AirPressure;
        }

        public string ManufacturerName { get; }

        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public float ManufacturerMaxAirPressure { get; }

        /// <summary>
        ///     States the `current` air-pressure.
        /// </summary>
        public float AirPressure { get; private set; }

        public override string ToString()
        {
            return
                $"{nameof(ManufacturerName)}: {ManufacturerName}," +
                $" {nameof(ManufacturerMaxAirPressure)}: {ManufacturerMaxAirPressure}," +
                $" {nameof(AirPressure)}: {AirPressure}";
        }

        public void InflateSelf(float i_PressureToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(ManufacturerMaxAirPressure, 0);

            // Assert minimum:
            if (i_PressureToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (ManufacturerMaxAirPressure > AirPressure + i_PressureToAdd)
            {
                throw exception;
            }

            AirPressure += i_PressureToAdd;
        }
    }
}
