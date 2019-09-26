using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace register
{
    class Program
    {
        static void Main(string[] args)
        {
            model.MemberRegister memberRegister = new model.MemberRegister();
            // memberRegister.CreateNewRegister();
            view.ConsoleView view = new view.ConsoleView();

            controller.User user = new controller.User();
            user.runProgram(view);
            // Console.WriteLine(member.ToString());
            // string filePath = @"C:\SaveData\members.txt";
            // Console.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");
            // List<string> lines = File.ReadAllLines(filePath).ToList();

            // foreach(string line in lines)
            // {
            //     Console.WriteLine(line);
            // }
            // DateTime dateTimeNow = DateTime.Now;
            
            // lines.Add($"Sven, Olsson, 691202, {dateTimeNow}");
            // File.WriteAllLines(filePath, lines);


            // Console.ReadLine();
        }
    }
}
