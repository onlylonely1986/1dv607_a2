using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Model
{
    class MemberRegister
    {
        private Member _member;

        private string _filePath;

        private DirectoryInfo _dir = new DirectoryInfo(@"c:\RegisterData");

        private DateTime dateTimeNow = DateTime.Now;

        public string FilePath
        {
            get {return _filePath;}
            set
            {
                _filePath = value;
            }
        }
        public void RegistryMember(Member member)
        {
            // string filePath = @"C:\SaveData\members.txt";
            // List<string> lines = File.ReadAllLines(filePath).ToList();
            // lines.Add($"{member.FirstName}, {member.LastName}, {member.PersonalNum}, {this.dateTimeNow}");
            // File.WriteAllLines(filePath, lines);
        }

        public void CreateNewRegister ()
        {
            this.CreateNewDir();
            this.CreateNewFile();
        }

         private void CreateNewDir ()
         {
            // DirectoryInfo Dir = new DirectoryInfo(@"c:\RegisterData");
            try 
            {
                if (_dir.Exists) 
                {
                    // Indicate that the directory already exists.
                    // Console.WriteLine("That path exists already.");
                    string _filePath = $@"{_dir}\members.txt";
 
                }
                else
                {
                    // Try to create the directory.
                    _dir.Create();
                    Console.WriteLine("The directory was created successfully.");
                } 
            }
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        private void CreateNewFile ()
        {
            StreamWriter file = new StreamWriter(FilePath);
            try 
            {
                if (File.Exists(FilePath))
                {
                    System.Console.WriteLine("File exists.");
                }
                
            } 
            catch
            {
                System.Console.WriteLine("File does not exist.");
            }
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
