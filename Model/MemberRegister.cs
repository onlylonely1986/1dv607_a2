using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Register
{
    class MemberRegister
    {
        private Member member;

        private DateTime dateTimeNow = DateTime.Now;

        public void RegistryMember(string firstName, string lastName, string personalNum)
        {
            this.member = new Member(firstName, lastName, personalNum);
            string filePath = @"C:\SaveData\members.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            lines.Add($"{this.member.firstName}, {this.member.lastName}, {this.member.personalNum}, {this.dateTimeNow}");
            File.WriteAllLines(filePath, lines);
        }

        public override string ToString()
        {
            return "You have been registred a new member";
        }
    }
}
