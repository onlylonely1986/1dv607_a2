using System;
using System.Collections.Generic;
using System.Linq;

namespace view
{

    /**
    * Represents the validation class activities.
    *  
    */
    public class ValidationView
    {
        public int ValidateMenuInput(int maxVal)
        {
            string inputStr = Console.ReadLine();
            int i;
            while (!int.TryParse(inputStr, out i) || !(i > 0 && i < maxVal))
            {
                System.Console.WriteLine("Try again :)");
                inputStr = Console.ReadLine();
            }
            return Convert.ToInt32(inputStr);
        }

        public string ValidateStringInput()
        {
            string input =  Console.ReadLine();
            List<string> invalidChars = new List<string>() { "!", "?", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };
            while(input.Any(char.IsDigit) || (input.Length < 2 && input.Length > 20))
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

        public int ValidateStringInputAsInt()
        {
            string input = System.Console.ReadLine();
            int inputInt;
            while(!int.TryParse(input, out inputInt) || (input.Length != 1))
            {
                System.Console.WriteLine("Please try again...");
                input = System.Console.ReadLine();
            }
            return inputInt;
        }
    }
}