using PartDataReaderLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PartDataReaderLibrary.JsonModels;
using KSPCraftParserConsole.FileControl;
using KSPCraftParserConsole.Properties;

namespace KSPCraftParserConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            #region Testing Region
            CraftController.ParseElectricalParts("1_9 Science", "vab", "Parser Test 1");
            #endregion

            #region Completed Region
            bool exit = false;

            while (!exit)
            {
                string inputLine = GetConsoleInput();
                Command decision = Command.ParseCommand(inputLine);
            }
            #endregion
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
