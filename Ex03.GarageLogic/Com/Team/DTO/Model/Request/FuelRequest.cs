using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Engine.Standard.Fuel;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public struct FuelRequest
    {
        public string LicensePlate { get; }

        public eType FuelType { get; }

        public float Amount { get; }

        public FuelRequest(string i_LicensePlate, eType i_FuelType,
            float i_Amount)
        {
            LicensePlate = i_LicensePlate;
            FuelType = i_FuelType;
            Amount = i_Amount;
        }
    }
}
