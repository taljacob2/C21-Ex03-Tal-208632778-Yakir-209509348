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
        
        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetValuePercentage()
        {
            return Value / ManufacturerMaxValue * 100;
        }        
    }
}
