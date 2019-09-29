using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace model
{
    class MemberRegister
    {
        private int _indexPickedBoat;
        private List<Member> _members = new List<Member>();
        
        private Member _member;

        private Member _pickedMember = null;

        private Boat _pickedBoat = null;

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
            this.WriteToFile();
        }

        public void ReadAllMembersFromFile()
        {   
            string jsonFromFile;
            using (StreamReader sr = new StreamReader("register.txt")) 
            {
                jsonFromFile = sr.ReadToEnd();
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
    
            this.WriteToFile();
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

                this.WriteToFile();
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

            Boat.BoatType t = _boatRegister.PickBoatType(type);
            
            _boatRegister.RegistryBoat(_pickedMember, t, l);
            this.WriteToFile();
        }

        public string GetBoatInfo()
        {
            if(_pickedMember != null)
            {
                System.Console.WriteLine($"Pick the boat to change:");
                int ind = 1;
                string boats = String.Concat(_pickedMember.Boats.Select(b=> $"[{ind++}]: {b.ToString()}\n"));
                return boats;
            } 
            return "";
        }

        public string SetPickedBoat(string pickedBoat)
        {
            int b = Int32.Parse(pickedBoat);
            b--;
            for (int i = 0; i < _pickedMember.Boats.Count; i++)
            {
                if(i == b)
                {
                    _pickedBoat = _pickedMember.Boats[i];
                    _indexPickedBoat = i;
                }
            }
            return _pickedBoat.ToString();
        }

        public void ChangeBoat(string type, string length)
        {
            int l = Int32.Parse(length);
            Boat.BoatType t = _boatRegister.PickBoatType(type);
            _boatRegister.ChangeBoat(_pickedBoat, t, l);
            this.WriteToFile();
        }

        public void RemoveBoat()
        {
            if (_pickedBoat != null)
            {
                // Members.Remove(_pickedBoat);
                _pickedMember.Boats.RemoveAt(_indexPickedBoat);
                System.Console.WriteLine("The boat was successfully removed.");
                _pickedBoat = null;
                this.WriteToFile();
            }
        }

        private void WriteToFile()
        {
            string jsonData = JsonConvert.SerializeObject(Members);
            using (StreamWriter sw = new StreamWriter("register.txt"))
            {
                sw.WriteLine(jsonData);
            }
        }

        public MemberRegister()
        {
            this.ReadAllMembersFromFile();
        }
    }
}
