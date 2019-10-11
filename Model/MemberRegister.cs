using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class MemberRegister
    {
        private int _indexPickedBoat;
        private List<Member> _members = new List<Member>();

        private Member _pickedMember = null;

        private Boat _pickedBoat = null;

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


        public string ChangeMember(string fName, string lName, string persNum)
        {
            _pickedMember.FirstName = fName;
            _pickedMember.LastName = lName;
            _pickedMember.PersNum = persNum;
    
            _saveData.WriteToFile(Members);
            return "The members information is updated in the register.";
        }

        public string RemoveMember(string searchNr)
        {
            int id = Int32.Parse(searchNr);
            string ret = "";
            if(_pickedMember != null)
            {
                ret = "Member was found\n";
                Member _pickedMember = Members.SingleOrDefault(x => x.MemberId == id);
                Members.Remove(_pickedMember);

                _saveData.WriteToFile(Members);
                ret += "The member is removed from register.";
            }
            else
            {
                ret = "Something went wrong.";
            }
            return ret;
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

        public string RegistryBoat(string type, string length)
        {
            int l = Int32.Parse(length);
            _pickedMember.AddBoat(type, l);
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

        // TODO controller-ansvar!
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
            if (_pickedBoat != null)
            {
                return _pickedBoat.ToString();
            } else
            {
                return "You have to add a boat first.";
            }
        }

        public string ChangeBoat(string type, string length)
        {
            if (_pickedBoat != null)
            {
                int l = Int32.Parse(length);
                _pickedMember.ChangeBoat(_pickedBoat, type, l);
                _saveData.WriteToFile(Members);
                return  "The boat was updated.";
            } 
            return "";
        }

        public string RemoveBoat()
        {
            if (_pickedBoat != null)
            {
                _pickedMember.RemoveBoat(_pickedBoat);
                _pickedBoat = null;
                _saveData.WriteToFile(Members);
                return  "The boat was successfully removed.";
            }
            return "";
        }
    }
}
