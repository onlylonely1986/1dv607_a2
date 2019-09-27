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
            model.MemberRegister memberRegister = new model.MemberRegister();
            view.ConsoleView view = new view.ConsoleView();

            // memberRegister.CreateNewRegister();
            
            // view.showConsole();
            // memberRegister.RegistryMember(input);

            // a_game.AddSubscriber(this);
			// m_view.DisplayInstructions();

            while(view.WantsToContinueProgram())
            // user wants to continue the session
            {
                view.showConsole();
            }
			// while (m_view.WantsToPlay())
			// {
			// 	m_view.DisplayInstructions();

			// 	m_view.DisplayResult(a_game.Play());
				
			// }
            
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
