using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.DTO.Model.Response;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Service;
using Ex03.GarageLogic.Com.Team.Service.Impl;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public class GarageControllerImpl : IGarageController
    {
        public IVehicleService VehicleService { get; } =
            new VehicleServiceImpl();

        // TODO : disabled.
        // public string GetVehicleDetails(string i_LicensePlate)
        // {
        //     Record record =
        //         FindVehicleRecordByLicensePlate(i_LicensePlate);
        //     return
        //         $"{record.Vehicle} Owners name:{record.Owner.Name}" +
        //         $" Owners phone number: {record.Owner.PhoneNumber}";
        // }

        public bool PostRefuel(RefuelRequest i_Request)
        {
            throw new NotImplementedException();
        }

        public bool PostRecharge(RechargeRequest i_Request)
        {
            throw new NotImplementedException();
        }

        public VehicleResponse GetVehicleDetails(string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        public bool PostInsert(Vehicle i_Vehicle)
        {
            throw new NotImplementedException();
        }

        public List<string> GetLicensePlatesList()
        {
            return VehicleService.SelectVehicleLicensePlates();
        }

        public List<string> GetLicensePlatesList(Record.eState i_StateToSelect)
        {
            throw new NotImplementedException();
        }

        public bool PostNewState(NewStateRequest i_Request)
        {
            throw new NotImplementedException();
        }

        public bool PostInflateTiresToMax(string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        // TODO : disabled.
        // public void ChargeVehicle(string i_LicensePlate, float i_Amount)
        // {
        //     Record record =
        //         FindVehicleRecordByLicensePlate(i_LicensePlate);
        //     if (!(record.Vehicle is IElectricVehicle vehicle))
        //     {
        //         throw new ArgumentException("This Vehicle does not use Fuel.");
        //     }
        //
        //     vehicle.ChargeBattery(i_Amount);
        // }

        // TODO : disabled.
        // public void SetTiresAirPressureToMax(Vehicle o_Vehicle)
        // {
        //     foreach (Tire tire in o_Vehicle.Tires)
        //     {
        //         setAirPressureToMax(tire);
        //     }
        // }
        //
        // private List<Tire> getTires(Vehicle i_Vehicle)
        // {
        //     return i_Vehicle.Tires;
        // }
        //
        // private static void addAirPressure(Tire o_Tire, float i_Pressure)
        // {
        //     if (o_Tire.MaxAirPressure > o_Tire.AirPressure + i_Pressure)
        //     {
        //         throw new ValueOutOfRangeException(o_Tire.MaxAirPressure, 0);
        //     }
        //
        //     o_Tire.AirPressure += i_Pressure;
        // }
        //
        // private void setAirPressureToMax(Tire o_Tire)
        // {
        //     o_Tire.AirPressure = o_Tire.MaxAirPressure;
        // }
    }
}
