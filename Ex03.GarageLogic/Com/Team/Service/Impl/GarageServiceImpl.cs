using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;
using Ex03.GarageLogic.Com.Team.Misc;
using Ex03.GarageLogic.Com.Team.Repository;
using Ex03.GarageLogic.Com.Team.Repository.Impl;

namespace Ex03.GarageLogic.Com.Team.Service.Impl
{
    /// <summary>
    ///     Create `new` objects here.
    /// </summary>
    public class GarageServiceImpl : IGarageService
    {
        public IRecordRepository RecordRepository { get; } =
            new RecordRepositoryImpl();

        public Record CreateRecord(AssertedVehicle i_AssertedVehicle,
            Owner i_Owner)
        {
            return new Record(i_AssertedVehicle, i_Owner);
        }

        public void Refuel(RefuelRequest i_Request)
        {
            // TODO: continue implementation.
            Record record =
                RecordRepository.FindByLicensePlate(i_Request.LicensePlate);
        }

        public List<string> SelectVehicleLicensePlates()
        {
            return RecordRepository.SelectVehicleLicensePlates();
        }

        public List<string> SelectVehicleLicensePlates(
            Record.eState i_StateToSelect)
        {
            return RecordRepository.SelectVehicleLicensePlates(i_StateToSelect);
        }

        public Record Insert(Record io_Record,
            out StringBuilder o_ResponseMessage)
        {
            Record record =
                RecordRepository.Insert(io_Record, out o_ResponseMessage);

            // When the insert was failed:
            if (!o_ResponseMessage.ToString().Equals("success"))
            {
                record.State = Record.eState.InProgress;
                o_ResponseMessage.Append(Environment.NewLine);
                o_ResponseMessage.Append(
                    $"Changed Record's State to: `{Record.eState.InProgress:G}`.");
            }

            return record;
        }

        public AssertedVehicle CreateAssertedFuelCar(
            CreateAndInsertAssertedCarRequest i_Request)
        {
            return new AssertedFuelCar(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.Color,
                i_Request
                    .DoorsAmount,
                i_Request.TireManufacturerName);
        }

        public AssertedVehicle CreateAssertedBatteryCar(
            CreateAndInsertAssertedCarRequest i_Request)
        {
            return new AssertedBatteryCar(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.Color,
                i_Request
                    .DoorsAmount,
                i_Request.TireManufacturerName);
        }

        public AssertedVehicle CreateAssertedFuelMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request)
        {
            return new AssertedFuelMotorcycle(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.LicenseType,
                i_Request
                    .ExtendedEngineVolumeInCC,
                i_Request.TireManufacturerName);
        }

