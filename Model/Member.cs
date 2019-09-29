using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    class Member : Person
    {
        private int _memberId;

        private List<Boat> _boats = new List<Boat>();

        private DateTime _memberSince = DateTime.Now;

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
            set
            {
                _boats = value;
            }
        }

        public DateTime MemberSince
        {
            get { return _memberSince;}
            set
            {
                _memberSince = value;
            }
        }
        // public int getPersonalNum()
        // {

        // }

        // public int getMemberId()
        // {

        // }

        // public List<Boat> getBoats()
        // {

        // }

        // public int getMemberSince()
        // {

        // }

        public Member(string firstName, string lastName, string personalNum) : base (firstName, lastName, personalNum)
        {
            Boats = _boats;
        }

        public override string ToString()
        {
             if (Boats != null)
            {
                foreach(Boat b in Boats)
                {
                    b.ToString();
                }
                return $"Id: {MemberId}, Name: {FirstName} {LastName}, Personal number: {PersNum}, Boats: {foreach(Boat b in Boats) => b.ToString()}, Member since: {MemberSince}";
            } else
            {
                string boats = "No boats added yet";
                return $"Id: {MemberId}, Name: {FirstName} {LastName}, Personal number: {PersNum}, Boats: {boats}, Member since: {MemberSince}";
            }
            
        }

        public string ToStringSmall()
        {
            int b = 0;
            if (Boats != null)
            {
                b = Boats.Count;
            }
            return $"Id: {MemberId}, Name: {FirstName} {LastName}, Boats: {b}";
        }
    }
}
