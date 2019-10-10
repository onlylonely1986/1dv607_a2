using System.Collections.Generic;
using System.Linq;

namespace controller 
{
    public class Controller
    {

        private string _action;

        private string _result;

        private model.TextFileSave _saveData;

        private IEnumerable<model.Member> _enumMembers;

        private List<model.Member> _members;

        public bool RunProgram(model.TextFileSave t)
        {
            _saveData = t;
            _members = _saveData.ReadDataFromFile();
            _enumMembers = (IEnumerable<model.Member>)_members.AsEnumerable();
            model.MemberRegister m = new model.MemberRegister(_saveData);
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
                // dependencie to model
                v.PrintCompactList(_enumMembers);
            }
            if (e == view.Event.VerboseList)
            {
                // dependencie to model
                v.PrintVerboseList(_enumMembers);
            }
            return true;
        }

        private void EventNewMember(model.MemberRegister m, view.ConsoleView v)
        {
            _action = "new";
            string fName = v.AskForMemberDetailName(_action);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.SaveNewMember(fName, lName, persNum);
        }

        private void EventSearchMemberName(model.MemberRegister m, view.ConsoleView v)
        {
            _action = "name";
            view.Event e2 = v.ShowSearchMenu(_action);
            if (e2 == view.Event.SearchWordGiven)
            {
                string word = v.AskForSearchWord(_action);
                // _result = m.SearchByName(word);
                v.SearchMemberByName(_enumMembers, word);
            }
        }

        private void EventSearchMemberId(model.MemberRegister m, view.ConsoleView v)
        {
            _action = "id";
            _action = "member";
            view.Event e = v.ShowSearchMenu(_action);
            if (e == view.Event.SearchWordGiven)
            {
                string id = v.AskForSearchWord(_action);
                _result = m.SearchById(id);
                v.ShowMessage(_result);
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
            _action = "change";
            string fName = v.AskForMemberDetailName(_action);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.ChangeMember(fName, lName, persNum);
        }

        
        private void EventRemoveMember(model.MemberRegister m, view.ConsoleView v, string id)
        {
            if(v.AskForOkey(_action))
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
            _action = "change";
            v.AskForBoatToPickText(_action);
            string boats = m.GetBoatInfo();
            // TODO: är detta fult att ha? 
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
            _action = "remove";
            string thing = "boat";
            v.AskForBoatToPickText(_action);
            string boats = m.GetBoatInfo();
            if (boats == "Sorry you have not added any boats to this member yet.")
            {
                v.ShowMessage(boats);
            }
            else
            {
                string pickBoat = v.ShowBoatInfo(boats);
                m.SetPickedBoat(pickBoat);
                if(v.AskForOkey(thing))
                {
                    _result =  m.RemoveBoat();
                    v.ShowMessage(_result);
                }
            }
        }  
    }    
}
