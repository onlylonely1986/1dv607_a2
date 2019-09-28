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
        public Application()
        {
            
        }

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
                List<string> inputs = new List<string>();
                inputs = v.AskForMemberDetails();
                m.RegistryMember(inputs);
            }
            if (e == view.ConsoleView.Event.ListMembers)
            {
                view.ConsoleView.Event e2 = v.AskForAccuracy();
                if (e2 == view.ConsoleView.Event.CompactList)
                {
                    m.PrintAllMembersCompact();
                }
                if (e2 == view.ConsoleView.Event.VerboseList)
                {
                    
                    // m.PrintAllMembersVerbose();
                }
                if (e2 == view.ConsoleView.Event.SearchMember)
                {
                    
                    // m.PrintAllMembersVerbose();
                }
                if (e2 == view.ConsoleView.Event.Quit)
                {
                    return false;
                }
                return true;
            }
            if (e == view.ConsoleView.Event.NewBoat)
            {
                System.Console.WriteLine("ny båt okej");
            }
            
            return true;
        }
    }
}


    // requirements vad ska user kunna göra/anropa?

    // lägga till medlem -> metod i medlemsregister
    // hantera/ändra medlemsinformation -> metod i medlemsregister
    // visa medlems information -> metod i medlemsregister
    // ta bort medlem -> metod i medlemsregister


    // visa lista på medlemmar compact list -> metod i listMembers
    // visa lista på medlemmar verbose list -> metod i listMembers

    // lägga till en båt för en medlem ( båten ska ha typ (enum) och length) -> i medlemsregister? eller båtregister?
    // ta bort en båt
    // ändra på båtinfo
