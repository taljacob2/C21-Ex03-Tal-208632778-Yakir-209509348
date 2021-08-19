using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.Database;

namespace Ex03.GarageLogic.Com.Team.Repository.Impl
{
    public class RecordRepositoryImpl : IRecordRepository
    {
        private const string k_SuccessResponseMessage = "success";

        private readonly IDatabase<List<Record>> r_Database =
            new Database.Impl.Database();

        /// <summary />
        /// <param name="io_Record" />
        /// <param name="o_ResponseMessage">
        ///     In case of success: <see cref="k_SuccessResponseMessage" />
        ///     In case of fail: <code>An-Error-Message</code>.
        /// </param>
        /// <returns>
        ///     Record retrieved / inserted.
        /// </returns>
        public Record Insert(Record io_Record,
            out StringBuilder o_ResponseMessage)
        {
            o_ResponseMessage = new StringBuilder();
            Record returnValue;
            try
            {
                Record? foundNullableRecord =
                    FindByLicensePlate(io_Record.Vehicle.LicensePlate);
                returnValue = foundNullableRecord.Value;
                o_ResponseMessage.Append(
                        $"The provided LicensePlate: `{returnValue.Vehicle.LicensePlate}` is already in database.");
            }
            catch (System.Exception e)
            {
                r_Database.GetRef().Add(io_Record);
                returnValue = io_Record;
                o_ResponseMessage.Append(k_SuccessResponseMessage);
            }
            
            return returnValue;
        }

        public bool Delete(Record i_Record)
        {
            bool returnValue = true;

            if (r_Database.GetRef().Contains(i_Record))
            {
                returnValue = false;
            }
            else
            {
                r_Database.GetRef().Remove(i_Record);
            }

            return returnValue;
        }

        /// <summary />
        /// <param name="i_LicensePlate">Serves as <see langword="Key" />.</param>
        /// <returns>Nullable Record found, in case of success.</returns>
        /// <exception cref="ArgumentException">
        ///     Error, if there is no existing Record found.
        /// </exception>
        public Record? FindByLicensePlate(string i_LicensePlate)
        {
            Record? returnValue = null; // `Nullable` implementation ready.
            List<string> licensePlates = SelectVehicleLicensePlates();

            for (int i = 0; i < licensePlates.Count; i++)
            {
                if (licensePlates[i].Equals(i_LicensePlate))
                {
                    returnValue = r_Database.GetRef()[i];
                    break;
                }
            }

            // Throw exception. // TODO: check if "logically" this is an ArgumentException.
            if (!returnValue.HasValue)
            {
                throw new ArgumentException(
                    $"LicensePlate provided: {i_LicensePlate} ->" +
                    " Record does not exist in database.");
            }

            return returnValue;
        }

        public List<string> SelectVehicleLicensePlates()
        {
            return r_Database.GetRef()
                .Select(i_Record => i_Record.Vehicle.LicensePlate).ToList();
        }

        public List<string> SelectVehicleLicensePlates(
            Record.eState i_StateToSelect)
        {
            return r_Database.GetRef()
                .FindAll(i_Record => i_Record.State == i_StateToSelect)
                .Select(i_Record => i_Record.Vehicle.LicensePlate)
                .ToList();
        }
    }
}
