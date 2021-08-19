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
        private static class EnumUpperString
        {
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
        }


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
            const int k_Indentation = 1;
            Console.Out.WriteLine("Create Owner:");
            string name =
                InputUtil.Convert<string>(
                    indentationString(k_Indentation) + "Enter name: ");
            string phoneNumber =
                InputUtil.Convert<string>(
                    indentationString(k_Indentation) + "Enter phone-number: ");
            return new Owner(phoneNumber, name);
        }

        private Vehicle createVehicle()
        {
            const int k_Indentation = 1;
            Console.Out.WriteLine("Create Vehicle:");
            string vehicleType = InputUtil.ConvertIgnoreCase(
                indentationString(k_Indentation) + "Enter vehicle-type: ",
                EnumUpperString.sr_CarStringUpper, EnumUpperString
                    .sr_MotorcycleStringUpper,
                EnumUpperString.sr_TruckStringUpper);
            string modelName =
                InputUtil.Convert<string>(
                    indentationString(k_Indentation) + "Enter name: ");
            string licensePlate =
                InputUtil.Convert<string>(
                    indentationString(k_Indentation) + "Enter phone-number: ");

            Vehicle returnValue = null;
            if (vehicleType.ToUpper().Equals(EnumUpperString.sr_CarStringUpper))
            {
                returnValue = createCar(vehicleType, modelName, licensePlate);
            }
            else if (vehicleType.ToUpper()
                .Equals(EnumUpperString.sr_MotorcycleStringUpper))
            {
                returnValue =
                    createMotorcycle(vehicleType, modelName, licensePlate);
            }
            else if (vehicleType.ToUpper()
                .Equals(EnumUpperString.sr_TruckStringUpper))
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

        private enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        private static string indentationString(int i_IndentationLevel)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= i_IndentationLevel; i++)
            {
                builder.Append("    ");
            }

            return builder.ToString();
        }
    }
}
