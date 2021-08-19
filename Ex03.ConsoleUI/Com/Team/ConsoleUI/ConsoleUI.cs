using System;
using System.Text;
using Ex03.ConsoleUI.Com.Team.Misc;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl;

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
            Console.Out.WriteLine($"Create {nameof(Record)}:");
            const int k_IndentationLevel = 1;
            Owner owner = createOwner(k_IndentationLevel);
            Vehicle vehicle = createVehicle(k_IndentationLevel);
            return GarageController.PostCreateRecord(vehicle, owner);
        }

        private Owner createOwner(int i_IndentationLevel)
        {
            Console.Out.WriteLine($"Create {nameof(Owner)}:");
            string name =
                InputUtil.Convert<string>(
                    StringIndentation.IndentationString(i_IndentationLevel) +
                    $"Enter {nameof(name)}: ");
            string phoneNumber =
                InputUtil.Convert<string>(
                    StringIndentation.IndentationString(i_IndentationLevel) +
                    $"Enter {nameof(phoneNumber)}: ");
            return new Owner(phoneNumber, name);
        }

        private Vehicle createVehicle(int i_IndentationLevel)
        {
            Console.Out.WriteLine($"Create {nameof(Vehicle)}:");
            string vehicleType = InputUtil.ConvertIgnoreCase(
                StringIndentation.IndentationString(i_IndentationLevel) +
                "Enter vehicle-type: ",
                EnumUpperString.sr_CarStringUpper, EnumUpperString
                    .sr_MotorcycleStringUpper,
                EnumUpperString.sr_TruckStringUpper);
            string modelName =
                InputUtil.Convert<string>(
                    StringIndentation.IndentationString(i_IndentationLevel) +
                    $"Enter {nameof(modelName)}: ");
            string licensePlate =
                InputUtil.Convert<string>(
                    StringIndentation.IndentationString(i_IndentationLevel) +
                    $"Enter {nameof(licensePlate)}: ");

            return createVehicleReturnValue(vehicleType, modelName,
                licensePlate);
        }

        private Vehicle createVehicleReturnValue(string i_VehicleType,
            string i_ModelName,
            string i_LicensePlate)
        {
            Vehicle returnValue = null;
            if (i_VehicleType.ToUpper()
                .Equals(EnumUpperString.sr_CarStringUpper))
            {
                returnValue = createCar(i_VehicleType, i_ModelName,
                    i_LicensePlate);
            }
            else if (i_VehicleType.ToUpper()
                .Equals(EnumUpperString.sr_MotorcycleStringUpper))
            {
                returnValue =
                    createMotorcycle(i_VehicleType, i_ModelName,
                        i_LicensePlate);
            }
            else if (i_VehicleType.ToUpper()
                .Equals(EnumUpperString.sr_TruckStringUpper))
            {
                returnValue = createTruck(i_VehicleType, i_ModelName,
                    i_LicensePlate);
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


            throw new NotImplementedException();
        }

        private Tire createTire()
        {
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

        private static class EnumUpperString
        {
            public static readonly string sr_CarStringUpper =
                $"{eVehicleType.Car:G}";

            public static readonly string sr_MotorcycleStringUpper =
                $"{eVehicleType.Motorcycle:G}";

            public static readonly string sr_TruckStringUpper =
                $"{eVehicleType.Truck:G}";

            public static readonly string sr_BlackStringUpper =
                $"{Car.eColor.Black:G}";

            public static readonly string sr_RedStringUpper =
                $"{Car.eColor.Red:G}";

            public static readonly string sr_SilverStringUpper =
                $"{Car.eColor.Silver:G}";

            public static readonly string sr_WhiteStringUpper =
                $"{Car.eColor.White:G}";

            static EnumUpperString()
            {
                // eVehicleType:
                sr_CarStringUpper = sr_CarStringUpper.ToUpper();
                sr_MotorcycleStringUpper = sr_MotorcycleStringUpper.ToUpper();
                sr_TruckStringUpper = sr_TruckStringUpper.ToUpper();

                // eColor:
                sr_BlackStringUpper = sr_BlackStringUpper.ToUpper();
                sr_RedStringUpper = sr_RedStringUpper.ToUpper();
                sr_SilverStringUpper = sr_SilverStringUpper.ToUpper();
                sr_WhiteStringUpper = sr_WhiteStringUpper.ToUpper();
            }
        }

        private enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }
    }
}
