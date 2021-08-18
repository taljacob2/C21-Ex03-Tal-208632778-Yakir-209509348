namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Fuel
{
    public sealed class FuelEngine : StandardEngine
    {
        /// <summary>
        ///     Note: Capacity is measured in `Liter` units.
        /// </summary>
        /// <param name="i_FuelType">
        ///     Determines the Manufacturer's fuel type for this engine.
        /// </param>
        /// <param name="i_MaxVolumeOfFuelTankInLiters">
        ///     Sets the <see cref="Engine.MaxEnergy" />
        /// </param>
        public FuelEngine(eType i_FuelType, float i_MaxVolumeOfFuelTankInLiters)
        {
            FuelType = i_FuelType;
            MaxEnergy = i_MaxVolumeOfFuelTankInLiters;
        }

        public eType FuelType { get; }
    }
}
