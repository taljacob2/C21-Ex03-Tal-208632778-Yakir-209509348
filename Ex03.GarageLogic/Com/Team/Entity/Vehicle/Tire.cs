using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle
{
    public struct Tire : ISelfInflater
    {
        public Tire(string i_ManufacturerName, float i_MaxAirPressure,
            float i_AirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            AirPressure = i_AirPressure;
        }

        public string ManufacturerName { get; }

        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public float MaxAirPressure { get; }

        /// <summary>
        ///     States the `current` air-pressure.
        /// </summary>
        public float AirPressure { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(ManufacturerName)}: {ManufacturerName}," +
                $" {nameof(MaxAirPressure)}: {MaxAirPressure}," +
                $" {nameof(AirPressure)}: {AirPressure}";
        }

        public void InflateSelf(float i_PressureToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(MaxAirPressure, 0);

            // Assert minimum:
            if (i_PressureToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (MaxAirPressure > AirPressure + i_PressureToAdd)
            {
                throw exception;
            }

            AirPressure += i_PressureToAdd;
        }
    }
}
