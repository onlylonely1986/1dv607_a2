using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    class Member
    {
        private string _firstName;

        private string _lastName;

        private string _personalNum;

        // private int memberId;

        // private List<Boat> boats;

        // private int memberSince;

        public string FirstName
        {
            get { return _firstName;}
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName;}
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _lastName = value;
            }
        }

         public string PersonalNum
        {
            get { return _personalNum;}
            set
            {
                if (value.Length != 11)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _personalNum = value;
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

       public Member(string firstName, string lastName, string personalNum)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNum =  personalNum;
        }

        public override string ToString()
        {
            return _firstName + ", " + _lastName + ", " + _personalNum;
        }
    }
}
