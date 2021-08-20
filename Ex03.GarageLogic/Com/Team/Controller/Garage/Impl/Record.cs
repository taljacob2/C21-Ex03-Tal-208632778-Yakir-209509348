using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public class Record
    {
        public enum eState
        {
            InProgress,
            Fixed,
            Payed
        }

        public Record(AssertedVehicle i_AssertedVehicle, Owner i_Owner)
        {
            AssertedVehicle = i_AssertedVehicle;
            Owner = i_Owner;
            State = eState.InProgress;
        }

        public Owner Owner { get; }

        public AssertedVehicle AssertedVehicle { get; }

        public string GetLicensePlate()
        {
            string returnValue = null;
            if (this.AssertedVehicle.GetPropertyValue<AssertedBatteryCar>
                ("AssertedBatteryCar") != null)
            {
                returnValue = this.AssertedVehicle
                    .GetPropertyValue<AssertedBatteryCar>
                        ("AssertedBatteryCar").LicensePlate;
            }
            else if (this.AssertedVehicle.GetPropertyValue<AssertedFuelCar>
                ("AssertedFuelCar") != null)
            {
                returnValue = this.AssertedVehicle
                    .GetPropertyValue<AssertedFuelCar>
                        ("AssertedFuelCar").LicensePlate;
            }
            else if (this.AssertedVehicle
                .GetPropertyValue<AssertedBatteryMotorcycle>
                    ("AssertedBatteryMotorcycle") != null)
            {
                returnValue = this.AssertedVehicle
                    .GetPropertyValue<AssertedBatteryMotorcycle>
                        ("AssertedBatteryMotorcycle").LicensePlate;
            }
            else if (this.AssertedVehicle
                .GetPropertyValue<AssertedFuelMotorcycle>
                    ("AssertedFuelMotorcycle") != null)
            {
                returnValue = this.AssertedVehicle
                    .GetPropertyValue<AssertedFuelMotorcycle>
                        ("AssertedFuelMotorcycle").LicensePlate;
            }
            else if (this.AssertedVehicle.GetPropertyValue<AssertedFuelTruck>
                ("AssertedFuelTruck") != null)
            {
                returnValue = this.AssertedVehicle
                    .GetPropertyValue<AssertedFuelTruck>
                        ("AssertedFuelTruck").LicensePlate;
            }

            return returnValue;
        }

        public eState State { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
