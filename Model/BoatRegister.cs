
namespace model
{
    class BoatRegister
    {
        public void RegistryBoat(Member m, Boat.BoatType t, int l)
        {
            Boat b = new Boat(t, l);
            
            int id = 0;
            if (m.Boats.Count != 0)
            {
                id = m.Boats.Count;
            }

            id++; 
            b.BoatId = id;
            System.Console.WriteLine(b.ToString());
            m.Boats.Add(b);
            System.Console.WriteLine("The boat was successfully registred.");
        }
    }
}
