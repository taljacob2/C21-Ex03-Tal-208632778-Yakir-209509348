using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl.Asserted;
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


        // TODO: disabled.
        // public void FuelVehicle(string i_LicensePlate,
        //     eType i_FuelType, float i_Amount)
        // {
        //     Record record =
        //         FindVehicleRecordByLicensePlate(i_LicensePlate);
        //     if (!(record.Vehicle is IFuelVehicle vehicle))
        //     {
        //         throw new ArgumentException("This Vehicle does not use Fuel.");
        //     }
        //
        //     vehicle.AddFuel(i_Amount, i_FuelType);
        // }

        // TODO: disabled.
        // public void FuelVehicle<T>(Vehicle io_Vehicle, float i_Amount) where
        //     T : IFuelVehicle
        // {
        //     if (!(record.Vehicle is IFuelVehicle vehicle))
        //     {
        //         throw new ArgumentException("This Vehicle does not use Fuel.");
        //     }
        //
        //     vehicle.AddFuel(i_Amount, i_FuelType);
        // }
    }
}
