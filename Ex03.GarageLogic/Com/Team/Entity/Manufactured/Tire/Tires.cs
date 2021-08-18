using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic.Com.Team.Misc;

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
            foreach (var tire in List)
            {
                stringBuilder.Append(tire);
                i++;
                if (i < List.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }
    }
}
