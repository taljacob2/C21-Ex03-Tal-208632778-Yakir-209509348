namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Fuel
{
    public sealed class FuelEngine : StandardEngine, ISelfRefueler
    {
        /// <summary>
        ///     Note: Capacity is measured in `Liter` units.
        /// </summary>
        /// <param name="i_FuelType">
        ///     Determines the Manufacturer's fuel type for this engine.
        /// </param>
        /// <param name="i_MaxEnergyAsVolumeOfFuelTankInLiters">
        ///     Sets the <see cref="Engine.MaxEnergy" />
        /// </param>
        public FuelEngine(eType i_FuelType, float i_MaxEnergyAsVolumeOfFuelTankInLiters)
        {
            FuelType = i_FuelType;
            MaxEnergy = i_MaxEnergyAsVolumeOfFuelTankInLiters;
        }

        public eType FuelType { get; }

        public void RefuelSelf(eType i_Type, float i_LitersToAdd)
        {
            throw new System.NotImplementedException();
        }
    }
}
