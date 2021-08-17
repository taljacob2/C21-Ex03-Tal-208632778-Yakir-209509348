namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Fuel
{
    public class FuelEngine : StandardEngine
    {
        public FuelEngine(eType i_FuelType, float i_VolumeOfFuelTankInLiters)
        {
            FuelType = i_FuelType;
            VolumeOfFuelTankInLiters = i_VolumeOfFuelTankInLiters;
        }

        public eType FuelType { get; }


        /// <summary>
        ///     Measured in `Liter` units.
        /// </summary>
        public float VolumeOfFuelTankInLiters { get; }
    }
}
