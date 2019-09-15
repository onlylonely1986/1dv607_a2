using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Register
{
    class Member
    {
        private string firstName {get; set;}

        private string lastName {get; set;}

        private string personalNum {get; set;}

        // private int memberId;

        // private List<Boat> boats;

        // private int memberSince;

        // public string getName()
        // {

        // }

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
            this.firstName = firstName;
            this.lastName = lastName;
            this.personalNum =  personalNum;
        }

        public override string ToString()
        {
            return this.firstName + ", " + this.lastName + ", " + this.personalNum;
        }
    }
}
