using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl.Asserted;
using Ex03.GarageLogic.Com.Team.Repository;
using Ex03.GarageLogic.Com.Team.Repository.Impl;

namespace Ex03.GarageLogic.Com.Team.Service.Impl
{
    /// <summary>
    /// Create `new` objects here. 
    /// </summary>
    public class GarageServiceImpl : IGarageService
    {
        public IRecordRepository RecordRepository { get; } =
            new RecordRepositoryImpl();

        public Record CreateRecord(VehicleComponent i_VehicleComponent, Owner i_Owner)
        {
            return new Record(i_VehicleComponent, i_Owner);
        }
        

        public void Refuel(RefuelRequest i_Request)
        {
            // TODO: continue implementation.
            Record? nullableRecord =
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

        public VehicleComponent CreateAssertedFuelCar(
            CreateAssertedCarRequest io_CreateAssertedCarRequest)
        {
            CreateRecord(new AssertedFuelCar(io_CreateAssertedCarRequest
                        .ModelName, io_CreateAssertedCarRequest.LicensePlate,
                    io_CreateAssertedCarRequest.Color,
                    io_CreateAssertedCarRequest
                        .DoorsAmount,
                    io_CreateAssertedCarRequest.TireManufacturerName),
                io_CreateAssertedCarRequest.Owner);
            
            throw new NotImplementedException();
        }

        public VehicleComponent CreateAssertedBatteryCar(CreateAssertedCarRequest i_Request)
        {
            throw new NotImplementedException();
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
