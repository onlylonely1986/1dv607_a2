using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace model
{
    class MemberRegister
    {
        private List<Member> _members = new List<Member>();
        
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
            get {return _members;}
            set {
                _members = value;
            }

        }

        public void RegistryMember(List<string> inputs)
        {
            string firstName = inputs[0];
            string lastName = inputs[1];
            string persNum = inputs[2];

            Member  m = new Member(firstName, lastName, persNum);
            System.Console.WriteLine(" ------- ");

            Members.Add(m);
            string jsonData = JsonConvert.SerializeObject(Members);

            using (StreamWriter sw = new StreamWriter("register.txt"))
            {
                sw.WriteLine(jsonData);
            }
        }

        public Member AddNewMember()
        {
            _member = new Member("Lone", "Nilsson", "551212-0101");
            System.Console.WriteLine("nu körs denna");
            return _member;
        }


        public void ReadAllMembersFromFile()
        {   
            string jsonFromFile;
            using (StreamReader sr = new StreamReader("register.txt")) 
            {
                jsonFromFile = sr.ReadToEnd();
                System.Console.WriteLine(jsonFromFile);

                // List<Member> readData = JsonConvert.DeserializeObject<List<Member>>(jsonFromFile);
                // Members = readData;
                
                // System.Console.WriteLine(Members);
                // System.Console.WriteLine(savedMembers);
                // List<Member> Members;
                
                // // Read and display lines from the file until the end of 
                // // the file is reached.
                // while ((line = sr.ReadLine()) != null) 
                // {
                //    Console.WriteLine(line[0]);
                //     // List<Member> Members;
                    // Member m = new Member(line[0].);
                    // JsonConvert.DeserializeObject<List<Member>>(list);

                    // System.Console.WriteLine(line);
                //     // members = JsonConvert.DeserializeObject<List<Member>>(line);
                
                //     foreach(string line in sr.ReadLine())
                //     {
                //         System.Console.WriteLine(item);
                //     //    System.Console.WriteLine("Id: " + m.MemberId + "\t First name: " + m.FirstName + "\t Last name: " + m.LastName + "\t Personal number: " + m.PersNum + "\t Boats: " + m.Boats + "\t Member since: " + m.MemberSince);
                //     }
                //}
                // sr.Close();
            }
            
            // StreamReader sr = new StreamReader(@"register.txt");
            // 
        }

        public MemberRegister()
        {
            this.ReadAllMembersFromFile();
        }
    }
}
