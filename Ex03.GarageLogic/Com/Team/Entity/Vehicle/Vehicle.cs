using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle
{
    public abstract class Vehicle
    {
        /// <summary>
        ///     Unique ID.
        /// </summary>
        public virtual string LicensePlate { get; protected internal set; }

        public virtual string ModelName { get; protected internal set; }
        
        public Engine Engine { get; protected set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
