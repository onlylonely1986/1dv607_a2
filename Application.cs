using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace register
{
    /**
    * Represents the console view.
    *  
    */
    public class Application
    {
        public bool RunProgram()
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


    // requirements vad ska user kunna göra/anropa?

    // menyn ska fortsätta rulla till anv väljer quit

    // lägga till medlem -> metod i medlemsregister                 -> Check
    // hantera/ändra medlemsinformation -> metod i medlemsregister  -> Check
    // visa medlems information -> metod i medlemsregister          -> Check
    // ta bort medlem -> metod i medlemsregister                    -> Check 


    // visa lista på medlemmar compact list -> metod i listMembers  -> Check
    // visa lista på medlemmar verbose list -> metod i listMembers  -> Check

    // lägga till en båt för en medlem -> i båtregister             ->
    // ta bort en båt                                               ->
    // ändra på båtinfo                                             -> 
