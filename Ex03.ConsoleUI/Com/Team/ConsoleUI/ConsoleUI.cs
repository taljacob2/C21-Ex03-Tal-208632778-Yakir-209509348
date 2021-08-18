using System;
using System.Text;
using Ex03.ConsoleUI.Com.Team.Misc;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Car;

namespace Ex03.ConsoleUI.Com.Team.ConsoleUI
{
    public class ConsoleUI
    {
        public IGarageController GarageController { get; } =
            new GarageControllerImpl();

        public void RunConsoleUI()
        {
            // DEBUG: test
            printLicensePlates();

            // DEBUG: test 
            GarageController.PostInsert(new Record(new Car(new CarConstructorDTO
                    ("modelName3", "licensePlate4",
                        new Tire("talINC", 32, 0), Car.eColor.Black,
                        Car.eDoorsAmount.Four, new BatteryEngine(3.2F))),
                    new Owner("054noregex...", "tal")),
                out StringBuilder responseMessage);

            Console.Out.WriteLine(responseMessage);

            // DEBUG: test 
            PostCreateRecord();

            // printMenu();
        }

        public Record PostCreateRecord()
        {
            Owner owner = createOwner();
            Vehicle vehicle = createVehicle();
            return GarageController.PostCreateRecord(vehicle, owner);
        }

        private Owner createOwner()
        {
            Console.Out.WriteLine("Create Owner:");
            string name = InputUtil.Convert<string>("  Enter name: ");
            string phoneNumber =
                InputUtil.Convert<string>("  Enter phone-number: ");
            return new Owner(phoneNumber, name);
        }

        private Vehicle createVehicle()
        {
            string carStringUpper = $"{eVehicleType.Car:G}";
            carStringUpper = carStringUpper.ToUpper();
            string motorcycleStringUpper = $"{eVehicleType.Motorcycle:G}";
            motorcycleStringUpper = motorcycleStringUpper.ToUpper();
            string truckStringUpper = $"{eVehicleType.Truck:G}";
            truckStringUpper = truckStringUpper.ToUpper();

            Console.Out.WriteLine("Create Vehicle:");
            string vehicleType = InputUtil.ConvertIgnoreCase<string>(
                "  Enter vehicle-type: ",
                carStringUpper, motorcycleStringUpper, truckStringUpper);
            string modelName = InputUtil.Convert<string>("  Enter name: ");
            string licensePlate =
                InputUtil.Convert<string>("  Enter phone-number: ");

            Vehicle returnValue = null;
            if (vehicleType.ToUpper().Equals(carStringUpper))
            {
                returnValue = createCar(vehicleType, modelName, licensePlate);
            }
            else if (vehicleType.ToUpper().Equals(motorcycleStringUpper))
            {
                returnValue =
                    createMotorcycle(vehicleType, modelName, licensePlate);
            }
            else if (vehicleType.ToUpper().Equals(truckStringUpper))
            {
                returnValue = createTruck(vehicleType, modelName, licensePlate);
            }

            return returnValue;
        }

        private Vehicle createTruck(string i_VehicleType, string i_ModelName,
            string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        private Vehicle createMotorcycle(string i_VehicleType,
            string i_ModelName, string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        private Vehicle createCar(string i_VehicleType, string i_ModelName,
            string i_LicensePlate)
        {
            Tire tire = createTire();

            string blackStringUpper = $"{Car.eColor.Black:G}";
            blackStringUpper = blackStringUpper.ToUpper();
            string redStringUpper = $"{Car.eColor.Red:G}";
            redStringUpper = redStringUpper.ToUpper();
            string silverStringUpper = $"{Car.eColor.Silver:G}";
            silverStringUpper = silverStringUpper.ToUpper();
            string whiteStringUpper = $"{Car.eColor.White:G}";
            whiteStringUpper = whiteStringUpper.ToUpper();
            
            
            throw new NotImplementedException();
        }

        private void printLicensePlates()
        {
            foreach (string licensePlate in GarageController
                .GetLicensePlatesList()
            )
            {
                Console.Out.WriteLine(licensePlate);
            }
        }

        private void printSelectedLicensePlates(Record.eState i_State)
        {
            foreach (string licensePlate in GarageController
                .GetLicensePlatesList(i_State)
            )
            {
                Console.Out.WriteLine(licensePlate);
            }
        }

        private void printMenu()
        {
            throw new NotImplementedException();
        }

        private enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }
    }
}
