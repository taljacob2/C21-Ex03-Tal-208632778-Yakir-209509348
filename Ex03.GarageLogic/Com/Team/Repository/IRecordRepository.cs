using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.GarageLogic.Com.Team.Repository
{
    public interface IRecordRepository
    {
        bool Insert(Record i_Record);

        bool Delete(Record i_Record);

        Record? FindByLicensePlate(string i_LicensePlate);
    }
}
