using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace View
{
    /**
    * Represents the menu.
    *    
     */
    class Menu
    {
        private string _inputVal1;

        private string _inputVal2;

        private string _inputVal3;

        public string InputVal1
        {
            get { return _inputVal1;}
            set {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                } else if (value == null)
                {
                    throw new ArgumentNullException();
                } 
                // TODO fel inputtype-exeption
                // göra snyggare felmeddelanden till användaren..
                _inputVal1 = value;
            }
        }

        public string InputVal2
        {
            get { return _inputVal2;}
        }

        public string InputVal3
        {
            get { return _inputVal3;}
        }

        public Menu ()
        {

           

            // Member member = new Member();
            // member.ToString();
                // memberRegister.RegistryMember("Ida", "Larsson", "600101-8000");
            // }
            
            // if ()
            //{

            //}
        }

        public void runMenu()
        {
            Console.WriteLine("Welcome to the boatclub register:");
            Console.WriteLine("Do you want to register a new member.");
            Console.WriteLine("Please enter your first name.");
            InputVal1 = Console.ReadLine();
            Console.WriteLine("Please enter your last name.");
            // LastName = Console.ReadLine();
            Console.WriteLine("Please enter your personalnumber with 10 numbers (XXXXXX-XXXX).");
            // PersonalNum = Console.ReadLine();
            Console.WriteLine("You have written this name and number, is it OK? Enter any button to submit.");
            Console.WriteLine(InputVal1);
        }
    }
}
