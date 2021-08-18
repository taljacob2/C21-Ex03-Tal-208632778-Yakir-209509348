using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;

namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    /// <summary>
    ///     A Request used for <see cref="FuelEngine" /> only.
    /// </summary>
    public struct RefuelRequest
    {
        public string LicensePlate { get; }

        public eType FuelType { get; }

        /// <summary>
        ///     Measured in `Liter` units.
        /// </summary>
        public float LitersToAdd { get; }

        public RefuelRequest(string i_LicensePlate, eType i_FuelType,
            float i_Amount)
        {
            LicensePlate = i_LicensePlate;
            FuelType = i_FuelType;
            LitersToAdd = i_Amount;
        }
    }
}
