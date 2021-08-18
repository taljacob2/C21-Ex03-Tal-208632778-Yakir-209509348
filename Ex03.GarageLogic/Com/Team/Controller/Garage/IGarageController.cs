using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.DTO.Model.Response;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;

namespace Ex03.GarageLogic.Com.Team.Controller.Garage
{
    public interface IGarageController
    {
        bool PostInsert(Vehicle i_Vehicle);

        List<string> GetLicensePlatesList();

        List<string> GetLicensePlatesList(Record.eState i_StateToSelect);

        bool PostNewState(NewStateRequest i_Request);

        bool PostInflateTiresToMax(string i_LicensePlate);

        bool PostFuel(FuelRequest i_Request);

        bool PostCharge(ChargeRequest i_Request);

        VehicleResponse GetVehicleDetails(string i_LicensePlate);
    }
}
