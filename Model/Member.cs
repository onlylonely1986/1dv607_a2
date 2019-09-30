using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    class Member : Person
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
            Boat.BoatType type = b.PickBoatType(t);
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
            Boat.BoatType type = b.PickBoatType(t);
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

        public override string ToString()
        {
             if (_boats != null)
            {
                string boats = String.Concat(Boats.Select(b=>b.ToString()));
                return $"Id: {MemberId}, Name: {FirstName} {LastName}, Personal number: {PersNum}, Boats {Boats.Count}: {boats}";
            } else
            {
                string boats = "No boats added yet";
                return $"Id: {MemberId}, Name: {FirstName} {LastName}, Personal number: {PersNum}, Boats: {boats}";
            }
        }

        public string ToStringSmall()
        {
            int b = 0;
            if (_boats != null)
            {
                b = _boats.Count;
            }
            return $"Id: {MemberId}, Name: {FirstName} {LastName}, Boats: {b}";
        }
    }
}
