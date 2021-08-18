using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Standard;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Impl.Car
{
    public class Car : Vehicle
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

        public Car(VehicleConstructorDTO i_VehicleConstructorDTO,
            eColor i_Color, eDoorsAmount i_DoorsAmount,
            StandardEngine i_StandardEngine)
            : base(i_VehicleConstructorDTO)
        {
            StandardEngine = i_StandardEngine;

            Color = i_Color;
            DoorsAmount = i_DoorsAmount;
        }

        public Car(CarConstructorDTO i_CarConstructorDTO)
        {
            StandardEngine = i_CarConstructorDTO.StandardEngine;
            ModelName = i_CarConstructorDTO.ModelName;
            LicensePlate = i_CarConstructorDTO.LicensePlate;

            Color = i_CarConstructorDTO.Color;
            DoorsAmount = i_CarConstructorDTO.DoorsAmount;
        }

        public eColor Color { get; }

        public eDoorsAmount DoorsAmount { get; }

        public StandardEngine StandardEngine { get; }

        public override string ToString()
        {
            // TODO: remove
            // return
            //     $"{base.ToString()}, {nameof(Color)}: {Color}, {nameof(DoorsAmount)}: {DoorsAmount}";

            return this.ToStringExtension();
        }
    }
}
