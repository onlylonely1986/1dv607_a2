using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class MemberRegister
    {
        private List<Member> _members = new List<Member>();

        private TextFileSave _saveData;

        private Member _pickedMember;

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

        public void SaveNewMember(string fName, string lName, long persNum)
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

        public void SetPickedMember(int pickedMemberId)
        {
             foreach(Member mem in Members)
            {
                if(mem.MemberId == pickedMemberId)
                {
                    _pickedMember = mem;
                }
            }
        }


        public void ChangeMember(int pickedMemberId, string fName, string lName, long persNum)
        {
            SetPickedMember(pickedMemberId);
            _pickedMember.FirstName = fName;
            _pickedMember.LastName = lName;
            _pickedMember.PersNum = persNum;
            _saveData.WriteToFile(Members);
        }

        public void RemoveMember(Member pickedMember, int id)
        {
            pickedMember = Members.SingleOrDefault(x => x.MemberId == id);
            Members.Remove(pickedMember);

            _saveData.WriteToFile(Members);
        }

        public void RegistryBoat(int pickedMemberId, int type, int length)
        {
            SetPickedMember(pickedMemberId);
            _pickedMember.AddBoat(type, length);
            _saveData.WriteToFile(Members);
        }

        public void ChangeBoat(int pickedMemberId, int pickedBoatId, int type, int length)
        {
            SetPickedMember(pickedMemberId);
            Boat boat;
            for (int i = 0; i < _pickedMember.Boats.Count; i++)
            {
                if (i == pickedBoatId)
                {
                    boat = _pickedMember.Boats[i]; 
                    _pickedMember.ChangeBoat(boat, type, length);
                }
            }
                _saveData.WriteToFile(Members);
        }

        public void RemoveBoat(int pickedMemberId, int pickedBoatId)
        {
            SetPickedMember(pickedMemberId);
            _pickedMember.RemoveBoat(pickedBoatId);
            _saveData.WriteToFile(Members);
        }
    }
}
