using System;
using System.Runtime;
using System.Text;
using Ex03.ConsoleUI.Com.Team.Misc;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
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
            int indentationLevel = 0;
            Console.Out.WriteLine(
                $"{StringIndentation.Create(indentationLevel)}Create {nameof(Record)}:");
            Owner owner = createOwner(ref indentationLevel);
            return createVehicle(owner, ref indentationLevel);
        }

        private Owner createOwner(ref int io_IndentationLevel)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{indentationString}Create {nameof(Owner)}:");
            string name =
                InputUtil.Convert<string>(
                    $"{indentationString}Enter {nameof(name)}: ");
            string phoneNumber =
                InputUtil.Convert<string>(
                    $"{indentationString}Enter {nameof(phoneNumber)}: ");

            io_IndentationLevel--;

            return new Owner(phoneNumber, name);
        }

        private Record createVehicle(Owner i_Owner,
            ref int io_IndentationLevel)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{StringIndentation.Create(io_IndentationLevel)}Create {nameof(Vehicle)}:");
            string vehicleType = createVehicleType(indentationString);
            string modelName =
                InputUtil.Convert<string>(
                    $"{indentationString}Enter {nameof(modelName)}: ");
            string licensePlate =
                InputUtil.Convert<string>(
                    $"{indentationString}Enter {nameof(licensePlate)}: ");

            io_IndentationLevel--;

            return createVehicleTypeSwitch(i_Owner, ref io_IndentationLevel,
                vehicleType,
                modelName, licensePlate);
        }

        private static string createVehicleType(string i_IndentationString)
        {
            string validEnumStrings = createValidStringsMessage(
                EnumString.sr_Car, EnumString.sr_Motorcycle,
                EnumString.sr_Truck);
            string vehicleType = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(vehicleType)}: {validEnumStrings}",
                EnumString.Upper.sr_Car, EnumString.Upper.sr_Motorcycle,
                EnumString.Upper.sr_Truck);
            return vehicleType;
        }

        private static string createValidStringsMessage(
            params string[] i_ValidStrings)
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

        private Record createVehicleTypeSwitch(Owner i_Owner,
            ref int io_IndentationLevel,
            string i_VehicleType, string i_ModelName, string i_LicensePlate)
        {
            io_IndentationLevel++;

            Record returnValue;
            string valueToSwitch = i_VehicleType.ToUpper();
            if (valueToSwitch.Equals(EnumString.Upper.sr_Car))
            {
                returnValue = createCar(i_Owner, ref io_IndentationLevel,
                    i_ModelName, i_LicensePlate);
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Motorcycle))
            {
                returnValue =
                    createMotorcycle(i_Owner, ref io_IndentationLevel,
                        i_ModelName, i_LicensePlate);
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Truck))
            {
                returnValue = createTruck(i_Owner, ref io_IndentationLevel,
                    i_ModelName, i_LicensePlate);
            }

            io_IndentationLevel--;

            return returnValue;
        }

        private Record createCar(Owner i_Owner,
            ref int io_IndentationLevel,
            string i_ModelName, string i_LicensePlate)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine($"{indentationString}Create {nameof(Car)}:");
            string tireManufacturerName =
                createTireManufacturerName(ref io_IndentationLevel);
            Car.eColor color = createColor(indentationString);
            Car.eDoorsAmount doorsAmount = createDoorsAmount(indentationString);
            GarageEnums.eEngineType engineType =
                createEngineType(indentationString);

            io_IndentationLevel--;

            return createCarTypeSwitch(i_Owner, i_ModelName, i_LicensePlate,
                tireManufacturerName, color, doorsAmount, engineType);
        }

        private Record createCarTypeSwitch(Owner i_Owner, string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName, Car.eColor i_Color,
            Car.eDoorsAmount i_DoorsAmount,
            GarageEnums.eEngineType i_EngineType)
        {
            CreateAssertedCarRequest request = new CreateAssertedCarRequest(
                i_Owner,
                i_ModelName, i_LicensePlate, i_TireManufacturerName,
                i_Color, i_DoorsAmount, i_EngineType);
            Record? nullableReturnValue = null;
            GarageEnums.eEngineType valueToSwitch = i_EngineType;
            string responseMessage = "";
            if (valueToSwitch == GarageEnums.eEngineType.Fuel)
            {
                nullableReturnValue =
                    GarageController.PostCreateAssertedFuelCar(request, out
                        responseMessage);
            }
            else if (valueToSwitch == GarageEnums.eEngineType.Battery)
            {
                nullableReturnValue =
                    GarageController.PostCreateAssertedBatteryCar(request, out
                        responseMessage);
            }

            Console.Out.WriteLine(responseMessage);

            return nullableReturnValue.Value;
        }

        private GarageEnums.eEngineType createEngineType(
            string i_IndentationString)
        {
            string validEnumStrings = createValidStringsMessage(
                EnumString.sr_Fuel, EnumString.sr_Battery);
            string engineType = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(engineType)}: {validEnumStrings}",
                EnumString.Upper.sr_Fuel, EnumString.Upper.sr_Battery);

            string valueToSwitch = engineType.ToUpper();
            GarageEnums.eEngineType? nullableOfReturnValue = null;
            if (valueToSwitch.Equals(EnumString.Upper.sr_Fuel))
            {
                nullableOfReturnValue = GarageEnums.eEngineType.Fuel;
            }
            else if (valueToSwitch
                .Equals(EnumString.Upper.sr_Battery))
            {
                nullableOfReturnValue = GarageEnums.eEngineType.Battery;
            }

            return nullableOfReturnValue.Value;
        }

        private static Car.eColor createColor(string i_IndentationString)
        {
            string validEnumStrings = createValidStringsMessage(
                EnumString.sr_Red, EnumString.sr_Silver,
                EnumString.sr_White, EnumString.sr_Black);
            string color = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(color)}: {validEnumStrings}",
                EnumString.Upper.sr_Red, EnumString.Upper.sr_Silver,
                EnumString.Upper.sr_White, EnumString.Upper.sr_Black);

            string valueToSwitch = color.ToUpper();
            Car.eColor? nullableOfReturnValue = null;
            if (valueToSwitch.Equals(EnumString.Upper.sr_Red))
            {
                nullableOfReturnValue = Car.eColor.Red;
            }
            else if (valueToSwitch
                .Equals(EnumString.Upper.sr_Silver))
            {
                nullableOfReturnValue = Car.eColor.Silver;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_White))
            {
                nullableOfReturnValue = Car.eColor.White;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Black))
            {
                nullableOfReturnValue = Car.eColor.Black;
            }

            return nullableOfReturnValue.Value;
        }

        static Car.eDoorsAmount createDoorsAmount(string i_IndentationString)
        {
            string validEnumStrings = createValidStringsMessage(
                EnumString.sr_Two, EnumString.sr_Three,
                EnumString.sr_Four, EnumString.sr_Five);
            string doorsAmount = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(doorsAmount)}: {validEnumStrings}",
                EnumString.Upper.sr_Two, EnumString.Upper.sr_Three,
                EnumString.Upper.sr_Four, EnumString.Upper.sr_Five);

            string valueToSwitch = doorsAmount.ToUpper();
            Car.eDoorsAmount? nullableOfReturnValue = null;
            if (valueToSwitch.Equals(EnumString.Upper.sr_Two))
            {
                nullableOfReturnValue = Car.eDoorsAmount.Two;
            }
            else if (valueToSwitch
                .Equals(EnumString.Upper.sr_Three))
            {
                nullableOfReturnValue = Car.eDoorsAmount.Three;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Four))
            {
                nullableOfReturnValue = Car.eDoorsAmount.Four;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Five))
            {
                nullableOfReturnValue = Car.eDoorsAmount.Five;
            }

            return nullableOfReturnValue.Value;
        }

        private Record createMotorcycle(Owner i_Owner,
            ref int io_IndentationLevel,
            string i_ModelName, string i_LicensePlate)
        {
            io_IndentationLevel++;

            io_IndentationLevel--;

            throw new NotImplementedException();
        }

        private Record createTruck(Owner i_Owner,
            ref int io_IndentationLevel,
            string i_ModelName, string i_LicensePlate)
        {
            io_IndentationLevel++;

            io_IndentationLevel--;

            throw new NotImplementedException();
        }

        private string createTireManufacturerName(ref int io_IndentationLevel)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine($"{indentationString}Create {nameof(Tire)}:");
            string manufacturerName =
                InputUtil.Convert<string>(
                    $"{indentationString}Enter {nameof(manufacturerName)}: ");

            io_IndentationLevel--;

            return manufacturerName;
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
                // eVehicleType:
                public static readonly string sr_Car = EnumString.sr_Car;

                public static readonly string sr_Motorcycle =
                    EnumString.sr_Motorcycle;

                public static readonly string sr_Truck = EnumString.sr_Truck;

                // eColor:
                public static readonly string sr_Black = EnumString.sr_Black;

                public static readonly string sr_Red = EnumString.sr_Red;

                public static readonly string sr_Silver = EnumString.sr_Silver;

                public static readonly string sr_White = EnumString.sr_White;

                // eDoorsAmount:
                public static readonly string sr_Two = EnumString.sr_Two;

                public static readonly string sr_Three = EnumString.sr_Three;

                public static readonly string sr_Four = EnumString.sr_Four;

                public static readonly string sr_Five = EnumString.sr_Five;

                // eEngineType:
                public static readonly string sr_Fuel = EnumString.sr_Fuel;

                public static readonly string
                    sr_Battery = EnumString.sr_Battery;

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

                    // eDoorsAmount:
                    sr_Two = sr_Two.ToUpper();
                    sr_Three = sr_Three.ToUpper();
                    sr_Four = sr_Four.ToUpper();
                    sr_Five = sr_Five.ToUpper();

                    // eEngineType:
                    sr_Fuel = sr_Fuel.ToUpper();
                    sr_Battery = sr_Battery.ToUpper();
                }
            }

            // eVehicleType:
            public static readonly string sr_Car =
                $"{GarageEnums.eVehicleType.Car:G}";

            public static readonly string sr_Motorcycle =
                $"{GarageEnums.eVehicleType.Motorcycle:G}";

            public static readonly string sr_Truck =
                $"{GarageEnums.eVehicleType.Truck:G}";

            // eColor:
            public static readonly string
                sr_Black = $"{Car.eColor.Black:G}";

            public static readonly string sr_Red = $"{Car.eColor.Red:G}";

            public static readonly string sr_Silver =
                $"{Car.eColor.Silver:G}";

            public static readonly string
                sr_White = $"{Car.eColor.White:G}";

            // eDoorsAmount:
            public static readonly string
                sr_Two = $"{Car.eDoorsAmount.Two:G}";

            public static readonly string sr_Three =
                $"{Car.eDoorsAmount.Three:G}";

            public static readonly string sr_Four =
                $"{Car.eDoorsAmount.Four:G}";

            public static readonly string
                sr_Five = $"{Car.eDoorsAmount.Five:G}";

            // eEngineType:
            public static readonly string
                sr_Fuel = $"{GarageEnums.eEngineType.Fuel:G}";

            public static readonly string sr_Battery =
                $"{GarageEnums.eEngineType.Battery:G}";

            static EnumString() {}
        }
    }
}
