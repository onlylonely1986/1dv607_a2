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
            // TODO implement controller
            controller.RunProgram run = new controller.RunProgram();
            run.runProgram();

            // Application  a = new Application();
            // a.RunProgram();
        }
    }
}

