using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class MemberRegister
    {
        private List<Member> _members = new List<Member>();

        private TextFileSave _saveData;

        public List<Member> Members
        {
            get {return _members;}
            set {
                _members = value;
            }
        }

        /**
        *   Constructor.
        */
        public MemberRegister(TextFileSave saveData)
        {
            _saveData = saveData;
            _members = _saveData.ReadDataFromFile();
        }

        public IEnumerable<Member> GetMembersAsEnums(TextFileSave t)
        {
           IEnumerable<Member> enumMembers = (IEnumerable<model.Member>)t.ReadDataFromFile().AsEnumerable();
           return enumMembers;
        }

        public void SaveNewMember(string fName, string lName, string persNum)
        {
            Member  m = new Member(fName, lName, persNum);
            
            int mId = 0;
            if (Members.Count != 0)
            {
                int nrOfM = Members.Count;
                nrOfM--;
                mId = Members[nrOfM].MemberId;
            }

            mId++;
            m.MemberId = mId;
            Members.Add(m);
            _saveData.WriteToFile(Members);
        }


        public string ChangeMember(Member pickedMember, string fName, string lName, string persNum)
        {
            pickedMember.FirstName = fName;
            pickedMember.LastName = lName;
            pickedMember.PersNum = persNum;
    
            _saveData.WriteToFile(Members);
            return "The members information is updated in the register.";
        }

        public void RemoveMember(Member pickedMember, string searchNr)
        {
            int id = Int32.Parse(searchNr);
            // string ret = "";
            if(pickedMember != null)
            {
                // ret = "Member was found\n";
                pickedMember = Members.SingleOrDefault(x => x.MemberId == id);
                Members.Remove(pickedMember);

                _saveData.WriteToFile(Members);
                // ret += "The member is removed from register.";
            }
            else
            {
                throw new Exception("Something went wrong");
            }
            // return ret;
        }

        public string GetBoatTypesListed()
        {
            int i = 0;
            string ret = "";
            foreach(model.BoatType t in Enum.GetValues(typeof(model.BoatType)))
            {
                i++;
                ret += $"[{i}] {t}\n";
            }
            return ret;
        }

        public string RegistryBoat(Member pickedMember, string type, string length)
        {
            int l = Int32.Parse(length);
            pickedMember.AddBoat(type, l);
            _saveData.WriteToFile(Members);
            return "The boat was successfully registred.";
        }

        public string GetBoatInfo(Member pickedMember)
        {
            if(pickedMember != null)
            {
                return pickedMember.GetBoatInfo();
            } 
            return "Sorry you have not added any boats to this member yet.";
        }

        public string ChangeBoat(Member pickedMember, Boat pickedBoat, string type, string length)
        {
            if (pickedBoat != null)
            {
                int l = Int32.Parse(length);
                pickedMember.ChangeBoat(pickedBoat, type, l);
                _saveData.WriteToFile(Members);
                // TODO view ansvar
                return  "The boat was updated.";
            } 
            return "";
        }

        public string RemoveBoat(Member pickedMember, Boat pickedBoat)
        {
            if (pickedBoat != null)
            {
                pickedMember.RemoveBoat(pickedBoat);
                _saveData.WriteToFile(Members);
                // TODO view ansvar
                return  "The boat was successfully removed.";
            }
            return "";
        }
    }
}
