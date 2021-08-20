using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;

namespace Ex03.GarageLogic.Com.Team.Service
{
    /// <summary>
    ///     Creates `new` objects here.
    /// </summary>
    public interface IGarageService
    {
        Record CreateRecord(Vehicle i_Vehicle, Owner i_Owner);

        void Refuel(RefuelRequest i_Request);

        List<string> SelectVehicleLicensePlates();

        List<string> SelectVehicleLicensePlates(Record.eState i_StateToSelect);
        
        /// <summary />
        /// <param name="io_Record" />
        /// <param name="o_ResponseMessage">
        ///     In case of success: <code>A-Success-Message</code>
        ///     In case of fail: <code>An-Error-Message</code>.
        /// </param>
        /// <returns>
        ///     Record retrieved / inserted.
        /// </returns>
        Record Insert(Record io_Record, out StringBuilder o_ResponseMessage);

        Vehicle CreateAssertedFuelCar(
            CreateAndInsertAssertedCarRequest i_Request);

        Vehicle CreateAssertedBatteryCar(
            CreateAndInsertAssertedCarRequest i_Request);

        Vehicle CreateAssertedFuelMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request);

        Vehicle CreateAssertedBatteryMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request);

        Vehicle CreateAssertedFuelTruck(
            CreateAndInsertAssertedTruckRequest i_Request);

        bool SetState(SetStateRequest i_Request,
            out StringBuilder o_ResponseMessage);

        bool PostInflateTiresToMaxByLicensePlate(string i_LicensePlate,
            out StringBuilder o_ResponseMessage);

        void GetRecordDetails(string i_LicensePlate,
            out StringBuilder o_ResponseMessage);

        void PostRefuel(RefuelRequest i_Request, out StringBuilder
            o_ResponseMessage);

        void PostRecharge(RechargeRequest i_Request, out StringBuilder
            o_ResponseMessage);
    }
}
