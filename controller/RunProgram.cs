using System.Collections.Generic;

namespace controller 
{

    public class RunProgram
    {
        public bool runProgram()
        {
            model.MemberRegister m = new model.MemberRegister();
            view.ConsoleView v = new view.ConsoleView();
            view.ConsoleView.Event e;
            
            v.showConsole();
            e = v.GetEvent();             
            if (e == view.ConsoleView.Event.Quit)
            {
                return false;
            }
            if (e == view.ConsoleView.Event.NewMember)
            {
                string action = "new";
                List<string> inputs = new List<string>();
                // TODO egna metoder för varje input från anv
                inputs = v.AskForMemberDetails(action);
                m.RegistryMember(inputs);
            }
            if (e == view.ConsoleView.Event.SearchMemberName)
            {
                // TODO egen metod för dessa alternativ
                string word;
                string focusName = "name";
                view.ConsoleView.Event e2 = v.ShowSearchMenu(focusName);
                if (e2 == view.ConsoleView.Event.SearchWordGiven)
                {
                    word = v.AskForSearchWord(focusName);
                    m.SearchByName(word);
                }
                if (e2 == view.ConsoleView.Event.GoBack)
                {
                    return false;
                }
            }
            if (e == view.ConsoleView.Event.SearchMemberId)
            {
                // TODO egen metod för dessa alternativ
                string id;
                string focusId = "id";
                view.ConsoleView.Event e2 = v.ShowSearchMenu(focusId);
                if (e2 == view.ConsoleView.Event.SearchWordGiven)
                {
                    id = v.AskForSearchWord(focusId);
                    m.SearchById(id);
                    view.ConsoleView.Event e3 = v.ShowMemberActivities();
                    if(e3 == view.ConsoleView.Event.ChangeMember)
                    {
                        string action = "change";
                        List<string> inputs = new List<string>();
                        inputs = v.AskForMemberDetails(action);
                        m.ChangeMember(inputs);
                    }
                    if(e3 == view.ConsoleView.Event.RemoveMember)
                    {
                        m.RemoveMember(id);
                    }
                    if(e3 == view.ConsoleView.Event.AddBoat)
                    {
                        string type = v.AskForBoatType();
                        string length = v.AskForBoatLength();
                        m.RegistryBoat(type, length);
                    }
                    if(e3 == view.ConsoleView.Event.ChangeBoat)
                    {
                        string boats = m.GetBoatInfo();
                        string pickBoat = v.ShowBoatInfo(boats);
                        m.SetPickedBoat(pickBoat);
                        // string  = v.AskForBoatToChange();
                        string type = v.AskForBoatType();
                        string length = v.AskForBoatLength();
                        m.ChangeBoat(type, length);
                    }
                }
                if (e2 == view.ConsoleView.Event.GoBack)
                {
                    return false;
                }
            }
            if (e == view.ConsoleView.Event.CompactList)
            {
                m.PrintAllMembersCompact();
            }
            if (e == view.ConsoleView.Event.VerboseList)
            {
                m.PrintAllMembersVerbose();
            }
            return true;
        }
    }
}
