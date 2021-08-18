using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine.Extended
{
    public class ExtendedEngine
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

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
