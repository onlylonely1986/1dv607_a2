using System;

namespace view
{

    /**
    * Represents the console view.
    *  
    */
    public class ConsoleView
    {
        public void ShowMenu()
        {
            System.Console.WriteLine("\n\n******************************************************************************");
            Console.WriteLine("\nWelcome to the boatclub register\n");
            Console.WriteLine("[1] Add a new member.");
            Console.WriteLine("[2] Search member by name.");
            Console.WriteLine("[3] Search member by member-id to change, remove or handle boats.");
            Console.WriteLine("[4] Show compact list of all members.");
            Console.WriteLine("[5] Show verbose list of all members.");
            Console.WriteLine("[6] Quit application.\n");
            System.Console.WriteLine("******************************************************************************");
        }

        public Event GetEvent(ValidationView v)
        {
            int i = v.ValidateMenuInput();
			if (i == 6) {
                System.Console.WriteLine("Good bye, have a nice day!");
				return Event.Quit;
			}
			if (i == 1)
			{
				return Event.NewMember;
			}
            if (i == 2)
			{
				return Event.SearchMemberName;
			}
            if (i == 3)
			{
				return Event.SearchMemberId;
			}
            if (i == 4)
			{
				return Event.CompactList;
			}
			if (i == 5)
			{
				return Event.VerboseList;
			}
			
			return Event.None;
        }

        public bool AskForOkey(Enum thing)
        {
            bool ok = false;
            System.Console.WriteLine($"Do you really want to remove the {thing}?");
            System.Console.WriteLine("Press enter if you are sure to remove, else press anything else.");
            ConsoleKeyInfo info = Console.ReadKey();
            // TODO behövs detta valideras nåt mer?
            if (info.Key != ConsoleKey.Enter)
            {
                System.Console.WriteLine("Ups, let's go back...");
                return ok;
            }
            else
            {
                System.Console.WriteLine("Removing...");
                ok = true;
                return ok;
            }
        }
    }
}
