namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine
{
    public abstract class Engine
    {
        /// <summary>
        ///     Determines the Remained-Energy.
        ///     <example>Measured in `derived: Liter/Hour` units.</example>
        /// </summary>
        public float Energy { get; set; } = 0;

        /// <summary>
        ///     Determines the Total-Max-Energy.
        ///     <example>Measured in `derived: Liter/Hour` units.</example>
        /// </summary>
        public float MaxEnergy { get; protected set; } = 100;

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetRemainedEnergyPercentage()
        {
            return Energy / MaxEnergy * 100;
        }
    }
}
