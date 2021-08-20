using Ex03.GarageLogic.Com.Team.Exception;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire
{
    /// <summary>
    ///     Units are measured in `PSI`.
    /// </summary>
    public class Tire : ISelfValueAdder
    {
        public Tire(string i_ManufacturerName,
            float i_ManufacturerMaxAirPressure,
            float i_AirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            ManufacturerMaxValue = i_ManufacturerMaxAirPressure;
            Value = i_AirPressure;
        }

        public ManufactureComponent ManufactureComponent { get; } =
            new ManufactureComponent();

        public float ManufacturerMaxValue
        {
            get => ManufactureComponent.ManufacturerMaxValue;

            set => ManufactureComponent.ManufacturerMaxValue = value;
        }

        public float Value
        {
            get => ManufactureComponent.Value;

            set => ManufactureComponent.Value = value;
        }

        public string ManufacturerName { get; }

        /// <summary />
        /// <param name="i_ValueToAdd" />
        /// <exception cref="ValueOutOfRangeException">
        ///     When the request exceeds the manufacturer's restrictions.
        /// </exception>
        public void AddSelfValue(float i_ValueToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(ManufacturerMaxValue, 0);

            // Assert minimum:
            if (i_ValueToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (ManufacturerMaxValue < Value + i_ValueToAdd)
            {
                throw exception;
            }

            Value += i_ValueToAdd;
        }

        public float GetValuePercentage()
        {
            return ManufactureComponent.GetValuePercentage();
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
