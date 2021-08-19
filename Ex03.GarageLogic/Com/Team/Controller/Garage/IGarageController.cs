﻿using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.DTO.Model.Response;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage
{
    public interface IGarageController
    {
        /// <summary />
        /// <param name="io_Record" />
        /// <param name="o_ResponseMessage">
        ///     In case of success: <code>A-Success-Message</code>
        ///     In case of fail: <code>An-Error-Message</code>.
        /// </param>
        /// <returns>
        ///     Record retrieved / inserted.
        /// </returns>
        Record PostInsert(Record io_Record,
            out StringBuilder o_ResponseMessage);

        List<string> GetLicensePlatesList();

        List<string> GetLicensePlatesList(Record.eState i_StateToSelect);

        bool PostNewState(NewStateRequest i_Request);

        bool PostInflateTiresToMax(string i_LicensePlate);

        /// <summary>
        ///     A Request used for <see cref="FuelEngine" /> only.
        ///     Measured in `Liter` units.
        /// </summary>
        bool PostRefuel(RefuelRequest i_Request);

        /// <summary>
        ///     A Request used for <see cref="BatteryEngine" /> only.
        ///     Measured in `Minute` units.
        ///     <remarks>
        ///         Note: The <see cref="Manufactured.Value" /> is measured in
        ///         `Hour` units.
        ///     </remarks>
        /// </summary>
        bool PostRecharge(RechargeRequest i_Request);

        VehicleResponse GetVehicleDetails(string i_LicensePlate);

        Record PostCreateRecord(Vehicle i_Vehicle, Owner i_Owner);

        Record PostCreateAssertedFuelCar(CreateAssertedCarRequest i_Request);

        Record PostCreateAssertedBatteryCar(CreateAssertedCarRequest i_Request);
    }
}
