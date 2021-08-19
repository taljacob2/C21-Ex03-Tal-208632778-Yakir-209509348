using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Service;
using Ex03.GarageLogic.Com.Team.Service.Impl;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage.Impl
{
    public class GarageControllerImpl : IGarageController
    {
        public IGarageService GarageService { get; } =
            new GarageServiceImpl();
        
        public bool PostRefuel(RefuelRequest i_Request, out string o_ResponseMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue =
                GarageService.PostRefuel(i_Request, out stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();
            return returnValue;
        }

        public void GetRecordDetails(string i_LicensePlate,
            out string o_ResponseMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            GarageService.GetRecordDetails(i_LicensePlate, out stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();
        }

        public Record PostCreateRecord(ComponentVehicle i_ComponentVehicle,
            Owner i_Owner)
        {
            return GarageService.CreateRecord(i_ComponentVehicle, i_Owner);
        }

        public Record PostCreateAndInsertAssertedFuelCar(
            CreateAndInsertAssertedCarRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedFuelCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostCreateAndInsertAssertedBatteryCar(
            CreateAndInsertAssertedCarRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedBatteryCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostCreateAndInsertAssertedFuelMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedFuelMotorcycle(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostCreateAndInsertAssertedBatteryMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedBatteryMotorcycle(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }

        public Record PostCreateAndInsertAssertedFuelTruck(
            CreateAndInsertAssertedTruckRequest i_Request,
            out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedFuelTruck(i_Request),
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

        public bool PostSetState(SetStateRequest i_Request,
            out string o_ResponseMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = GarageService.SetState(i_Request, out
                stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();
            return returnValue;
        }

        public bool PostInflateTiresToMaxByLicensePlate(string i_LicensePlate,
            out string o_ResponseMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue =
                GarageService.PostInflateTiresToMaxByLicensePlate(
                    i_LicensePlate, out stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();
            return returnValue;
        }

        public Record PostInsertAssertedFuelCar(
            CreateAndInsertAssertedCarRequest
                i_Request, out string o_ResponseMessage)
        {
            Record returnValue = GarageService.CreateRecord(
                GarageService.CreateAssertedBatteryCar(i_Request),
                i_Request.Owner);

            PostInsert(returnValue, out StringBuilder stringBuilder);
            o_ResponseMessage = stringBuilder.ToString();

            return returnValue;
        }
    }
}
