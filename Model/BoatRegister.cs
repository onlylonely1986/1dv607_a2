
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
    }
}
