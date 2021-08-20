using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component.Impl
{
    public class Car : ComponentVehicle
    {
        public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }

        public enum eDoorsAmount
        {
            Two,
            Three,
            Four,
            Five
        }

        public const int k_TiresAmount = 4;

        public Car(CarConstructorDTO i_CarConstructorDTO)
        {
            EngineContainer = i_CarConstructorDTO.Engine;
            ModelName = i_CarConstructorDTO.ModelName;
            LicensePlate = i_CarConstructorDTO.LicensePlate;
            Color = i_CarConstructorDTO.Color;
            DoorsAmount = i_CarConstructorDTO.DoorsAmount;
            SetTires(i_CarConstructorDTO.TireToSetForAllTires, k_TiresAmount);
        }

        public Car(Engine i_EngineContainer)
        {
            EngineContainer = i_EngineContainer;
        }

        public eColor Color { get; set; }

        public eDoorsAmount DoorsAmount { get; set; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
