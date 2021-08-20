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

        public override float GetManufacturerMaxValue()
        {
            return Engine.GetManufacturerMaxValue();
        }

        public override float GetValue()
        {
            return Engine.GetValue();
        }

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public override float GetValuePercentage()
        {
            return Engine.GetValuePercentage();
        }
    }
}
