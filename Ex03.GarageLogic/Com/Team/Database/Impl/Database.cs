using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Car;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Motorcycle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Truck;

namespace Ex03.GarageLogic.Com.Team.Database.Impl
{
    /// <summary>
    ///     Singleton implemented.
    ///     <remarks><see cref="Record" /> is unique.</remarks>
    /// </summary>
    public class Database : IDatabase<List<Record>>, IBootable
    {
        public Database()
        {
            initInstance();
        }

        private List<Record> InstanceOfVehicles { get; set; }

        public List<Record> Vehicles { get; private set; }

        public void Boot()
        {
            List<Record> listToAddOnBoot = new List<Record>
            {
                new Record(new Motorcycle(new MotorcycleConstructorDTO
                    ("modelName1", "licensePlate1",
                        new Tire("talINC", 30, 0), Motorcycle.eLicenseType.A,
                        new ExtendedEngine(new FuelEngine(eType.Octan98, 6),
                            2000))),
                    new Owner("054noregex...", "tal")),

                new Record(new Motorcycle(new MotorcycleConstructorDTO
                    ("modelName2", "licensePlate2",
                        new Tire("talINC", 30, 0), Motorcycle.eLicenseType.A,
                        new ExtendedEngine(new BatteryEngine(1.8F), 2000))),
                    new Owner("054noregex...", "tal")),

                new Record(new Car(new CarConstructorDTO
                    ("modelName3", "licensePlate3",
                        new Tire("talINC", 32, 0), Car.eColor.Black,
                        Car.eDoorsAmount.Four,
                        new FuelEngine(eType.Octan95, 45))),
                    new Owner("054noregex...", "tal")),

                new Record(new Car(new CarConstructorDTO
                    ("modelName3", "licensePlate4",
                        new Tire("talINC", 32, 0), Car.eColor.Black,
                        Car.eDoorsAmount.Four, new BatteryEngine(3.2F))),
                    new Owner("054noregex...", "tal")),

                new Record(new Truck(new TruckConstructorDTO(
                        "modelName3", "licensePlate5",
                        new Tire("talINC", 26, 0), true,
                        100000, new FuelEngine(eType.Soler, 120))),
                    new Owner("054noregex...", "tal"))
            };

            GetRef().AddRange(listToAddOnBoot);
        }

        public List<Record> GetRef()
        {
            initInstance();
            return InstanceOfVehicles;
        }

        private void initInstance()
        {
            if (InstanceOfVehicles == null)
            {
                Vehicles = new List<Record>();
                InstanceOfVehicles = Vehicles;
                Boot(); // Note: Boot is called last. 
            }
        }
    }
}
