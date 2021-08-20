namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine
{
    public abstract class Engine : EngineContainer
    {
        public ManufactureComponent ManufactureComponent { get; private set; }
        
        public float ManufacturerMaxValue
        {
            get => ManufactureComponent.ManufacturerMaxValue;

            set => ManufactureComponent.ManufacturerMaxValue = value;
        }
        
        public float Value
        {
            get => ManufactureComponent.Value;

            set => ManufactureComponent.Value = value;
        }
        
    }
}
