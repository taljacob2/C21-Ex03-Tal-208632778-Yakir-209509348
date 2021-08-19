using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended
{
    public class ExtendedEngine : ISelfValueAdder
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

        public void AddSelfValue(float i_ValueToAdd)
        {
            Engine.AddSelfValue(i_ValueToAdd);
        }

        public override string ToString()
        {
            return this.ToStringExtension();
        }

        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public float GetValuePercentage()
        {
            return Engine.GetValuePercentage();
        }
    }
}
