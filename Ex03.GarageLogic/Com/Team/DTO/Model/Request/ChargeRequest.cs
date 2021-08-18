namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    public struct ChargeRequest
    {
        public string LicensePlate { get; }

        /// <summary>
        ///     Measured in `Minute` units.
        /// </summary>
        public float AmountOfMinutesToCharge { get; }

        public ChargeRequest(string i_LicensePlate,
            float i_AmountOfMinutesToCharge)
        {
            LicensePlate = i_LicensePlate;
            AmountOfMinutesToCharge = i_AmountOfMinutesToCharge;
        }
    }
}
