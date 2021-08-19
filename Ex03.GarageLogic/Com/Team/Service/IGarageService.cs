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
        
        Vehicle CreateAssertedFuelCar(CreateAssertedCarRequest io_CreateAssertedCarRequest);
        Vehicle CreateAssertedBatteryCar(CreateAssertedCarRequest i_Request);
    }
}
