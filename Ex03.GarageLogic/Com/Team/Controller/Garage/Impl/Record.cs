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
            if (this.AssertedVehicle is AssertedBatteryCar)
            {
                returnValue = ((AssertedBatteryCar) this.AssertedVehicle)
                    .LicensePlate;
            }
            if (this.AssertedVehicle is AssertedFuelCar)
            {
                returnValue = ((AssertedFuelCar) this.AssertedVehicle)
                    .LicensePlate;
            }
            if (this.AssertedVehicle is AssertedBatteryMotorcycle)
            {
                returnValue = ((AssertedBatteryMotorcycle) this.AssertedVehicle)
                    .LicensePlate;
            }
            if (this.AssertedVehicle is AssertedFuelMotorcycle)
            {
                returnValue = ((AssertedFuelMotorcycle) this.AssertedVehicle)
                    .LicensePlate;
            }
            if (this.AssertedVehicle is AssertedFuelTruck)
            {
                returnValue = ((AssertedFuelTruck) this.AssertedVehicle)
                    .LicensePlate;
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
