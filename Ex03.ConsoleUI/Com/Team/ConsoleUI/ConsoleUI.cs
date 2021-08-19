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

            string validEnumStrings = ConsoleUI.validEnumStrings(
                EnumString.sr_Car, EnumString.sr_Motorcycle,
                EnumString.sr_Truck);
            string vehicleType = InputUtil.ConvertIgnoreCase(
                StringIndentation.IndentationString(i_IndentationLevel) +
                $"Enter {nameof(vehicleType)}: {validEnumStrings}",
                EnumString.Upper.sr_Car, EnumString.Upper.sr_Motorcycle,
                EnumString.Upper.sr_Truck);
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

        private static string validEnumStrings(params string[] i_ValidStrings)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < i_ValidStrings.Length; i++)
            {
                builder.Append("`");
                builder.Append(i_ValidStrings[i]);
                builder.Append("`");
                if (i < i_ValidStrings.Length - 1)
                {
                    builder.Append(" / ");
                }
            }

            builder.Append(": ");

            return builder.ToString();
        }

        private Vehicle createVehicleReturnValue(string i_VehicleType,
            string i_ModelName,
            string i_LicensePlate)
        {
            Vehicle returnValue = null;
            if (i_VehicleType.ToUpper()
                .Equals(EnumString.Upper.sr_Car))
            {
                returnValue = createCar(i_VehicleType, i_ModelName,
                    i_LicensePlate);
            }
            else if (i_VehicleType.ToUpper()
                .Equals(EnumString.Upper.sr_Motorcycle))
            {
                returnValue =
                    createMotorcycle(i_VehicleType, i_ModelName,
                        i_LicensePlate);
            }
            else if (i_VehicleType.ToUpper()
                .Equals(EnumString.Upper.sr_Truck))
            {
                returnValue = createTruck(i_VehicleType, i_ModelName,
                    i_LicensePlate);
            }

            return returnValue;
        }

        private Vehicle createCar(string i_VehicleType, string i_ModelName,
            string i_LicensePlate)
        {
            Tire tire = createTire();


            throw new NotImplementedException();
        }

        private Vehicle createMotorcycle(string i_VehicleType,
            string i_ModelName, string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        private Vehicle createTruck(string i_VehicleType, string i_ModelName,
            string i_LicensePlate)
        {
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

        private static class EnumString
        {
            public static class Upper
            {
                public static readonly string sr_Car = EnumString.sr_Car;

                public static readonly string sr_Motorcycle =
                    EnumString.sr_Motorcycle;

                public static readonly string sr_Truck = EnumString.sr_Truck;

                public static readonly string sr_Black = EnumString.sr_Black;

                public static readonly string sr_Red = EnumString.sr_Red;

                public static readonly string sr_Silver = EnumString.sr_Silver;

                public static readonly string sr_White = EnumString.sr_White;

                static Upper()
                {
                    // eVehicleType:
                    sr_Car = sr_Car.ToUpper();
                    sr_Motorcycle = sr_Motorcycle.ToUpper();
                    sr_Truck = sr_Truck.ToUpper();

                    // eColor:
                    sr_Black = sr_Black.ToUpper();
                    sr_Red = sr_Red.ToUpper();
                    sr_Silver = sr_Silver.ToUpper();
                    sr_White = sr_White.ToUpper();
                }
            }

            public static readonly string sr_Car = $"{eVehicleType.Car:G}";

            public static readonly string sr_Motorcycle =
                $"{eVehicleType.Motorcycle:G}";

            public static readonly string sr_Truck =
                $"{eVehicleType.Truck:G}";

            public static readonly string
                sr_Black = $"{Car.eColor.Black:G}";

            public static readonly string sr_Red = $"{Car.eColor.Red:G}";

            public static readonly string sr_Silver =
                $"{Car.eColor.Silver:G}";

            public static readonly string
                sr_White = $"{Car.eColor.White:G}";

            static EnumString() {}
        }

        private enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }
    }
}
