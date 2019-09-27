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
        
        private List<string> _inputs = new List<string>();
        public void showConsole()
        {
            int choice;
            // do
            // {
            Console.WriteLine("Welcome to the boatclub register:");
            System.Console.WriteLine("  ");
            Console.WriteLine("1. Add a new member.");
            Console.WriteLine("2. Add a new boat.");
            Console.WriteLine("3. Search for members.");
            Console.WriteLine("4. Quit application.");

            choice = Convert.ToInt32(Console.ReadLine());

            userMakesChoice(choice);
                // return ret;

            // } while (choice != 4);
        }

        public bool WantsToContinueProgram()
        {
            return System.Console.ReadLine() != "4";
        }
        private void userMakesChoice(int choice)
        {   
            string input1 = "";
            string input2 = "";
            string input3 = "";
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Do you want to register a new member.");
                    System.Console.WriteLine("  ");
                    Console.WriteLine("Please enter your first name.");
                    input1 = Console.ReadLine();
                    do 
                    {
                        Console.WriteLine("Your name must be longer than one character, try to enter your first name again.");
                        input1 = Console.ReadLine();

                    } while (input1.Length > 2);

                    _inputs.Add(input1);
                    
                    Console.WriteLine("Please enter your last name.");
                    input2 = Console.ReadLine();
                    _inputs.Add(input2);
                    Console.WriteLine("Please enter your personal number.");
                    input3 = Console.ReadLine();
                    _inputs.Add(input3);
                    for (int i = 0; i < _inputs.Count; i ++)
                    {
                        System.Console.WriteLine(_inputs[i]);
                    }
                    // return input;
                    break;
                case 2:
                    // return input;
                    break;
                case 3:
                    // return input;
                    break;
                case 4:
                    // return input;
                    break;
                default:
                    break;
            }
            // Console.Clear();
        }

    }
}
