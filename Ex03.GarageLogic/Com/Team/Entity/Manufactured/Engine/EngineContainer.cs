namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine
{
    public abstract class EngineContainer : ISelfValueAdder
    {
        public abstract void AddSelfValue(float i_ValueToAdd);
        public abstract float GetValuePercentage();
    }
}
