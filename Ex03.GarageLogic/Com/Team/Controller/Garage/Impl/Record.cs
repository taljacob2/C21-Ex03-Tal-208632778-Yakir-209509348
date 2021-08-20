using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
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

        public eState State { get; set; }

        public string GetLicensePlate()
        {
            string returnValue = null;
            if (AssertedVehicle is AssertedBatteryCar)
            {
                returnValue = ((AssertedBatteryCar) AssertedVehicle)
                    .GetLicensePlate();
            }

            if (AssertedVehicle is AssertedFuelCar)
            {
                returnValue = ((AssertedFuelCar) AssertedVehicle)
                    .GetLicensePlate();
            }

            if (AssertedVehicle is AssertedBatteryMotorcycle)
            {
                returnValue = ((AssertedBatteryMotorcycle) AssertedVehicle)
                    .GetLicensePlate();
            }

            if (AssertedVehicle is AssertedFuelMotorcycle)
            {
                returnValue = ((AssertedFuelMotorcycle) AssertedVehicle)
                    .GetLicensePlate();
            }

            if (AssertedVehicle is AssertedFuelTruck)
            {
                returnValue = ((AssertedFuelTruck) AssertedVehicle)
                    .GetLicensePlate();
            }

            return returnValue;
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
