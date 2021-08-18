namespace Ex03.GarageLogic.Com.Team.Entity.Manufacturer.Engine
{
    public abstract class Engine
    {
        /// <summary>
        ///     Determines the Remained-Energy.
        ///     <example>Measured in `derived: Liter/Hour` units.</example>
        /// </summary>
        public float Energy { get; protected set; } = 0;

        /// <summary>
        ///     Defined by the Manufacturer.
        ///     Determines the Total-Max-Energy.
        ///     <example>Measured in `derived: Liter/Hour` units.</example>
        /// </summary>
        public float ManufacturerMaxEnergy { get; protected set; } = 100;

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetRemainedEnergyPercentage()
        {
            return Energy / ManufacturerMaxEnergy * 100;
        }
    }
}
