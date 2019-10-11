using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member : Person
    {
        private int _memberId;

        private List<Boat> _boats = new List<Boat>();

        public int MemberId
        {
            get { return _memberId;}
            set
            {
                _memberId = value;
            }
        }

        public List<Boat> Boats
        {
            get { return _boats;}
        }

        public void AddBoat(string t, int l)
        {
            Boat b = new Boat(l);
            BoatType type = b.PickBoatType(t);
            b.Type = type;
            if (_boats.Count < 100)
            {
                _boats.Add(b);
            } else
            {
                throw new ArgumentOutOfRangeException("You have to many boots in your harbor.");
            }
        }

        public void ChangeBoat(Boat b, string t, int l)
        {
            BoatType type = b.PickBoatType(t);
            b.Type = type;
            b.LengthInFeet = l;
            
        }

        public void RemoveBoat(Boat b)
        {
            _boats.Remove(b);   
        }

        public string GetBoatInfo()
        {
            int ind = 1;
            string boats = String.Concat(_boats.Select(b=> $"[{ind++}]: {b.ToString()}\n"));
            return boats;
        }

        public Member(string firstName, string lastName, string personalNum) : base (firstName, lastName, personalNum)
        {
        }
    }
}
