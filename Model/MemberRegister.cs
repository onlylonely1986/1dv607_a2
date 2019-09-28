using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace model
{
    class MemberRegister
    {
        private List<Member> _members;
        
        private Member _member;

        // TODO implement this
        private int _uniqueID;

        // TODO justera detta senare!
        // ej korrekt inkapslad
        public Member Member
        {
            get {return _member;}
            set {
                _member = value;
            }

        }

        public List<Member> Members
        {
            get; set;
        }

        public void RegistryMember(List<string> inputs)
        {
            string firstName = inputs[0];
            string lastName = inputs[1];
            string persNum = inputs[2];

            foreach (string input in inputs)
            {
                // System.Console.WriteLine($"du har skrivit in:  {input} ");
            }

            Member  m = new Member(firstName, lastName, persNum);
            System.Console.WriteLine(" -------   ");

            StreamWriter sw = new StreamWriter(@"register.txt");
            
            // lines.Add($"{m.FirstName}, nilsson, 551212-0101, {this.dateTimeNow}");
            // File.WriteAllLines(_filePath, lines);
            // string info = $"{new Member(firstName, "Nilsson", "551212-0101")}, {this.dateTimeNow}";

            // TODO 
            // enbart första argumentet skrivs in, kolla om man ska parsa ett objekt?  med json för att 
            // skicka in en hel medlem
            // Medlem: ID, förnamn, efternamn, personNr, datum, båtar[]
            string result = JsonConvert.SerializeObject(m);
            sw.WriteLine(result);
            System.Console.WriteLine(result);
            sw.Close();

                // string json = File.ReadAllText(args[0]);
                // int[] data = JsonConvert.DeserializeObject<int[]>(json);

        }

        public Member AddNewMember()
        {
            _member = new Member("Lone", "Nilsson", "551212-0101");
            System.Console.WriteLine("nu körs denna");
            return _member;
        }


        public void ReadAllMembersFromFile()
        {

        }

        public override string ToString()
        {
            return "You have been registred a new member";
        }
    }
}
