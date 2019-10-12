using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("\n\nWelcome to the boatclub register\n");
            Console.WriteLine("[1] Add a new member.");
            Console.WriteLine("[2] Search member by name.");
            Console.WriteLine("[3] Search member by member-id to change, remove or handle boats.");
            Console.WriteLine("[4] Show compact list of all members.");
            Console.WriteLine("[5] Show verbose list of all members.");
            Console.WriteLine("[6] Quit application.\n");
        }

        public Event GetEvent()
        {
            int i = Convert.ToInt32(Console.ReadLine());
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
                System.Console.WriteLine("Compact list:\n");
				return Event.CompactList;
			}
			if (i == 5)
			{
                System.Console.WriteLine("Verbose list:\n");
				return Event.VerboseList;
			}
			
			return Event.None;
        }

        public bool AskForOkey(Enum thing)
        {
            bool ok = false;
            System.Console.WriteLine($"Are you sure you want to remove the {thing}?");
            System.Console.WriteLine("Press enter if you are sure to remove, else press anything else.");
            ConsoleKeyInfo info = Console.ReadKey();
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

        public void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }

       
    }
}
