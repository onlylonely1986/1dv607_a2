using System;
using System.Collections.Generic;
using System.Linq;

namespace controller 
{
    public class Controller
    {

        IEnumerable<model.Member> _enumMembers;
        private string _result;
        private model.TextFileSave _savedData;

        private model.Member _pickedMember;

        public bool RunProgram()
        {
            _savedData = new model.TextFileSave();
            model.MemberRegister m = new model.MemberRegister(_savedData);
            view.ConsoleView v = new view.ConsoleView();
            view.Event e;

            v.ShowMenu();
            e = v.GetEvent();
            if (e == view.Event.Quit)
            {
                return false;
            }
            if (e == view.Event.NewMember)
            {
                EventNewMember(m, v);
            }
            if (e == view.Event.SearchMemberName)
            {
                EventSearchMemberName(m, v);
            }
            if (e == view.Event.SearchMemberId)
            {
                EventSearchMemberId(m, v);
            }
            if (e == view.Event.CompactList)
            {
                v.PrintCompactList(m.GetMembersAsEnums(_savedData));
            }
            if (e == view.Event.VerboseList)
            {
                v.PrintVerboseList(m.GetMembersAsEnums(_savedData));
            }
            return true;
        }

        private void SetPickedMember(string searchNr, model.MemberRegister m)
        { 
            int id = Int32.Parse(searchNr);
            _enumMembers = m.GetMembersAsEnums(_savedData);
            foreach(model.Member mem in _enumMembers)
            {
                if(mem.MemberId == id)
                {
                    _pickedMember = mem;
                }
            }
        }

        private void EventNewMember(model.MemberRegister m, view.ConsoleView v)
        {
            string fName = v.AskForMemberDetailName(Action.New);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.SaveNewMember(fName, lName, persNum);
        }

        private void EventSearchMemberName(model.MemberRegister m, view.ConsoleView v)
        {
            view.Event e2 = v.ShowSearchMenu(Action.Name);
            if (e2 == view.Event.SearchWordGiven)
            {
                string word = v.AskForSearchWord(Action.Name);
                v.SearchMemberByName(_enumMembers, word);
            }
        }

        private void EventSearchMemberId(model.MemberRegister m, view.ConsoleView v)
        {
            view.Event e = v.ShowSearchMenu(Action.Id);
            if (e == view.Event.SearchWordGiven)
            {
                string id = v.AskForSearchWord(Action.Id);
                SetPickedMember(id, m);
                v.SearchById(_pickedMember, id);
                view.Event e3 = v.ShowMemberActivities();
                if(e3 == view.Event.ChangeMember)
                {
                    EventChangeMember(m, v);
                }

                if(e3 == view.Event.RemoveMember)
                {
                    EventRemoveMember(m, v, id);
                }

                if(e3 == view.Event.AddBoat)
                {
                    EventAddBoat(m,v);
                }

                if(e3 == view.Event.ChangeBoat)
                {
                    EventChangeBoat(m, v);
                }

                if(e3 == view.Event.RemoveBoat)
                {
                    EventRemoveBoat(m, v);
                }
            }  
        }

        private void EventChangeMember(model.MemberRegister m, view.ConsoleView v)
        {
            string fName = v.AskForMemberDetailName(Action.Change);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.ChangeMember(fName, lName, persNum);
        }
        
        private void EventRemoveMember(model.MemberRegister m, view.ConsoleView v, string id)
        {
            if(v.AskForOkey(Action.Member))
            {
                m.RemoveMember(id);
            }
        }

        private void EventAddBoat(model.MemberRegister m, view.ConsoleView v)
        {
            string t = m.GetBoatTypesListed();  
            string pickedType = v.AskForBoatType(t);
            string length = v.AskForBoatLength();
            _result = m.RegistryBoat(pickedType, length);
            v.ShowMessage(_result);
        }
 
        private void EventChangeBoat(model.MemberRegister m, view.ConsoleView v)
        {
            v.AskForBoatToPickText(Action.Change);
            string boats = m.GetBoatInfo(_pickedMember);

            if (boats == "Sorry you have not added any boats to this member yet.")
            {
                v.ShowMessage(boats);
            }
            else
            {
                string pickBoat = v.ShowBoatInfo(boats);
                m.SetPickedBoat(pickBoat);
                string t = m.GetBoatTypesListed();  
                string pickedType = v.AskForBoatType(t);
                string length = v.AskForBoatLength();
                _result = m.ChangeBoat(pickedType, length);
                v.ShowMessage(_result);
            }
        }  
        private void EventRemoveBoat(model.MemberRegister m, view.ConsoleView v)
        {
            v.AskForBoatToPickText(Action.Remove);
            string boats = m.GetBoatInfo(_pickedMember);
            if (boats == "Sorry you have not added any boats to this member yet.")
            {
                v.ShowMessage(boats);
            }
            else
            {
                string pickBoat = v.ShowBoatInfo(boats);
                m.SetPickedBoat(pickBoat);
                if(v.AskForOkey(Action.Boat))
                {
                    _result =  m.RemoveBoat();
                    v.ShowMessage(_result);
                }
            }
        }  
    }    
}
