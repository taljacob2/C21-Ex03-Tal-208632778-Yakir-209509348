namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine
{
    public abstract class Engine
    {
        /// <summary>
        ///     Determines the Remained-Energy.
        ///     Measured in `derived: Liter/Hour` units.
        /// </summary>
        public float Energy { get; set; } = 0;

        /// <summary>
        ///     Measured in `derived: Liter/Hour` units.
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
