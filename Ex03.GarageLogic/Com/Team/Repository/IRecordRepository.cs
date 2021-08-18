using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.GarageLogic.Com.Team.Repository
{
    public interface IRecordRepository
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
        Record Insert(Record io_Record, out StringBuilder o_ResponseMessage);

        bool Delete(Record i_Record);

        Record? FindByLicensePlate(string i_LicensePlate);

        List<string> SelectVehicleLicensePlates();

        List<string> SelectVehicleLicensePlates(Record.eState i_StateToSelect);
    }
}