        public AssertedVehicle CreateAssertedBatteryMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request)
        {
            return new AssertedBatteryMotorcycle(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.LicenseType,
                i_Request
                    .ExtendedEngineVolumeInCC,
                i_Request.TireManufacturerName);
        }

        public AssertedVehicle CreateAssertedFuelTruck(
            CreateAndInsertAssertedTruckRequest i_Request)
        {
            return new AssertedFuelTruck(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.IsContainingDangerousMaterials,
                i_Request.MaxCarryingCapabilityInKilos,
                i_Request.TireManufacturerName);
        }

        public void SetState(SetStateRequest i_Request,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            try
            {
                Record record = RecordRepository.FindByLicensePlate(i_Request
                    .LicensePlate);
                record.State = i_Request.NewState;
                o_ResponseMessage.Append(
                    $"Changed Record's State to: `{i_Request.NewState:G}`.");
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        public void PostRecharge(RechargeRequest i_Request,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            try
            {
                Record record =
                    RecordRepository.FindByLicensePlate(i_Request.LicensePlate);
                postRecharge(record, i_Request.MinutesToAdd, o_ResponseMessage);
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        public void PostRefuel(RefuelRequest i_Request,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            try
            {
                Record record =
                    RecordRepository.FindByLicensePlate(i_Request.LicensePlate);
                postRefuel(record, i_Request.FuelType, i_Request.LitersToAdd,
                    o_ResponseMessage);
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        public void PostInflateTiresToMaxByLicensePlate(string i_LicensePlate,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            try
            {
                Record record =
                    RecordRepository.FindByLicensePlate(i_LicensePlate);

                typeOfSwitchForPSI(o_ResponseMessage, record);
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        public void GetRecordDetails(string i_LicensePlate,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            try
            {
                Record record =
                    RecordRepository.FindByLicensePlate(i_LicensePlate);
                o_ResponseMessage.Append("Record Found:" + Environment.NewLine +
                                         record);
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        private void postRecharge(Record io_Record, float i_RequestMinutesToAdd,
            StringBuilder o_ResponseMessage)
        {
            // BatteryEngine is a property. Find it:
            if (io_Record.AssertedVehicle.GetPropertyValue<BatteryEngine>
                ("BatteryEngine") != null)
            {
                BatteryEngine batteryEngine =
                    io_Record.AssertedVehicle.GetPropertyValue<BatteryEngine>
                        ("BatteryEngine");
                tryToRecharge(i_RequestMinutesToAdd, o_ResponseMessage,
                    batteryEngine);
            }
            else if (io_Record.AssertedVehicle.GetPropertyValue<ExtendedEngine>
                ("ExtendedEngine") != null)
            {
                ExtendedEngine extendedEngine =
                    io_Record.AssertedVehicle
                        .GetPropertyValue<ExtendedEngine>("ExtendedEngine");

                if (io_Record.AssertedVehicle.GetPropertyValue<BatteryEngine>
                    ("BatteryEngine") != null)
                {
                    BatteryEngine batteryEngine =
                        io_Record.AssertedVehicle
                            .GetPropertyValue<BatteryEngine>
                                ("BatteryEngine");
                    tryToRecharge(i_RequestMinutesToAdd, o_ResponseMessage,
                        batteryEngine);
                }
            }
            else
            {
                o_ResponseMessage.Append(
                    $"Recharge Failed. You do not own a {nameof(BatteryEngine)}.");
            }
        }

        private void tryToRecharge(float i_RequestMinutesToAdd,
            StringBuilder o_ResponseMessage, BatteryEngine io_BatteryEngine)
        {
            try
            {
                io_BatteryEngine.AddMinutes(i_RequestMinutesToAdd);
                o_ResponseMessage.Append(
                    $"Successful Recharge. You have `{io_BatteryEngine.Value}` hours." +
                    $" That is: {io_BatteryEngine.GetValuePercentage()}%");
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        private void postRefuel(Record io_Record, eType i_FuelType, float
            i_LitersToAdd, StringBuilder o_ResponseMessage)
        {
            // FuelEngine is a property. Find it:
            if (io_Record.AssertedVehicle.GetPropertyValue<FuelEngine>
                ("FuelEngine") != null)
            {
                FuelEngine fuelEngine =
                    io_Record.AssertedVehicle.GetPropertyValue<FuelEngine>
                        ("FuelEngine");
                tryToRefuel(i_FuelType, i_LitersToAdd, o_ResponseMessage,
                    fuelEngine);
            }
            else if (io_Record.AssertedVehicle.GetPropertyValue<ExtendedEngine>
                ("ExtendedEngine") != null)
            {
                ExtendedEngine extendedEngine =
                    io_Record.AssertedVehicle
                        .GetPropertyValue<ExtendedEngine>("ExtendedEngine");
                if (io_Record.AssertedVehicle.GetPropertyValue<FuelEngine>
                    ("FuelEngine") != null)
                {
                    FuelEngine fuelEngine =
                        io_Record.AssertedVehicle.GetPropertyValue<FuelEngine>
                            ("FuelEngine");
                    tryToRefuel(i_FuelType, i_LitersToAdd, o_ResponseMessage,
                        fuelEngine);
                }
            }
            else
            {
                o_ResponseMessage.Append(
                    $"Refuel Failed. You do not own a {nameof(FuelEngine)}.");
            }
        }

        private static void tryToRefuel(eType i_FuelType, float i_LitersToAdd,
            StringBuilder o_ResponseMessage, FuelEngine io_FuelEngine)
        {
            try
            {
                io_FuelEngine.AddFuelByManualRequest(i_FuelType,
                    i_LitersToAdd);
                o_ResponseMessage.Append(
                    $"Successful Refuel. You have `{io_FuelEngine.Value}` liters." +
                    $" That is: {io_FuelEngine.GetValuePercentage()}%");
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        private static void typeOfSwitchForPSI(StringBuilder o_ResponseMessage,
            Record io_Record)
        {
            float psi = 0;
            ComponentVehicle componentVehicle;
            if ((componentVehicle =
                io_Record.AssertedVehicle.GetPropertyValue<Car>
                    ("Car")) != null)
            {
                inflateWithSuccess(o_ResponseMessage, componentVehicle);
            }
            else if ((componentVehicle =
                io_Record.AssertedVehicle.GetPropertyValue<Car>
                    ("Motorcycle")) != null)
            {
                inflateWithSuccess(o_ResponseMessage, componentVehicle);
            }
            else if ((componentVehicle =
                io_Record.AssertedVehicle.GetPropertyValue<Car>
                    ("Truck")) != null)
            {
                inflateWithSuccess(o_ResponseMessage, componentVehicle);
            }
        }

        private static void inflateWithSuccess(StringBuilder o_ResponseMessage,
            ComponentVehicle i_ComponentVehicle)
        {
            float psi;
            i_ComponentVehicle.Tires.InflateAllTiresToMaxValue();
            psi = i_ComponentVehicle.Tires.GetManufacturerMaxValue();
            o_ResponseMessage.Append(
                $"Changed Tires' PSI to: `{psi}`.");
        }
    }
}
