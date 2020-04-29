﻿using PartDataReaderLibrary;

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
            int startIndex = 1;
            #region Testing Region
            if (startIndex == 0)
            {
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
                calculator.PrintData();
            }
            #endregion

            #region Completed Region
            else if (startIndex == 1)
            {
                bool exit = false;

                while (!exit)
                {
                    string inputLine = GetConsoleInput();
                    Command decision;
                    try
                    {
                        decision = Command.ParseCommand(inputLine);
                        decision.Strategy.Execute();
                    }
                    catch (CommandException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.BadInput);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
            #endregion
        }

        public static string GetConsoleInput( )
        {
            string output = "";
            bool done = false;

            while (!done)
            {
                Console.Write(">");
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
