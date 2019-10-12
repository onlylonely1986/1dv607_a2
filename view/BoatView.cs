using System;
using System.Collections.Generic;
using System.Linq;

namespace view
{

    /**
    * Represents the boat view activities.
    *  
    */
    public class BoatView
    {
        public void PrintBoatInfo(model.Member member)
        {
            int ind = 1;
            foreach(model.Boat boat in member.Boats)
            {
                System.Console.WriteLine($"[{ind++}]: Boattype: {boat.Type} Length: {boat.LengthInFeet} feet");
            }
        }


        public string BoatToString(model.Boat b)
        {
            return $"[ Boattype: {b.Type}, Length: {b.LengthInFeet} feet. ]";
        }   

        public string GetBoatTypesListed()
        {
            int i = 0;
            string ret = "";
            foreach(model.BoatType t in Enum.GetValues(typeof(model.BoatType)))
            {
                i++;
                ret += $"[{i}] {t}\n";
            }
            return ret;
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

        public void AskForBoatToPickText(Enum handle)
        {
            System.Console.WriteLine($"Pick the boat to {handle.ToString().ToLower()}:");
        }

        public int PickBoatToHandle(model.Member pickedMember)
        {
            string boatNrAsStr = System.Console.ReadLine();
            int boatNr = 0;
            if (pickedMember.Boats.Count < 1)
            {
                System.Console.WriteLine("Sorry you have not added any boats yet.");
                return boatNr;
            }
            else
            {
                while (!int.TryParse(boatNrAsStr, out boatNr) || !(boatNr <= pickedMember.Boats.Count))
                {
                    System.Console.WriteLine("Please write a boat nr...");
                    boatNrAsStr = System.Console.ReadLine();
                }
                // TODO kollar ej för långa ints
                // kollar ej för att ange en 0
                boatNr = Int32.Parse(boatNrAsStr);
                return boatNr;
            }
        }
    }
}