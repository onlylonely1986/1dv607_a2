using System.Collections.Generic;

namespace controller 
{
    public class Controller
    {
        public bool RunProgram()
        {
            model.MemberRegister m = new model.MemberRegister();
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
                string all = m.PrintAllMembersCompact();
                v.ShowMessage(all);
            }
            if (e == view.Event.VerboseList)
            {
                string all = m.PrintAllMembersVerbose();
                v.ShowMessage(all);
            }
            return true;
        }

        private void EventNewMember(model.MemberRegister m, view.ConsoleView v)
        {
            string action = "new";
            string fName = v.AskForMemberDetailName(action);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.RegistryMember(fName, lName, persNum);
        }

        private void EventSearchMemberName(model.MemberRegister m, view.ConsoleView v)
        {
            string word;
            string focusName = "name";
            view.Event e2 = v.ShowSearchMenu(focusName);
            if (e2 == view.Event.SearchWordGiven)
            {
                word = v.AskForSearchWord(focusName);
                string result = m.SearchByName(word);
                v.ShowMessage(result);
            }
        }

        private void EventSearchMemberId(model.MemberRegister m, view.ConsoleView v)
        {
            string id;
            string focusId = "id";
            string thing = "member";
            view.Event e = v.ShowSearchMenu(focusId);
            if (e == view.Event.SearchWordGiven)
            {
                    id = v.AskForSearchWord(focusId);
                    string result = m.SearchById(id);
                    v.ShowMessage(result);
                    view.Event e3 = v.ShowMemberActivities();
                    if(e3 == view.Event.ChangeMember)
                    {
                       EventChangeMember(m, v);
                    }

                    if(e3 == view.Event.RemoveMember)
                    {
                        EventRemoveMember(m, v, id, thing);
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
            string action = "change";
            string fName = v.AskForMemberDetailName(action);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.ChangeMember(fName, lName, persNum);
        }

        
        private void EventRemoveMember(model.MemberRegister m, view.ConsoleView v, string id, string thing)
        {
            if(v.AskForOkey(thing))
            {
                m.RemoveMember(id);
            }
        }

        private void EventAddBoat(model.MemberRegister m, view.ConsoleView v)
        {
            string t = m.GetBoatTypesListed();  
            string pickedType = v.AskForBoatType(t);
            string length = v.AskForBoatLength();
            string respons = m.RegistryBoat(pickedType, length);
            v.ShowMessage(respons);
        }
 
        private void EventChangeBoat(model.MemberRegister m, view.ConsoleView v)
        {
            string handle = "change";
            v.AskForBoatToPickText(handle);
            string boats = m.GetBoatInfo();
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
                string respons = m.ChangeBoat(pickedType, length);
                v.ShowMessage(respons);
            }
        }  
        private void EventRemoveBoat(model.MemberRegister m, view.ConsoleView v)
        {
            string handle = "remove";
            string thing = "boat";
            v.AskForBoatToPickText(handle);
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
                    string respons =  m.RemoveBoat();
                    v.ShowMessage(respons);
                }
            }
        }  
    }    
}
