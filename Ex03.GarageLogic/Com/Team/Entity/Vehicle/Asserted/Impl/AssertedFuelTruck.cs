using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl
{
    public class AssertedFuelTruck : AssertedVehicle
    {
        public AssertedFuelTruck(string i_ModelName, string i_LicensePlate,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            string i_TireManufacturerName)
        {
            Truck.SetTires(new Tire(i_TireManufacturerName,
                26, 0), Truck.k_TiresAmount);
            Truck.ModelName = i_ModelName;
            Truck.LicensePlate = i_LicensePlate;
            Truck.IsContainingDangerousMaterials =
                i_IsContainingDangerousMaterials;
            Truck.MaxCarryingCapabilityInKilos = i_MaxCarryingCapabilityInKilos;
        }

        protected Truck Truck { get; } =
            new Truck(new FuelEngine(eType.Soler, 120));

        public override string LicensePlate => Truck.LicensePlate;

        public override string ModelName => Truck.ModelName;

        public FuelEngine Engine => (FuelEngine) Truck.Engine;

        public bool IsContainingDangerousMaterials =>
            Truck.IsContainingDangerousMaterials;

        public float MaxCarryingCapabilityInKilos =>
            Truck.MaxCarryingCapabilityInKilos;

        public void AddFuel(eType i_Type, float i_Liters)
        {
            Engine.AddFuelByManualRequest(i_Type, i_Liters);
        }
    }
}
