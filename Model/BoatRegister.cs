
namespace model
{
    class BoatRegister
    {
        public void RegistryBoat(Member m, Boat.BoatType type, int l) => m.Boats.Add(new Boat(type, l));
    }
}
