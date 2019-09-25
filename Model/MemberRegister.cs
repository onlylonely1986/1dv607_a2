using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Model
{
    class MemberRegister
    {
        private Member _member;

        private DateTime dateTimeNow = DateTime.Now;

        public void RegistryMember(Member member)
        {
            string filePath = @"C:\SaveData\members.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            lines.Add($"{member.FirstName}, {member.LastName}, {member.PersonalNum}, {this.dateTimeNow}");
            File.WriteAllLines(filePath, lines);
        }

        public override string ToString()
        {
            return "You have been registred a new member";
        }
    }
}
