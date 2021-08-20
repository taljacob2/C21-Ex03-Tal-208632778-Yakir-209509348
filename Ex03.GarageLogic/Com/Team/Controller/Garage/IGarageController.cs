using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage
{
    public interface IGarageController
    {
        List<string> GetLicensePlatesList();

        List<string> GetLicensePlatesList(Record.eState i_StateToSelect);

        void PostSetState(SetStateRequest i_Request,
            out string o_ResponseMessage);

        void PostInflateTiresToMaxByLicensePlate(string i_LicensePlate,
            out string o_ResponseMessage);

        /// <summary>
        ///     A Request used for <see cref="FuelEngine" /> only.
        ///     Measured in `Liter` units.
        /// </summary>
        void PostRefuel(RefuelRequest i_Request, out string o_ResponseMessage);

        /// <summary>
        ///     A Request used for <see cref="BatteryEngine" /> only.
        ///     Measured in `Minute` units.
        ///     <remarks>
        ///         Note: The <see cref="Manufactured.Value" /> is measured in
        ///         `Hour` units.
        ///     </remarks>
        /// </summary>
        void PostRecharge(RechargeRequest i_Request,
            out string o_ResponseMessage);

        void GetRecordDetails(string i_LicensePlate,
            out string o_ResponseMessage);

        Record PostCreateAndInsertAssertedFuelCar(
            CreateAndInsertAssertedCarRequest i_Request,
            out string o_ResponseMessage);

        Record PostCreateAndInsertAssertedBatteryCar(
            CreateAndInsertAssertedCarRequest i_Request,
            out string o_ResponseMessage);

        Record PostCreateAndInsertAssertedFuelMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request,
            out string o_ResponseMessage);

        Record PostCreateAndInsertAssertedBatteryMotorcycle(
            CreateAndInsertAssertedMotorcycleRequest i_Request,
            out string o_ResponseMessage);

        Record PostCreateAndInsertAssertedFuelTruck(
            CreateAndInsertAssertedTruckRequest i_Request,
            out string o_ResponseMessage);
    }
}
