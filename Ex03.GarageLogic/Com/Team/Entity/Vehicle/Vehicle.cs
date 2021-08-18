using System.Collections.Generic;
using Ex03.GarageLogic.Com.Team.DTO.Constructor;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine;
using Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire;
using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle
{
    public abstract class Vehicle
    {
        protected Vehicle(VehicleConstructorDTO i_VehicleConstructorDTO)
        {
            ModelName = i_VehicleConstructorDTO.ModelName;
            LicensePlate = i_VehicleConstructorDTO.LicensePlate;
            TiresMaxAirPressure = i_VehicleConstructorDTO.TiresMaxAirPressure;
        }

        protected Vehicle() {}

        public string ModelName { get; protected set; }

        /// <summary>
        ///     Unique ID.
        /// </summary>
        public string LicensePlate { get; protected set; }

        public List<Tire> Tires { get; protected set; }

        public float TiresMaxAirPressure { get; protected set; }

        public Engine Engine { get; }

        public float GetRemainedEnergyPercentage()
        {
            return Engine.GetValuePercentage();
        }

        public override string ToString()
        {
            // TODO: remove
            // StringBuilder stringBuilder = new StringBuilder();
            // stringBuilder.Append(
            //     $"{nameof(ModelName)}: {ModelName}," +
            //     $" {nameof(LicensePlate)}: {LicensePlate}," +
            //     $" {nameof(TiresMaxAirPressure)}: {TiresMaxAirPressure}");
            // stringBuilder.Append($"{nameof(Tires)}:");
            // foreach (Tire tire in Tires)
            // {
            //     stringBuilder.Append(tire);
            // }
            //
            // return stringBuilder.ToString();

            return this.ToStringExtension();
        }
    }
}
