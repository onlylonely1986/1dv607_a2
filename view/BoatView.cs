using System;

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
            return $"[ Boattype: {b.Type},  Length: {b.LengthInFeet} feet. ]";
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

        public int AskForBoatType(string types)
        {
            Console.WriteLine("\nPick your boattype, it must be one of these (pick by number):");
            System.Console.WriteLine(types);
            string typeStr = System.Console.ReadLine();
            int typeInt;
            while (!int.TryParse(typeStr, out typeInt) || !(typeInt <= 4 && typeInt >= 1))
            {
                System.Console.WriteLine("Please enter a nr of a type");
                typeStr = System.Console.ReadLine();
            }            
            typeInt = Int32.Parse(typeStr);
            return typeInt;
        }

        public int AskForBoatLength()
        {
            Console.WriteLine("\nPlease enter your boat length in feet:");
            string lengthStr = System.Console.ReadLine();
            int length;
            while (!int.TryParse(lengthStr, out length) || !(length > 2 && length < 100))
            {
                Console.WriteLine("You have to a enter reasonable length on your boat.");
                lengthStr = Console.ReadLine();
            }
            length = Int32.Parse(lengthStr);
            return length;
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
                    System.Console.WriteLine("Please write a boat nr... Write 0 to go back to main menu.");
                    boatNrAsStr = System.Console.ReadLine();
                }

                boatNr = Int32.Parse(boatNrAsStr);
                return boatNr;
            }
        }
    }
}
