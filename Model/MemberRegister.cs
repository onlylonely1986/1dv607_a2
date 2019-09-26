using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    class MemberRegister
    {
        // private Member _member;

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
            // Member member = new Member();
            // member.ToString();
            // memberRegister.RegistryMember("Ida", "Larsson", "600101-8000");

            // string filePath = @"C:\SaveData\members.txt";
            // List<string> lines = File.ReadAllLines(filePath).ToList();
            // lines.Add($"{member.FirstName}, {member.LastName}, {member.PersonalNum}, {this.dateTimeNow}");
            // File.WriteAllLines(filePath, lines);
        }

        /**
        *   Method checking for exisisting directory and file, and creating them 
        *   if they not exist.
         */
        public void CreateNewRegister ()
        {
            try 
            {
            string dirPath = this.CreateNewDir();
            this.CreateNewFile(dirPath);
            } catch (Exception e) 
            {
                Console.WriteLine("Something went wrong when trying to create a new directory: {0}", e.ToString());
            }

        }

         private string CreateNewDir ()
         {
            string _filePath = $@"{_dir}\";

            if (_dir.Exists) 
            {
                return _filePath;
            }
            else
            {
                _dir.Create();
                return _filePath;
            }
        }

        private void CreateNewFile (string dirPath)
        {
            string newFile = "members.txt";
            _filePath = $"{dirPath}{newFile}";
            StreamWriter file = new StreamWriter(_filePath);
            try 
            {
                if (File.Exists(_filePath))
                {
                    return;
                }
                
            } 
            catch
            {
                System.Console.WriteLine("Something went wrong when creating the file.");
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
