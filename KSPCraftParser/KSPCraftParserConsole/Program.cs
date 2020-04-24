using PartDataReaderLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PartDataReaderLibrary.CraftModels;
using KSPCraftParserConsole.FileControl;
using PartDataReaderLibrary.Calculators;

namespace KSPCraftParserConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            #region Testing Region
            string jsonPartPath = @"D:\Games\KSP\Notes\PartData\KSP_Parts_Mk3.json";
            string craftPath = @"D:\Games\steamapps\common\Kerbal Space Program\saves\Ship Testing\Ships\VAB\TestCraft2.craft";
            string jsonSciencePath = @"D:\Games\KSP\Notes\PartData\KSP_Science_Experiments_Mk1.json";

            Craft testCraft = new Craft();

            CraftModel allParts = JsonController.OpenJsonFile<CraftModel>("KSP_Parts_Mk3");
            ScienceExperiments allScience = JsonController.OpenJsonFile<ScienceExperiments>("KSP_Science_Experiments_Mk1");

            testCraft = CraftController.ParseCraftFile(FileController.ReadCraftFile(craftPath));
            testCraft = CraftController.SortParts(testCraft, allParts);

            allScience.SortExperiments(testCraft);
            CalcManager calculator = new CalcManager(testCraft);
            calculator.Calculate();
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

        public static string GetConsoleInput( )
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
