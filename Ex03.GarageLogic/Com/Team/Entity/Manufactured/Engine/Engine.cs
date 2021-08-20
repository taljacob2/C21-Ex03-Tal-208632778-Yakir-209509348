using Ex03.GarageLogic.Com.Team.Exception;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Engine
{
    public abstract class Engine : EngineContainer
    {
        public ManufactureComponent ManufactureComponent { get; private set; 
        } = new ManufactureComponent();
        
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
        
        /// <summary>
        ///     Measured in `Percentage` units.
        /// </summary>
        public override float GetValuePercentage()
        {
            return ManufactureComponent.GetValuePercentage();
        }
        
        public override void AddSelfValue(float i_ValueToAdd)
        {
            ValueOutOfRangeException exception =
                new ValueOutOfRangeException(ManufacturerMaxValue, 0);

            // Assert minimum:
            if (i_ValueToAdd < 0)
            {
                throw exception;
            }

            // Assert maximum:
            if (ManufacturerMaxValue < Value + i_ValueToAdd)
            {
                throw exception;
            }

            Value += i_ValueToAdd;
        }

    }
}
