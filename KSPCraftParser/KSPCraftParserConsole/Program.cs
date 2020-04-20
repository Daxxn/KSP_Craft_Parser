using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KSPCraftParserConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            bool exit = false;

            while (!exit)
            {
                string inputLine = GetConsoleInput();

            }
        }

        public static string GetConsoleInput(  )
        {
            string output = "";
            bool done = false;

            while (!done)
            {
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    done = true;
                    output = input;
                }
                else
                {
                    done = false;
                    output = "";
                }
            }

            return output;
        }
    }
}
