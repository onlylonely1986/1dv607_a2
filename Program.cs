﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Register
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberRegister memberRegister = new MemberRegister();
            memberRegister.RegistryMember("Ida", "Larsson", "600101-8000");
            // Member member = new Member("Ida", "Larsson", "600101-8000");
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
