using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    class MemberRegister
    {
        private string _filePath;

        // StreamWriter file = new StreamWriter(_filePath); // members.txt
        private DateTime dateTimeNow = DateTime.Now;
        // private DirectoryInfo _dir = new DirectoryInfo(@"c:\RegisterData\");
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

        public string FilePath
        {
            get {return _filePath;}
            set
            {
                _filePath = value;
            }
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
            // m.ToString;
            // Member.FirstName = firstName;
            // if (_filePath == $"{_dir}members.txt")
            // {
                // List<string> lines = new List<>;
            StreamWriter sw = new StreamWriter(@"../register.txt");
            StreamWriter sw1 = new StreamWriter(@"member.txt");
            // lines.Add($"{m.FirstName}, nilsson, 551212-0101, {this.dateTimeNow}");
                // File.WriteAllLines(_filePath, lines);
                // string info = $"{new Member(firstName, "Nilsson", "551212-0101")}, {this.dateTimeNow}";
            sw.WriteLine(m.FirstName);
            sw1.WriteLine(m.FirstName);
                // string json = File.ReadAllText(args[0]);
                // int[] data = JsonConvert.DeserializeObject<int[]>(json);

            // }
            // string filePath = @"C:\SaveData\members.txt";
        }

        public Member AddNewMember()
        {
            _member = new Member("Lone", "Nilsson", "551212-0101");
            System.Console.WriteLine("nu körs denna");
            return _member;
        }


        public void PrintOutAll()
        {
            List<string> lines = File.ReadAllLines(_filePath).ToList();

            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public override string ToString()
        {
            return "You have been registred a new member";
        }
    }
}
