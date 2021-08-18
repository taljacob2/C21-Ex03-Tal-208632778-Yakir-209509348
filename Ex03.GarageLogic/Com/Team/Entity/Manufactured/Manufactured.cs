using Ex03.GarageLogic.Com.Team.Exception;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured
{
    public abstract class Manufactured : ISelfValueAdder
    {
        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public float ManufacturerMaxValue { get; protected set; }

        /// <summary>
        ///     States the `current` value.
        /// </summary>
        public float Value { get; protected set; }

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
            if (ManufacturerMaxValue > Value + i_ValueToAdd)
            {
                throw exception;
            }

            Value += i_ValueToAdd;
        }

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetValuePercentage()
        {
            return Value / ManufacturerMaxValue * 100;
        }
        
        public override string ToString()
        {
            return this.ToStringExtension();
        }
        
    }
}
