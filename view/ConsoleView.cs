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

        // TODO: this object is responsible for much metodhs, is it possible to break into smaller piecies?
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

            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1) {
                System.Console.WriteLine("Change member information:\n");
				return Event.ChangeMember;
			}

            if (i == 2) {
                System.Console.WriteLine("Add new boat to member:\n");
				return Event.AddBoat;
			}

            if (i == 3) {
                System.Console.WriteLine("Change boat information:\n");
				return Event.ChangeBoat;
			}
            if (i == 4) {
                System.Console.WriteLine("Remove boat from member:\n");
				return Event.RemoveBoat;
			}
            if (i == 5) {
                System.Console.WriteLine("Remove member from register:\n");
				return Event.RemoveMember;
			}
            if (i == 6) {
				return Event.GoBack;
			}

            return Event.None;
        }

        public Event ShowSearchMenu(string focus)
        {
            Console.WriteLine($"\n\n[1] Search for members by {focus}.");
            Console.WriteLine("[2] Go Back To Start Menu.\n");
            string s = Console.ReadLine();
            try
            {
                int i = Convert.ToInt32(s);
                if (i == 1)
                {
                    System.Console.WriteLine("Search here:\n");
                    return Event.SearchWordGiven;
                } else
                {
                    return Event.GoBack;
                }
            } 
            catch
            {
                throw new FormatException("Wrong input type");
            }            
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

        public string AskForBoatType(string types)
        {
            Console.WriteLine("\nPick your boattype, it must be one of these (pick by number):");
            System.Console.WriteLine(types);
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

        public void AskForBoatToPickText(string handle)
        {
            System.Console.WriteLine($"Pick the boat to {handle}:");
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

        public void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public void PrintVerboseList(IEnumerable<model.Member> members)
        {
            foreach(model.Member M in members)
            {
                System.Console.WriteLine(M);
            }
        }

        public void PrintCompactList(IEnumerable<model.Member> members)
        {
            foreach(model.Member M in members)
            {
                System.Console.WriteLine($"Id: {M.MemberId}, Name: {M.FirstName} {M.LastName}, Boats: {M.Boats.Count}");
            }
        }


        public void SearchMemberByName(IEnumerable<model.Member> members, string search)
        {
            List<model.Member> searchList = new List<model.Member>();
            string ret = "";
            foreach(model.Member m in members)
            {
                if(m.FirstName.ToLower().Contains(search.ToLower()) || m.LastName.ToLower().Contains(search.ToLower()))
                {
                    searchList.Add(m);
                }
            }
            if (searchList.Count != 0)
            {
                ret = $"This members with '{search}' in their name were found:\n";
                foreach(model.Member m in searchList)
                {
                    ret += $"{m.ToStringSmall()}\n";
                }                
            }
            else
            {
                ret = $"No member with {search} in their name was found:";
            }
            System.Console.WriteLine(ret);
        }
    }
}
