﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using Ex03.ConsoleUI.Com.Team.Misc;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.DTO.Model.Request;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Battery;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl;

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
            string name = createOwnerName(indentationString);
            string phoneNumber = createPhoneNumber(indentationString);

            io_IndentationLevel--;

            return new Owner(phoneNumber, name);
        }

        private static string createPhoneNumber(string i_IndentationString)
        {
            string phoneNumber = null;
            while (phoneNumber == null)
            {
                try
                {
                    phoneNumber =
                        InputUtil.ConvertWithAssertByRegexWithException(
                            $"{i_IndentationString}Enter {nameof(phoneNumber)}: ",
                            new Regex("[0-9]{10}"));
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Insert exactly 10 numbers.");
                }
            }

            return phoneNumber;
        }

        private static string createOwnerName(string i_IndentationString)
        {
            string name = null;

            while (name == null)
            {
                try
                {
                    name =
                        InputUtil.ConvertWithAssertByRegexWithException(
                            $"{i_IndentationString}Enter {nameof(name)}: ",
                            new Regex("[a-zA-Z]"));
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Insert letters only.");
                }
            }

            return name;
        }

        private Record createVehicle(Owner i_Owner,
            ref int io_IndentationLevel)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{StringIndentation.Create(io_IndentationLevel)}Create {nameof(VehicleComponent)}:");
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

            Record? nullableReturnValue = null;
            string valueToSwitch = i_VehicleType.ToUpper();
            if (valueToSwitch.Equals(EnumString.Upper.sr_Car))
            {
                nullableReturnValue = createCar(i_Owner,
                    ref io_IndentationLevel,
                    i_ModelName, i_LicensePlate);
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Motorcycle))
            {
                nullableReturnValue =
                    createMotorcycle(i_Owner, ref io_IndentationLevel,
                        i_ModelName, i_LicensePlate);
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_Truck))
            {
                nullableReturnValue = createTruck(i_Owner,
                    ref io_IndentationLevel,
                    i_ModelName, i_LicensePlate);
            }

            io_IndentationLevel--;

            return nullableReturnValue.Value;
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

        private Record createMotorcycleTypeSwitch(Owner i_Owner,
            string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName,
            Motorcycle.eLicenseType i_LicenseType,
            int i_ExtendedEngineVolumeInCC,
            GarageEnums.eEngineType i_EngineType)
        {
            CreateAndInsertAssertedMotorcycleRequest request = new
                CreateAndInsertAssertedMotorcycleRequest(
                    i_Owner,
                    i_ModelName, i_LicensePlate, i_TireManufacturerName,
                    i_LicenseType, i_ExtendedEngineVolumeInCC, i_EngineType);
            Record? nullableReturnValue = null;
            GarageEnums.eEngineType valueToSwitch = i_EngineType;
            string responseMessage = "";
            if (valueToSwitch == GarageEnums.eEngineType.Fuel)
            {
                nullableReturnValue =
                    GarageController.PostCreateAndInsertAssertedFuelMotorcycle(
                        request,
                        out responseMessage);
            }
            else if (valueToSwitch == GarageEnums.eEngineType.Battery)
            {
                nullableReturnValue =
                    GarageController
                        .PostCreateAndInsertAssertedBatteryMotorcycle(
                            request, out responseMessage);
            }

            Console.Out.WriteLine(responseMessage);

            return nullableReturnValue.Value;
        }

        private Record createCarTypeSwitch(Owner i_Owner, string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName, Car.eColor i_Color,
            Car.eDoorsAmount i_DoorsAmount,
            GarageEnums.eEngineType i_EngineType)
        {
            CreateAndInsertAssertedCarRequest request =
                new CreateAndInsertAssertedCarRequest(
                    i_Owner,
                    i_ModelName, i_LicensePlate, i_TireManufacturerName,
                    i_Color, i_DoorsAmount, i_EngineType);
            Record? nullableReturnValue = null;
            GarageEnums.eEngineType valueToSwitch = i_EngineType;
            string responseMessage = "";
            if (valueToSwitch == GarageEnums.eEngineType.Fuel)
            {
                nullableReturnValue =
                    GarageController.PostCreateAndInsertAssertedFuelCar(request,
                        out
                        responseMessage);
            }
            else if (valueToSwitch == GarageEnums.eEngineType.Battery)
            {
                nullableReturnValue =
                    GarageController.PostCreateAndInsertAssertedBatteryCar(
                        request, out
                        responseMessage);
            }

            Console.Out.WriteLine(responseMessage);

            return nullableReturnValue.Value;
        }

        private Record createTruckTypeSwitch(Owner i_Owner, string i_ModelName,
            string i_LicensePlate,
            string i_TireManufacturerName,
            bool i_IsContainingDangerousMaterials,
            float i_MaxCarryingCapabilityInKilos,
            GarageEnums.eEngineType i_EngineType)
        {
            CreateAndInsertAssertedTruckRequest request =
                new CreateAndInsertAssertedTruckRequest(
                    i_Owner,
                    i_ModelName, i_LicensePlate, i_TireManufacturerName,
                    i_IsContainingDangerousMaterials, i_MaxCarryingCapabilityInKilos, i_EngineType);
            Record? nullableReturnValue = null;
            GarageEnums.eEngineType valueToSwitch = i_EngineType;
            string responseMessage = "";
            if (valueToSwitch == GarageEnums.eEngineType.Fuel)
            {
                nullableReturnValue =
                    GarageController.PostCreateAndInsertAssertedFuelTruck(request,
                        out
                        responseMessage);
            }
            else if (valueToSwitch == GarageEnums.eEngineType.Battery)
            {
                responseMessage =
                    "There is no AssertedBatteryTruck in the system. Request failed.";

                // Ready for future implementation:
                // nullableReturnValue =
                //     GarageController.PostCreateAndInsertAssertedBatteryTruck(request, out responseMessage);
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

        private static Car.eDoorsAmount createDoorsAmount(
            string i_IndentationString)
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

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{indentationString}Create {nameof(Motorcycle)}:");
            string tireManufacturerName =
                createTireManufacturerName(ref io_IndentationLevel);
            Motorcycle.eLicenseType licenseType =
                createLicenseType(indentationString);
            int extendedEngineVolumeInCC =
                createExtendedEngineVolumeInCC(ref io_IndentationLevel);
            GarageEnums.eEngineType engineType =
                createEngineType(indentationString);

            io_IndentationLevel--;

            return createMotorcycleTypeSwitch(i_Owner, i_ModelName,
                i_LicensePlate,
                tireManufacturerName, licenseType, extendedEngineVolumeInCC,
                engineType);
        }

        private Motorcycle.eLicenseType createLicenseType(
            string i_IndentationString)
        {
            string validEnumStrings = createValidStringsMessage(
                EnumString.sr_A, EnumString.sr_B1,
                EnumString.sr_AA, EnumString.sr_BB);
            string licenseType = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(licenseType)}: {validEnumStrings}",
                EnumString.Upper.sr_A, EnumString.Upper.sr_B1,
                EnumString.Upper.sr_AA, EnumString.Upper.sr_BB);

            string valueToSwitch = licenseType.ToUpper();
            Motorcycle.eLicenseType? nullableOfReturnValue = null;
            if (valueToSwitch.Equals(EnumString.Upper.sr_A))
            {
                nullableOfReturnValue = Motorcycle.eLicenseType.A;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_B1))
            {
                nullableOfReturnValue = Motorcycle.eLicenseType.B1;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_AA))
            {
                nullableOfReturnValue = Motorcycle.eLicenseType.AA;
            }
            else if (valueToSwitch.Equals(EnumString.Upper.sr_BB))
            {
                nullableOfReturnValue = Motorcycle.eLicenseType.BB;
            }

            return nullableOfReturnValue.Value;
        }

        private Record createTruck(Owner i_Owner,
            ref int io_IndentationLevel,
            string i_ModelName, string i_LicensePlate)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{indentationString}Create {nameof(Truck)}:");
            string tireManufacturerName =
                createTireManufacturerName(ref io_IndentationLevel);
            bool isContainingDangerousMaterials =
                createIsContainingDangerousMaterials(indentationString);
            float maxCarryingCapabilityInKilos =
                createMaxCarryingCapabilityInKilos(indentationString);

            GarageEnums.eEngineType engineType =
                createEngineType(indentationString);

            io_IndentationLevel--;

            return createTruckTypeSwitch(i_Owner, i_ModelName, i_LicensePlate,
                tireManufacturerName, isContainingDangerousMaterials,
                maxCarryingCapabilityInKilos, engineType);
        }

        private static float createMaxCarryingCapabilityInKilos(
            string i_IndentationString)
        {
            float maxCarryingCapabilityInKilos = -1;
            while (maxCarryingCapabilityInKilos == -1)
            {
                try
                {
                    maxCarryingCapabilityInKilos =
                        InputUtil.ConvertWithAssertByRangeWithException<float>(
                            $"{i_IndentationString}Enter {nameof(maxCarryingCapabilityInKilos)}: ",
                            0, float.MaxValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return maxCarryingCapabilityInKilos;
        }

        private bool createIsContainingDangerousMaterials(
            string i_IndentationString)
        {
            const string k_True = "true";
            const string k_False = "false";
            string validEnumStrings = createValidStringsMessage(k_True,
                k_False);
            string isContainingDangerousMaterials = InputUtil.ConvertIgnoreCase(
                $"{i_IndentationString}Enter {nameof(isContainingDangerousMaterials)}: {validEnumStrings}",
                k_True, k_False);

            string valueToSwitch = isContainingDangerousMaterials.ToLower();
            bool? nullableOfReturnValue = null;
            if (valueToSwitch.Equals(k_True))
            {
                nullableOfReturnValue = true;
            }
            else if (valueToSwitch.Equals(k_False))
            {
                nullableOfReturnValue = false;
            }

            return nullableOfReturnValue.Value;
        }

        private int createExtendedEngineVolumeInCC(ref int io_IndentationLevel)
        {
            io_IndentationLevel++;

            string indentationString =
                StringIndentation.Create(io_IndentationLevel);
            Console.Out.WriteLine(
                $"{indentationString}Create {nameof(ExtendedEngine)}:");
            int extendedEngineVolumeInCC = 0;
            while (extendedEngineVolumeInCC == 0)
            {
                try
                {
                    extendedEngineVolumeInCC =
                        InputUtil.ConvertWithAssertByRangeWithException<int>(
                            $"{indentationString}Enter {nameof(extendedEngineVolumeInCC)}: ",
                            1, int.MaxValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            // Comment: instead, you may do so, and avoid exceptions:
            // InputUtil.ConvertWithAssertByRange<int>(
            //     $"{indentationString}Enter {nameof(extendedEngineVolumeInCC)}: ",
            //     1, int.MaxValue);

            io_IndentationLevel--;

            return extendedEngineVolumeInCC;
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

            // eLicenseType:
            public static readonly string
                sr_A = $"{Motorcycle.eLicenseType.A:G}";

            public static readonly string
                sr_B1 = $"{Motorcycle.eLicenseType.B1:G}";

            public static readonly string
                sr_AA = $"{Motorcycle.eLicenseType.AA:G}";

            public static readonly string
                sr_BB = $"{Motorcycle.eLicenseType.BB:G}";

            static EnumString() {}

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

                // eLicenseType:
                public static readonly string sr_A = EnumString.sr_A;

                public static readonly string sr_B1 = EnumString.sr_B1;

                public static readonly string sr_AA = EnumString.sr_AA;

                public static readonly string sr_BB = EnumString.sr_BB;

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

                    // eLicenseType:
                    sr_A = sr_A.ToUpper();
                    sr_B1 = sr_B1.ToUpper();
                    sr_AA = sr_AA.ToUpper();
                    sr_BB = sr_BB.ToUpper();
                }
            }
        }
    }
}
