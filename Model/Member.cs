using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    class Member : Person
    {

        private int _memberId;

        private List<Boat> _boats;

        private int _memberSince;

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
 
        }
    }
}
