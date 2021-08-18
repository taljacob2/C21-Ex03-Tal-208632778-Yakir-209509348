using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle
{
    public abstract class Vehicle
    {
        protected Vehicle(VehicleConstructorDTO i_VehicleConstructorDTO)
        {
            ModelName = i_VehicleConstructorDTO.ModelName;
            LicensePlate = i_VehicleConstructorDTO.LicensePlate;
            TireToSetForAllTires = i_VehicleConstructorDTO.TireToSetForAllTires;
        }

        protected Vehicle() {}

        /// <summary>
        ///     Unique ID.
        /// </summary>
        public string LicensePlate { get; protected set; }

        public string ModelName { get; protected set; }

        public Tire TireToSetForAllTires { get; }

        public Tires Tires { get;} = new Tires();

        public Engine Engine { get; }

        public float GetRemainedEnergyPercentage()
        {
            return Engine.GetValuePercentage();
        }

        protected void SetTires(int i_TiresAmount)
        {
            for (int i = 0; i < i_TiresAmount; i++)
            {
                this.Tires.List.Add(this.TireToSetForAllTires);
            }
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
