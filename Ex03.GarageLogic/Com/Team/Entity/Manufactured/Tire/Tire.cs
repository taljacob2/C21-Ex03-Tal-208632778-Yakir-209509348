using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire
{
    /// <summary>
    ///     <see cref="Manufactured.Value" /> is measured in `PSI`.
    /// </summary>
    public class Tire : Manufactured, ISelfInflater
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

        /// <summary />
        /// <param name="i_ValueToAdd" />
        /// <exception cref="ValueOutOfRangeException">
        ///     When the request exceeds the manufacturer's restrictions.
        /// </exception>
        public void InflateSelf(float i_ValueToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(ManufacturerMaxValue, 0);

            // Assert minimum:
            if (i_ValueToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (ManufacturerMaxValue > Value + i_ValueToAdd)
            {
                throw exception;
            }

            Value += i_ValueToAdd;
        }

        public override string ToString()
        {
            return
                $"{nameof(ManufacturerName)}: {ManufacturerName}," +
                $" {nameof(ManufacturerMaxValue)}: {ManufacturerMaxValue}," +
                $" {nameof(Value)}: {Value}";
        }
    }
}
