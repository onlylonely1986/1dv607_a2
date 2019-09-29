using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace model
{
    class MemberRegister
    {
        private List<Member> _members = new List<Member>();
        
        private Member _member;

        private Member _pickedMember = null;

        private BoatRegister _boatRegister = new BoatRegister();

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
                System.Console.WriteLine(m.ToStringSmall());
            }
        }

        public void PrintAllMembersVerbose()
        {
            foreach(Member m in Members)
            {
                System.Console.WriteLine(m.ToString());
            }
        }

        public void SearchByName(string search)
        {
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
                System.Console.WriteLine(m.ToStringSmall()); 
                }                
            }
            else
            {
                System.Console.WriteLine($"No member with {search} in their name was found:");
            }
        }

        public void SearchById(string searchNr)
        {
            try
            {
                int id = Int32.Parse(searchNr);
                foreach(Member m in Members)
                {
                    if(m.MemberId == id)
                    {
                        _pickedMember = m;
                    }
                }
                if (_pickedMember != null)
                {
                    System.Console.WriteLine($"Members with the id: {searchNr} were found:");
                    System.Console.WriteLine(_pickedMember.ToString());    
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

        public void ChangeMember(List<string> inputs)
        {
            _pickedMember.FirstName = inputs[0];
            _pickedMember.LastName = inputs[1];
            _pickedMember.PersNum = inputs[2];
    
            string jsonData = JsonConvert.SerializeObject(Members);
            using (StreamWriter sw = new StreamWriter("register.txt"))
            {
                sw.WriteLine(jsonData);
            }
            System.Console.WriteLine("The members information is updated in the register.");
        }

        public void RemoveMember(string searchNr)
        {
            int id = Int32.Parse(searchNr);
            if(_pickedMember != null)
            {
                System.Console.WriteLine("Member was found");
                Member _pickedMember = Members.SingleOrDefault(x => x.MemberId == id);
                Members.Remove(_pickedMember);

                // write updated memberregister to file
                string jsonData = JsonConvert.SerializeObject(Members);
                using (StreamWriter sw = new StreamWriter("register.txt"))
                {
                    sw.WriteLine(jsonData);
                }
                System.Console.WriteLine("The member is removed from register.");
            }
            else
            {
                System.Console.WriteLine("Something went wrong.");
            }
        }

        public void RegistryBoat(string type, string length)
        {
            if(_pickedMember != null)
            {
                System.Console.WriteLine(_pickedMember.ToStringSmall());
            }
            int l = Int32.Parse(length);
            Boat.BoatType t = Boat.BoatType.Other;
            System.Console.WriteLine($"Type: {type} Length: {l}");
            System.Console.WriteLine(Boat.BoatType.Sailboat);
            if (type == "1")
            {
                t = Boat.BoatType.Sailboat;
            }
            if (type == "2")
            {
                t = Boat.BoatType.Motorsailer;
            }
            if (type == "3")
            {
                t = Boat.BoatType.KayakorCanoe;
            }
            if (type == "4")
            {
                t = Boat.BoatType.Other;
            }
            _boatRegister.RegistryBoat(_pickedMember, t, l);
        }

        public MemberRegister()
        {
            this.ReadAllMembersFromFile();
            
        }
    }
}
