using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Com.Team.Entity.Manufactured.Tire
{
    public class Tires
    {
        public List<Tire> List { get; } = new List<Tire>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("[");
            int i = 0;
            foreach (Tire tire in List)
            {
                stringBuilder.Append(tire);
                i++;
                if (i < List.Count)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }
    }
}
