using System.Security.Cryptography.X509Certificates;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine
{
    public abstract class EngineContainer : ISelfValueAdder
    {
        public abstract float GetValuePercentage();
        
        public abstract void AddSelfValue(float i_ValueToAdd);
    }
}
