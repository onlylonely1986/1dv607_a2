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

        public void showConsole()
        {
            Console.WriteLine("\n\nWelcome to the boatclub register\n");
            Console.WriteLine("[1] Add a new member.");
            Console.WriteLine("[2] Search member by name.");
            Console.WriteLine("[3] Search member by member-id to change, remove or handle boats.");
            Console.WriteLine("[4] Show compact list of all members.");
            Console.WriteLine("[5] Show verbose list of all members.");
            Console.WriteLine("[6] Quit application.\n");
        }

        public bool WantsToContinueProgram()
        {
            return System.Console.ReadLine() != "4";
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

        public string AskForMemberDetailName(string action)
        {
            if (action == "new")
            {
                Console.WriteLine("Do you want to register a new member.");
            }
            if (action == "change")
            {
                Console.WriteLine("Do you want to change a members information.");
            }
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your first name.");
            string input = this.WrongHandelingNameInput();
            return input;
            
        }

        public string AskForMemberDetailLastName()
        {
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your last name.");
            string input = this.WrongHandelingNameInput();
            return input; 
        }

        private string WrongHandelingNameInput()
        {
            string input = Console.ReadLine();
            if (input.Length > 2 && input.Length < 20)
            {
                return input;   
            } else
            {
                while(input.Length < 2 || input.Length > 20)
                {
                    Console.WriteLine("Please enter a name between 2 and 20 characters length.");
                    input = Console.ReadLine();
                }
                return input;
            }
        }

        public string AskForMemberDetailNum()
        {
            Console.WriteLine("Please enter your personal number.");
            string input = Console.ReadLine();
            if (input.Length == 11)
            {
                return input;   
            } else
            {
                while(input.Length != 11)
                {
                    Console.WriteLine("Please enter a personal num with 10 numbers (this format: XXXXXX-XXXX).");
                    input = Console.ReadLine();
                }
                return input;
            }
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
                System.Console.WriteLine("Search here:\n");
				return Event.SearchWordGiven;
			}
            if (c == "2") {
				return Event.GoBack;
			}

            return Event.None;   
        }

        public string AskForSearchWord(string focus)
        {
            if (focus == "name")
            {
                Console.WriteLine("Write a name or a character in a name you want to find...\n");
            } 
            if (focus == "id")
            {
                Console.WriteLine("Write a nr of an id to find a member...\n");
            }
            return System.Console.ReadLine();
        }

        public string AskForBoatType()
        {
            Console.WriteLine("\nPick your boattype, it must be one of these (pick by number):");
            Console.WriteLine($"[1] {model.Boat.BoatType.Sailboat}");
            Console.WriteLine($"[2] {model.Boat.BoatType.Motorsailer}");
            Console.WriteLine($"[3] {model.Boat.BoatType.KayakorCanoe}");          
            Console.WriteLine($"[4] {model.Boat.BoatType.Other}");
            string type = System.Console.ReadLine();
            return type;
        }

        public string AskForBoatLength()
        {
            Console.WriteLine("\nPlease enter your boat length in feet:");
            string length = System.Console.ReadLine();
            if (length.Length > 2 && length.Length < 100)
            {
                return length;   
            } else
            {
                while(length.Length < 2 || length.Length > 100)
                {
                    Console.WriteLine("You have to a enter reasonable length on your boat.");
                    length = Console.ReadLine();
                }
                return length;
            }
        }

        public string ShowBoatInfo(string boats)
        {
            System.Console.WriteLine(boats);
            string boatNr = System.Console.ReadLine();
            return boatNr;
        }

        public bool AskForOkey(string thing)
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
    }
}
