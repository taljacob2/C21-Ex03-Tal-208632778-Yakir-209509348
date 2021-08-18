namespace Ex03.GarageLogic.Com.Team.DTO.Model.Request
{
    /// <summary>
    ///     A Request used for <see cref="BatteryEngine" /> only.
    /// </summary>
    public struct RechargeRequest
    {
        public string LicensePlate { get; }

        /// <summary>
        ///     Measured in `Minute` units.
        ///     <remarks>
        ///         Note: The <see cref="Engine.ManufacturerMaxEnergy" /> is measured in
        ///         `Hour` units.
        ///     </remarks>
        /// </summary>
        public float MinutesToAdd { get; }

        public RechargeRequest(string i_LicensePlate, float i_MinutesToAdd)
        {
            LicensePlate = i_LicensePlate;
            MinutesToAdd = i_MinutesToAdd;
        }
    }
}
