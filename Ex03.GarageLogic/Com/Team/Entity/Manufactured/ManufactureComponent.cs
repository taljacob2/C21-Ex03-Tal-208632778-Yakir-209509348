namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured
{
    public class ManufactureComponent
    {
        /// <summary>
        ///     Defined by the Manufacturer.
        /// </summary>
        public float ManufacturerMaxValue { get; protected internal set; }

        /// <summary>
        ///     States the `current` value.
        /// </summary>
        public float Value { get; protected internal set; }

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetValuePercentage()
        {
            return Value / ManufacturerMaxValue * 100;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
