
namespace model
{
    class BoatRegister
    {
        public void RegistryBoat(Member m, Boat.BoatType type, int l)
        {
            Boat b = new Boat(type, l);
            System.Console.WriteLine(b.ToString());
            // b.ToString();
            m.Boats.Add(b);
            System.Console.WriteLine("The boat was successfully registred.");
        }
    }
}
