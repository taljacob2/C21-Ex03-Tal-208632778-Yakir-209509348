using System;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.ConsoleUI.Com.Team.ConsoleUI
{
    public class ConsoleUI
    {
        public IGarageController GarageController { get;} =
            new GarageControllerImpl();

        public void RunUI()
        {
            Console.Out.WriteLine(GarageController.GetLicensePlatesList());

            // printMenu();
        }

        private void printMenu()
        {
            throw new NotImplementedException();
        }
    }
}
