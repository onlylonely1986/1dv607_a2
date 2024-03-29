using System;
using System.Collections.Generic;
using System.Linq;

namespace view
{

    /**
    * Represents the member view activities.
    *  
    */
    public class MemberView
    {
        public Event ShowMemberActivities(ValidationView v)
        {
            Console.WriteLine("\n\n[1] Change member information.");
            Console.WriteLine("[2] Add a new boat to member.");
            Console.WriteLine("[3] Change boat information.");
            Console.WriteLine("[4] Remove boat from member.");
            Console.WriteLine("[5] Remove member from register.");
            Console.WriteLine("[6] Go back to main menu.\n");

            int i = v.ValidateMenuInput(7);
            if (i == 1) 
            {
                System.Console.WriteLine("Change member information:\n");
				return Event.ChangeMember;
			}

            if (i == 2) 
            {
                System.Console.WriteLine("Add new boat to member:\n");
				return Event.AddBoat;
			}

            if (i == 3) 
            {
                System.Console.WriteLine("Change boat information:\n");
				return Event.ChangeBoat;
			}
            if (i == 4) 
            {
                System.Console.WriteLine("Remove boat from member:\n");
				return Event.RemoveBoat;
			}
            if (i == 5) 
            {
                System.Console.WriteLine("Remove member from register:\n");
				return Event.RemoveMember;
			}
            if (i == 6) 
            {
				return Event.GoBack;
			}

            return Event.None;
        }

        public Event ShowSearchMenu(Enum focus, ValidationView v)
        {
            Console.WriteLine($"\n\n[1] Search for members by {focus.ToString().ToLower()}.");
            Console.WriteLine("[2] Go Back To Start Menu.\n");

            int i = v.ValidateMenuInput(3);    
            if (i == 1)
            {
                System.Console.WriteLine("Search here:\n");
                return Event.SearchWordGiven;
            }
            if (i == 2)
            {
                System.Console.WriteLine("Back to main menu.");
				return Event.GoBack;
			} 
            
            return Event.None;         
        }

        public int AskForSearchId(ValidationView v)
        {
            Console.WriteLine("Write a nr of an id to find a member...\n");
            return v.ValidateStringInputAsInt();
        }

        public string AskForSearchName()
        {
            Console.WriteLine("Write a name or a character in a name you want to find...\n");
            string input = Console.ReadLine();
            List<string> invalidChars = new List<string>() { "!", "?", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };
            while(input.Any(char.IsDigit) || (input.Length < 1 && input.Length > 10))
            {
                foreach(string s in invalidChars)
                {
                    if(input.Contains(s))
                    {
                        Console.WriteLine($"Invalid characters: {s}");
                    }
                }
                if(input.Length < 2 && input.Length > 20)
                {
                    Console.WriteLine("Please enter a name between 2 and 20 characters length.");
                }
                if(input.Any(char.IsDigit))
                {
                    Console.WriteLine("Please don't mix up with numbers.");
                }
                
                input = Console.ReadLine();
            }            
            return input;
        }

        public string AskForMemberDetailName(Enum action, ValidationView v)
        {
            if (action.ToString() == "New")
            {
                Console.WriteLine("Do you want to register a new member.");
            }
            if (action.ToString() == "Change")
            {
                Console.WriteLine("Do you want to change a members information.");
            }
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your first name.");
            string input = v.ValidateStringInput();
            return input;
        }

        public string AskForMemberDetailLastName(ValidationView v)
        {
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your last name.");
            string input = v.ValidateStringInput();
            return input; 
        }

        public long AskForMemberDetailNum()
        {
            Console.WriteLine("Please enter your personal number.");
            string input = Console.ReadLine();
            long persNr;
            while (!long.TryParse(input, out persNr) || input.Length != 6)
            {
                System.Console.WriteLine("Please enter a personal num with 10 numbers (this format: YYMMDD).");
                input = System.Console.ReadLine();
            }
            persNr = Int64.Parse(input);
            return persNr;
        }

        public void SearchMemberByName(IEnumerable<model.Member> members, string search)
        {
            List<model.Member> searchList = new List<model.Member>();
            foreach(model.Member m in members)
            {
                if(m.FirstName.ToLower().Contains(search.ToLower()) || m.LastName.ToLower().Contains(search.ToLower()))
                {
                    searchList.Add(m);
                }
            }
            if (searchList.Count != 0)
            {
                System.Console.WriteLine($"This members with '{search}' in their name were found:\n");
                foreach(model.Member m in searchList)
                {
                    MemberToStringSmall(m);
                }                
            }
            else
            {
                System.Console.WriteLine($"No member with '{search}' in their name was found...\n");
            }
        }

        public bool SearchById(model.Member pickedMember, int searchNr, BoatView v)
        {
            if (pickedMember != null)
            {
                System.Console.WriteLine($"Members with the id: {searchNr} were found:\n");
                MemberToString(pickedMember, v);
                return true;
            }
            else
            {
                System.Console.WriteLine($"No member with {searchNr} as id was found...");
                return false;
            }
        }

        public void PrintVerboseList(IEnumerable<model.Member> members, BoatView v)
        {
            foreach(model.Member M in members)
            {
                MemberToString(M, v);
            }
        }

        public void PrintCompactList(IEnumerable<model.Member> members)
        {
            foreach(model.Member M in members)
            {
                MemberToStringSmall(M);
            }
        }

        public void MemberToString(model.Member m, BoatView v)
        {
             if (m.Boats.Count > 0)
            {
                string boats = String.Concat(m.Boats.Select(b => v.BoatToString(b)));
                System.Console.WriteLine("Id: {0}, Name: {1} {2}, Personal number: {3}, Boats: {4}", m.MemberId, m.FirstName, m.LastName, m.PersNum, boats);
            } else
            {
                string boats = "No boats added yet";
                System.Console.WriteLine("Id: {0}, Name: {1} {2}, Personal number: {3}, Boats: {4}", m.MemberId, m.FirstName, m.LastName, m.PersNum, boats);
            }
        }

        public void MemberToStringSmall(model.Member m)
        {
            int b = 0;
            if (m.Boats != null)
            {
                b = m.Boats.Count;
            }
            System.Console.WriteLine("Id: {0}, Name: {1} {2}, Boats: {3}", m.MemberId, m.FirstName, m.LastName, b);
        }
    }
}