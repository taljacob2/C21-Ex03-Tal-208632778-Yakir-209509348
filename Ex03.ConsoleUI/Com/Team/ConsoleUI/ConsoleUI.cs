using System;
using Ex03.GarageLogic.Com.Team.Controller.Garage;
using Ex03.GarageLogic.Com.Team.Controller.Garage.Impl;

namespace Ex03.ConsoleUI.Com.Team.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly IGarageController r_GarageController =
            new GarageControllerImpl();

        public void RunUI()
        {
            printMenu();
        }

        private void printMenu()
        {
            throw new NotImplementedException();
        }
    }
}
