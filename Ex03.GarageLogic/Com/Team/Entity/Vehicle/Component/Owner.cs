using Ex03.GarageLogic.Com.Team.Misc;

namespace Ex03.GarageLogic.Com.Team.Entity.Vehicle.Component
{
    public struct Owner    
    {
        public Owner(string i_PhoneNumber, string i_Name)
        {
            PhoneNumber = i_PhoneNumber;
            Name = i_Name;
        }

        public string Name { get; }

        public string PhoneNumber { get; }

        public override string ToString()
        {
            return this.ToStringExtension();
        }
    }
}
