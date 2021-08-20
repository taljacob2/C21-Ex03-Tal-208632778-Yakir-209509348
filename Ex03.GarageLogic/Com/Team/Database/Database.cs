using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.GarageLogic.Com.Team.Database
{
    /// <summary>
    ///     Singleton implemented.
    ///     <remarks><see cref="Record" /> is unique.</remarks>
    /// </summary>
    public class Database : IDatabase<List<Record>>
    {
        public Database()
        {
            initInstance();
        }

        private List<Record> InstanceOfRecords { get; set; }

        public List<Record> Records { get; private set; }

        public List<Record> GetRef()
        {
            initInstance();
            return InstanceOfRecords;
        }

        private void initInstance()
        {
            if (InstanceOfRecords == null)
            {
                Records = new List<Record>();
                InstanceOfRecords = Records;
            }
        }
    }
}
