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

        private model.Boat _pickedBoat;

        private int _indexPickedBoat;

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

        private void SetPickedBoat(string pickedBoat)
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
            // TODO view ansvar
            if (_pickedBoat != null)
            {
                // return _pickedBoat.ToString();
            } else
            {
                throw new Exception("Something went wrong!");
            }
        }

        private void EventNewMember(model.MemberRegister m, view.ConsoleView v)
        {
            string fName = v.AskForMemberDetailName(Action.New);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.SaveNewMember(fName, lName, persNum);
            _enumMembers = m.GetMembersAsEnums(_savedData);
        }

        private void EventSearchMemberName(model.MemberRegister m, view.ConsoleView v)
        {
            view.Event e2 = v.ShowSearchMenu(Action.Name);
            if (e2 == view.Event.SearchWordGiven)
            {
                string word = v.AskForSearchWord(Action.Name);
                _enumMembers = m.GetMembersAsEnums(_savedData);
                v.SearchMemberByName(_enumMembers, word);
            }
        }
        // TODO kolla att listan uppdateras om man lägger till/ändrar båt/namn, hittar ej pickedboat tror jag...
        private void EventSearchMemberId(model.MemberRegister m, view.ConsoleView v)
        {
            view.Event e = v.ShowSearchMenu(Action.Id);
            if (e == view.Event.SearchWordGiven)
            {
                string id = v.AskForSearchWord(Action.Id);
                SetPickedMember(id, m);
                if (v.SearchById(_pickedMember, id))
                {
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
        }

        private void EventChangeMember(model.MemberRegister m, view.ConsoleView v)
        {
            string fName = v.AskForMemberDetailName(Action.Change);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.ChangeMember(_pickedMember, fName, lName, persNum);
            // TODO updateras inte .. måste kolla upp!
            _enumMembers = m.GetMembersAsEnums(_savedData);
        }
        
        private void EventRemoveMember(model.MemberRegister m, view.ConsoleView v, string id)
        {
            if(v.AskForOkey(Action.Member))
            {
                m.RemoveMember(_pickedMember, id);
                _enumMembers = m.GetMembersAsEnums(_savedData);
            }
        }

        private void EventAddBoat(model.MemberRegister m, view.ConsoleView v)
        {
            string t = m.GetBoatTypesListed();  
            string pickedType = v.AskForBoatType(t);
            string length = v.AskForBoatLength();
            _result = m.RegistryBoat(_pickedMember, pickedType, length);
            _enumMembers = m.GetMembersAsEnums(_savedData);
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
                SetPickedBoat(pickBoat);
                string t = m.GetBoatTypesListed();  
                string pickedType = v.AskForBoatType(t);
                string length = v.AskForBoatLength();
                _result = m.ChangeBoat(_pickedMember, _pickedBoat, pickedType, length);
                _enumMembers = m.GetMembersAsEnums(_savedData);
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
                SetPickedBoat(pickBoat);
                if(v.AskForOkey(Action.Boat))
                {
                    _result =  m.RemoveBoat(_pickedMember, _pickedBoat);
                    _enumMembers = m.GetMembersAsEnums(_savedData);
                    v.ShowMessage(_result);
                }
            }
        }  
    }    
}
