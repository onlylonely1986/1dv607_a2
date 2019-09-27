using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace view
{

    /**
    * Represents the console view.
    *  
    */
    public class ConsoleView
    {
        public enum Event {
			None,
			NewMember,
			SearchMember,
			NewBoat,
			Quit
		}

        private List<string> _inputs = new List<string>();

        public void showConsole()
        {
            Console.WriteLine("Welcome to the boatclub register:");
            System.Console.WriteLine("  ");
            Console.WriteLine("1. Add a new member.");
            Console.WriteLine("2. Add a new boat.");
            Console.WriteLine("3. Search for members.");
            Console.WriteLine("4. Quit application.");
            System.Console.WriteLine("  ");
        }

        public bool WantsToContinueProgram()
        {
            return System.Console.ReadLine() != "4";
        }
        public void userMakesChoice()
        {   
            // System.Console.WriteLine(memberReg);
            return;
        }

        public Event GetEvent()
        {
            string c = System.Console.ReadLine();
			if (c == "4") {
                System.Console.WriteLine("Good bye, have a nice day!");
				return Event.Quit;
			}
			if (c == "1")
			{
				return Event.NewMember;
			}
			if (c == "2")
			{
				return Event.SearchMember;
			}
			if (c == "3")
			{
				return Event.NewBoat;
			}

			return Event.None;
        }

        public List<string> AskForMemberDetails()
        {
            string input1 = "";
            string input2 = "";
            string input3 = "";

            
            Console.WriteLine("Do you want to register a new member.");
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your first name.");
            input1 = Console.ReadLine();

            // TODO nån slags felhantering av användaren input
            // Console.WriteLine("Your name must be longer than one character, try to enter your first name again.");
            // input1 = Console.ReadLine();
            _inputs.Add(input1);
            Console.WriteLine("Please enter your last name.");
            input2 = Console.ReadLine();
            _inputs.Add(input2);
            Console.WriteLine("Please enter your personal number.");
            input3 = Console.ReadLine();
            _inputs.Add(input3);
            return _inputs;
        }
    }
}
