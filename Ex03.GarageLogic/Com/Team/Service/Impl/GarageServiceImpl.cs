using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Asserted.Impl;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
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


        public Record CreateRecord(Vehicle i_Vehicle, Owner i_Owner)
        {
            return new Record(i_Vehicle, i_Owner);
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

        public Vehicle CreateAssertedFuelCar(
            CreateAndInsertAssertedCarRequest i_Request)
        {
            return new AssertedFuelCar(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.Color,
                i_Request
                    .DoorsAmount,
                i_Request.TireManufacturerName);
        }

        public Vehicle CreateAssertedBatteryCar(
            CreateAndInsertAssertedCarRequest i_Request)
        {
            return new AssertedBatteryCar(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.Color,
                i_Request
                    .DoorsAmount,
                i_Request.TireManufacturerName);
        }

        public Vehicle CreateAssertedFuelMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request)
        {
            return new AssertedFuelMotorcycle(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.LicenseType,
                i_Request
                    .ExtendedEngineVolumeInCC,
                i_Request.TireManufacturerName);
        }

        public Vehicle CreateAssertedBatteryMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request)
        {
            return new AssertedBatteryMotorcycle(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.LicenseType,
                i_Request
                    .ExtendedEngineVolumeInCC,
                i_Request.TireManufacturerName);
        }

        public Vehicle CreateAssertedFuelTruck(
            CreateAndInsertAssertedTruckRequest i_Request)
        {
            return new AssertedFuelTruck(i_Request
                    .ModelName, i_Request.LicensePlate,
                i_Request.IsContainingDangerousMaterials,
                i_Request.MaxCarryingCapabilityInKilos,
                i_Request.TireManufacturerName);
        }

        public bool SetState(SetStateRequest i_Request,
            out StringBuilder o_ResponseMessage)
        {
            bool returnValue = true;
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
                returnValue = false;
            }

            return returnValue;
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

        private void postRecharge(Record io_Record, float i_RequestMinutesToAdd,
            StringBuilder o_ResponseMessage)
        {
            if (io_Record.Vehicle.Engine is BatteryEngine)
            {
                BatteryEngine fuelEngine =
                    (BatteryEngine) io_Record.Vehicle.Engine;
                tryToRecharge(i_RequestMinutesToAdd, o_ResponseMessage, fuelEngine);
            }

            // Engine is a Property. Find it:
            else if (io_Record.Vehicle
                         .GetPropertyValue<ExtendedEngine>("ExtendedEngine") !=
                     null)
            {
                ExtendedEngine extendedEngine = io_Record.Vehicle
                    .GetPropertyValue<ExtendedEngine>
                        ("ExtendedEngine");
                extendedEngineInvokeTryRecharge(i_RequestMinutesToAdd,
                    o_ResponseMessage, extendedEngine);
            }
            else if (io_Record.Vehicle.GetPropertyValue<ExtendedEngine>
                ("Engine") != null)
            {
                // Just for backup. // todo : may remove.
                ExtendedEngine extendedEngine = io_Record.Vehicle
                    .GetPropertyValue<ExtendedEngine>
                        ("Engine");
                extendedEngineInvokeTryRecharge(i_RequestMinutesToAdd,
                    o_ResponseMessage, extendedEngine);
            }
            else
            {
                o_ResponseMessage.Append(
                    $"Recharge Failed. You do not own a {nameof(BatteryEngine)}.");
            }
        }

        private void extendedEngineInvokeTryRecharge(
            float i_RequestMinutesToAdd, StringBuilder o_ResponseMessage,
            ExtendedEngine io_ExtendedEngine)
        {
            Engine engine =
                io_ExtendedEngine.GetPropertyValue<Engine>("Engine");
            if (engine is BatteryEngine)
            {
                BatteryEngine batteryEngine = (BatteryEngine) engine;
                tryToRecharge(i_RequestMinutesToAdd, o_ResponseMessage,
                    batteryEngine);
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
                    $"Successful Recharge. You have `{io_BatteryEngine.Value}` hours.");
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

        private void postRefuel(Record io_Record, eType i_FuelType, float
            i_LitersToAdd, StringBuilder o_ResponseMessage)
        {
            if (io_Record.Vehicle.Engine is FuelEngine)
            {
                FuelEngine fuelEngine =
                    (FuelEngine) io_Record.Vehicle.Engine;
                tryToRefuel(i_FuelType, i_LitersToAdd, o_ResponseMessage,
                    fuelEngine);
            }

            // Engine is a Property. Find it:
            else if (io_Record.Vehicle
                         .GetPropertyValue<ExtendedEngine>("ExtendedEngine") !=
                     null)
            {
                ExtendedEngine extendedEngine = io_Record.Vehicle
                    .GetPropertyValue<ExtendedEngine>
                        ("ExtendedEngine");
                extendedEngineInvokeTryRefuel(i_FuelType, i_LitersToAdd,
                    o_ResponseMessage, extendedEngine);
            }
            else if (io_Record.Vehicle.GetPropertyValue<ExtendedEngine>
                ("Engine") != null)
            {
                // Just for backup. // todo : may remove.
                ExtendedEngine extendedEngine = io_Record.Vehicle
                    .GetPropertyValue<ExtendedEngine>
                        ("Engine");
                extendedEngineInvokeTryRefuel(i_FuelType, i_LitersToAdd,
                    o_ResponseMessage, extendedEngine);
            }
            else
            {
                o_ResponseMessage.Append(
                    $"Refuel Failed. You do not own a {nameof(FuelEngine)}.");
            }
        }

        private static void extendedEngineInvokeTryRefuel(eType i_FuelType,
            float i_LitersToAdd, StringBuilder o_ResponseMessage,
            ExtendedEngine i_ExtendedEngine)
        {
            Engine engine =
                i_ExtendedEngine.GetPropertyValue<Engine>("Engine");
            if (engine is FuelEngine)
            {
                FuelEngine fuelEngine = (FuelEngine) engine;
                tryToRefuel(i_FuelType, i_LitersToAdd, o_ResponseMessage,
                    fuelEngine);
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
                    $"Successful Refuel. You have `{io_FuelEngine.Value}` liters.");
            }
            catch (System.Exception e)
            {
                o_ResponseMessage.Append(e.Message);
            }
        }

        public bool PostInflateTiresToMaxByLicensePlate(string i_LicensePlate,
            out StringBuilder o_ResponseMessage)
        {
            bool returnValue = true;
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
                returnValue = false;
            }

            return returnValue;
        }

        private static void typeOfSwitchForPSI(StringBuilder o_ResponseMessage,
            Record io_Record)
        {
            float psi = 0;
            if (io_Record.Vehicle is ComponentVehicle)
            {
                Tires tires = ((ComponentVehicle) io_Record.Vehicle).Tires;
                tires.InflateAllTiresToMaxValue();
                psi = tires.GetManufacturerMaxValue();

                o_ResponseMessage.Append(
                    $"Changed Tires' PSI to: `{psi}`.");
            }
            else if (io_Record.Vehicle is AssertedVehicle)
            {
                Tires tires = ((ComponentVehicle) io_Record.Vehicle).Tires;
                tires.InflateAllTiresToMaxValue();
                psi = tires.GetManufacturerMaxValue();

                o_ResponseMessage.Append(
                    $"Changed Tires' PSI to: `{psi}`.");
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
    }
}
