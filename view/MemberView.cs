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

        public Event ShowSearchMenu(Enum focus)
        {
            Console.WriteLine($"\n\n[1] Search for members by {focus.ToString().ToLower()}.");
            Console.WriteLine("[2] Go Back To Start Menu.\n");
            string s = Console.ReadLine();

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

        public string AskForSearchWord(Enum focus)
        {
            if (focus.ToString() == "Name")
            {
                Console.WriteLine("Write a name or a character in a name you want to find...\n");
            } 
            if (focus.ToString() == "Id")
            {
                Console.WriteLine("Write a nr of an id to find a member...\n");
            }
            return System.Console.ReadLine();
        }
        public string AskForMemberDetailName(Enum action)
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

        public bool SearchById(model.Member pickedMember, string searchNr, BoatView v)
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
             if (m.Boats != null)
            {
                string boats = String.Concat(m.Boats.Select(b => v.BoatToString(b)));
                System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Personal number: {m.PersNum}, Boats {m.Boats.Count}: {boats}");
            } else
            {
                string boats = "No boats added yet";
                System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Personal number: {m.PersNum}, Boats: {boats}");
            }
        }

        public void MemberToStringSmall(model.Member m)
        {
            int b = 0;
            if (m.Boats != null)
            {
                b = m.Boats.Count;
            }
            System.Console.WriteLine($"Id: {m.MemberId}, Name: {m.FirstName} {m.LastName}, Boats: {b}");
        }
    }
}