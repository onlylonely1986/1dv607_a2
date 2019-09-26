using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace view
{
    /**
    * Represents the console view.
    *  
    */
    public class ConsoleView
    {
        // Menu _menu = new Menu();

        // bool _inProgram = true;
        
        public void showConsole()
        {
            // while(_inProgram)
            // {
            menu();
            // }
        }

        private void menu()
        {
            string _inputVal1;
            Console.WriteLine("Welcome to the boatclub register:");
            System.Console.WriteLine("  ");
            Console.WriteLine("Enter n to add a new member, enter s to search for members, enter q to quit.");
            Console.WriteLine("Do you want to register a new member.");
            System.Console.WriteLine("  ");
            Console.WriteLine("Please enter your first name.");
            _inputVal1 = Console.ReadLine();
        }
    }
}
