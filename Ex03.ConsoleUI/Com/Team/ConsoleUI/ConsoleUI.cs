using System;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard.Fuel;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle;
using Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Motorcycle;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.ConsoleUI.Com.Team.ConsoleUI
{
    public class ConsoleUI
    {
        public IGarageController GarageController { get; } =
            new GarageControllerImpl();

        public void RunConsoleUI()
        {
            printLicensePlates();

            printSelectedLicensePlates(Record.eState.InProgress);

            // printMenu();
        }

        private void printLicensePlates()
        {
            foreach (var licensePlate in GarageController.GetLicensePlatesList()
            )
            {
                Console.Out.WriteLine(licensePlate);
                
                //DEBUG: test
                Record record = new Record(new Motorcycle(new MotorcycleConstructorDTO
                    ("modelName1", "licensePlate1",
                        30, Motorcycle.eLicenseType.A,
                        new ExtendedEngine(new FuelEngine(eType.Octan98, 6),
                            2000))),
                    new Owner("054noregex...", "tal"));
                Console.Out.WriteLine("record = {0}", record.ToStringExtension());
            }
        }

        private void printSelectedLicensePlates(Record.eState i_State)
        {
            foreach (var licensePlate in GarageController.GetLicensePlatesList(i_State)
            )
            {
                Console.Out.WriteLine(licensePlate);
            }
        }

        private void printMenu()
        {
            throw new NotImplementedException();
        }
    }
}
