
namespace model
{
    class BoatRegister
    {
        public void RegistryBoat(Member m, Boat.BoatType t, int l)
        {
            Boat b = new Boat(t, l);
            System.Console.WriteLine(b.ToString());
            m.Boats.Add(b);
            System.Console.WriteLine("The boat was successfully registred.");
        }

        public void ChangeBoat(Boat b, Boat.BoatType t, int l)
        {
            b.Type = t;
            b.LengthInFeet = l;
        }

        public Boat.BoatType PickBoatType(string type)
        {
            Boat.BoatType t = Boat.BoatType.Other;
            if (type == "1")
            {
                t = Boat.BoatType.Sailboat;
            } else if (type == "2")
            {
                t = Boat.BoatType.Motorsailer;
            } else if (type == "3")
            {
                t = Boat.BoatType.KayakorCanoe;
            } else if (type == "4")
            {
                t = Boat.BoatType.Other;
            }
            return t;
        }
    }
}
