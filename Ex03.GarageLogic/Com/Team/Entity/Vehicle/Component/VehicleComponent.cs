using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component
{
    public abstract class VehicleComponent : Vehicle
    {
        protected VehicleComponent(VehicleComponentConstructorDTO i_VehicleComponentConstructorDTO)
        {
            ModelName = i_VehicleComponentConstructorDTO.ModelName;
            LicensePlate = i_VehicleComponentConstructorDTO.LicensePlate;
        }

        protected VehicleComponent() {}
        
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
