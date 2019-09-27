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
            
            

            // memberRegister.CreateNewRegister();
            
            // view.showConsole();
            // memberRegister.RegistryMember(input);
            // view.showConsole();
            // view.userMakesChoice(memberReg.AddNewMember());

            // while(view.WantsToContinueProgram())
            // user wants to continue the session
            // {
            //    view.showConsole();
            //}

			// while (m_view.WantsToPlay())
			// {
			// 	m_view.DisplayInstructions();

			// 	m_view.DisplayResult(a_game.Play());
				
			// }
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
                List<string> inputs = v.AskForMemberDetails();
                m.RegistryMember(inputs);
            }
            if (e == view.ConsoleView.Event.SearchMember)
            {
                // a_game.Hit();
                System.Console.WriteLine("söka på medlemmar jaha");
            }
            if (e == view.ConsoleView.Event.NewBoat)
            {
                // a_game.Stand();
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
