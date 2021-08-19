using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Abstract
{
    public abstract class AbstractVehicle : Vehicle
    {
        protected AbstractVehicle(VehicleConstructorDTO i_VehicleConstructorDTO)
        {
            ModelName = i_VehicleConstructorDTO.ModelName;
            LicensePlate = i_VehicleConstructorDTO.LicensePlate;
        }

        protected AbstractVehicle() {}

        /// <summary>
        ///     Unique ID.
        /// </summary>
        public string LicensePlate { get; protected internal set; }

        public string ModelName { get; protected internal set; }

        public Tires Tires { get; } = new Tires();

        public Engine Engine { get; protected set; }

        public float GetRemainedEnergyPercentage()
        {
            return Engine.GetValuePercentage();
        }

        protected internal void SetTires(Tire i_TireToSetForAllTires,
            int i_TiresAmount)
        {
            for (int i = 0; i < i_TiresAmount; i++)
            {
                Tires.List.Add(i_TireToSetForAllTires.Copy()); // Deep copy.
            }
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
