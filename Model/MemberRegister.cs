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

        public void RegistryMember(string firstName)
        {
            // memberRegister.RegistryMember(new Member());
            // Member = new Member(firstName, "Nilsson", "551212-0101");
            // Member.FirstName = firstName;
            // if (_filePath == $"{_dir}members.txt")
            // {
                // List<string> lines = new List<>;
                StreamWriter sw = new StreamWriter("member.txt");
                // lines.Add($"{Member.FirstName}, nilsson, 551212-0101, {this.dateTimeNow}");
                // File.WriteAllLines(_filePath, lines);
                // string info = $"{new Member(firstName, "Nilsson", "551212-0101")}, {this.dateTimeNow}";
                sw.WriteLine(firstName);
                // string json = File.ReadAllText(args[0]);
                // int[] data = JsonConvert.DeserializeObject<int[]>(json);

            // }
            // string filePath = @"C:\SaveData\members.txt";
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
