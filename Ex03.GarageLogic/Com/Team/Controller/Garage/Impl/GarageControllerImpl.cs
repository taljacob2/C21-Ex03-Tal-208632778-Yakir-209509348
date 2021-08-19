using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.DTO.Model.Response;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Service;
using Ex03.GarageLogic.Com.Team.Service.Impl;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public class GarageControllerImpl : IGarageController
    {
        public IGarageService GarageService { get; } =
            new GarageServiceImpl();

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

        public Record PostCreateRecord(VehicleComponent i_VehicleComponent, Owner i_Owner)
        {
            return GarageService.CreateRecord(i_VehicleComponent, i_Owner);
        }

        public Record PostCreateAndInsertAssertedFuelCar(
            CreateAssertedCarRequest i_Request, out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedFuelCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostCreateAndInsertAssertedBatteryCar(CreateAssertedCarRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedBatteryCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }
        
        public Record PostInsertAssertedFuelCar(CreateAssertedCarRequest 
        i_Request, out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedBatteryCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostInsert(Record io_Record,
            out StringBuilder o_ResponseMessage)
        {
            return GarageService.Insert(io_Record, out o_ResponseMessage);
        }

        public List<string> GetLicensePlatesList()
        {
            return GarageService.SelectVehicleLicensePlates();
        }

        public List<string> GetLicensePlatesList(Record.eState i_StateToSelect)
        {
            return GarageService.SelectVehicleLicensePlates(i_StateToSelect);
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
