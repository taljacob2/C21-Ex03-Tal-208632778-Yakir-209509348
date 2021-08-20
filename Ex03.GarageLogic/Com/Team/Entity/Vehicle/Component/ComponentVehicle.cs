using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component
{
    public abstract class ComponentVehicle : Vehicle
    {
        protected ComponentVehicle(
            ComponentVehicleConstructorDTO i_ComponentVehicleConstructorDTO)
        {
            ModelName = i_ComponentVehicleConstructorDTO.ModelName;
            LicensePlate = i_ComponentVehicleConstructorDTO.LicensePlate;
        }

        protected ComponentVehicle() {}

        public Tires Tires { get; } = new Tires();

        public float GetRemainedEnergyPercentage()
        {
            return EngineContainer.GetValuePercentage();
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
