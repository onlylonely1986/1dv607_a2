using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace model
{
    class MemberRegister
    {
        private List<Member> _members = new List<Member>();
        
        private Member _member;

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
            
            int mId = 0;
            if (Members.Count != 0)
            {
                mId = Members.Count;
            }

            mId++; 
            m.MemberId = mId;
            Members.Add(m);
            string jsonData = JsonConvert.SerializeObject(Members);

            using (StreamWriter sw = new StreamWriter("register.txt"))
            {
                sw.WriteLine(jsonData);
            }
        }

        public void ReadAllMembersFromFile()
        {   
            string jsonFromFile;
            using (StreamReader sr = new StreamReader("register.txt")) 
            {
                jsonFromFile = sr.ReadToEnd();
                // System.Console.WriteLine(jsonFromFile);

                Members = JsonConvert.DeserializeObject<List<Member>>(jsonFromFile);
            }
        }

        public void PrintAllMembersCompact()
        {            
            foreach(Member m in Members)
            {
                int nrOfBoats = 0;
                if (m.Boats != null)
                {
                    nrOfBoats = m.Boats.Count;
                }
                System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Boats: {nrOfBoats}");
            }
        }

        public void PrintAllMembersVerbose()
        {
            foreach(Member m in Members)
            {
                
                if (m.Boats != null)
                {
                    System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Personal number: {m.PersNum}, Boats: {m.Boats}, Member since: {m.MemberSince}");
                }
                else
                {
                    string boats = "No boats added yet";
                    System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Personal number: {m.PersNum}, Boats: {boats}, Member since: {m.MemberSince}");
                }
                
            }
        }

        public void SearchByName(string search)
        {
            // string searchWord = "u";
            List<Member> searchList = new List<Member>();
            foreach(Member m in Members)
            {
                if(m.FirstName.ToLower().Contains(search.ToLower()) || m.LastName.ToLower().Contains(search.ToLower()))
                {
                    searchList.Add(m);
                }
            }
            if (searchList.Count != 0)
            {
                System.Console.WriteLine($"This members with '{search}' in their name were found:");
                foreach(Member m in searchList)
                {
                System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Boats: 0"); // TODO obs bad practice to have cw in model
                }                
            }
            else
            {
                System.Console.WriteLine($"No member with {search} in their name was found:");
            }
        }

        public void SearchById(string searchNr)
        {
            // int searchNr = 4;
            try
            {
                int res = Int32.Parse(searchNr);
                Console.WriteLine(res);
                List<Member> searchList = new List<Member>();
                foreach(Member m in Members)
                {
                    if(m.MemberId == res)
                    {
                        searchList.Add(m);
                    }
                }
                if (searchList.Count != 0)
                {
                    System.Console.WriteLine($"Members with the id: {searchNr} were found:");
                    foreach(Member m in searchList)
                    {
                    System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Boats: 0"); // TODO obs bad practice to have cw in model
                    }                
                }
                else
                {
                    System.Console.WriteLine($"No member with {searchNr} as id was found:");
                }

            } catch (FormatException)
            {
                System.Console.WriteLine("Exception");
            }
        }

        public MemberRegister()
        {
            this.ReadAllMembersFromFile();
        }
    }
}
