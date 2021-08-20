using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine
{
    public class ExtendedEngine : EngineContainer
    {
        public ExtendedEngine(Engine i_Engine, int i_VolumeInCC)
        {
            Engine = i_Engine;
            VolumeInCC = i_VolumeInCC;
        }

        public Engine Engine { get; }

        /// <summary>
        ///     Measured in `CC` units.
        /// </summary>
        public int VolumeInCC { get; }

        public override void AddSelfValue(float i_ValueToAdd)
        {
            Engine.AddSelfValue(i_ValueToAdd);
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }

        public float ManufacturerMaxValue
        {
            get => Engine.ManufacturerMaxValue;

            set => Engine.ManufacturerMaxValue = value;
        }

        public float Value
        {
            get => Engine.Value;

            set => Engine.Value = value;
        }
    }
}
