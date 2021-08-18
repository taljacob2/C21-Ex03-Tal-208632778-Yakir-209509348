using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public struct NewStateRequest
    {
        public string LicensePlate { get; }

        public Record.eState NewState { get; }


        public NewStateRequest(string i_LicensePlate, Record.eState i_NewState)
        {
            LicensePlate = i_LicensePlate;
            NewState = i_NewState;
        }
    }
}
