namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle
{
    public abstract class Vehicle
    {
        /// <summary>
        ///     Unique ID.
        /// </summary>
        public virtual string LicensePlate { get; protected internal set; }

        public virtual string ModelName { get; protected internal set; }
    }
}
