using System;
using System.Collections.Generic;

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
            SearchMemberName,
            SearchMemberId,
			ChangeMember,
            ChangeBoat,
            AddBoat,
            RemoveBoat,
            RemoveMember,
            CompactList,
            VerboseList,
            SearchWordGiven,
            GoBack,
            Quit

		}

        private List<string> _inputs = new List<string>();

        public void showConsole()
        {
            Console.WriteLine("\n\nWelcome to the boatclub register\n");
            Console.WriteLine("[1] Add a new member.");
            Console.WriteLine("[2] Search member by name.");
            Console.WriteLine("[3] Search member by member-id to change or remove");
            Console.WriteLine("[4] Show compact list of all members.");
            Console.WriteLine("[5] Show verbose list of all members.");
            Console.WriteLine("[6] Quit application.\n");
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
			if (c == "6") {
                System.Console.WriteLine("Good bye, have a nice day!");
				return Event.Quit;
			}
			if (c == "1")
			{
				return Event.NewMember;
			}
            if (c == "2")
			{
				return Event.SearchMemberName;
			}
            if (c == "3")
			{
				return Event.SearchMemberId;
			}
            if (c == "4")
			{
                System.Console.WriteLine("Compact list:\n");
				return Event.CompactList;
			}
			if (c == "5")
			{
                System.Console.WriteLine("Verbose list:\n");
				return Event.VerboseList;
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

            // TODO nån slags felhantering av användarens input
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


        public Event ShowMemberActivities()
        {
            Console.WriteLine("\n\n[1] Change member information.");
            Console.WriteLine("[2] Add a new boat to member.");
            Console.WriteLine("[3] Change boat information.");
            Console.WriteLine("[4] Remove boat from member.");
            Console.WriteLine("[5] Remove member from register.");
            Console.WriteLine("[6] Go back to main menu.\n");
            string c = System.Console.ReadLine();
            if (c == "1") {
                System.Console.WriteLine("Change member information:\n");
				return Event.ChangeMember;
			}

            if (c == "2") {
                System.Console.WriteLine("Add new boat to member:\n");
				return Event.AddBoat;
			}

            if (c == "3") {
                System.Console.WriteLine("Change boat information:\n");
				return Event.ChangeBoat;
			}
            if (c == "4") {
                System.Console.WriteLine("Remove boat from member:\n");
				return Event.RemoveBoat;
			}
            if (c == "5") {
                System.Console.WriteLine("Remove member from register:\n");
				return Event.RemoveMember;
			}
            if (c == "6") {
				return Event.GoBack;
			}

            return Event.None;
        }

        public Event ShowSearchMenu(string focus)
        {
            Console.WriteLine($"\n\n[1] Search for members by {focus}.");
            Console.WriteLine("[2] Go Back To Start Menu.\n");
            string c = System.Console.ReadLine();
            if (c == "1") {
                System.Console.WriteLine("Search by name:\n");
				return Event.SearchWordGiven;
			}
            if (c == "2") {
				return Event.GoBack;
			}

            return Event.None;   
        }

        public string AskForSearchWord()
        {
            Console.WriteLine("Write a name or a character in a name you want to find...\n");
            string searchWord = System.Console.ReadLine();
            return searchWord;
        }

        public string AskForSearchId()
        {
            Console.WriteLine("Write a nr of an id to find a member...\n");
            string searchNr = System.Console.ReadLine();
            return searchNr;
        }
    }
}
