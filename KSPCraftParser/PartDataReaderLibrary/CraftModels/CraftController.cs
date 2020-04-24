using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
	public static class CraftController
	{
		#region - Fields & Properties

		#endregion

		#region - Methods
		public static Craft ParseCraftFile( string rawCraftData )
		{
			List<string> splitData = rawCraftData.Split(new string[] { "PART\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			List<string[]> partData = new List<string[]>();
			foreach (var part in splitData)
			{
				string[] lines = part.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
				string[] cleanedLines = new string[ lines.Length ];
				List<string> data = new List<string>();

				for (int i = 0; i < lines.Length; i++)
				{
					//bool hitEnd = false;
					cleanedLines[ i ] = lines[ i ].Trim(new char[] { '\t' });
					if (cleanedLines[ i ] != "{")
					{
						if (cleanedLines[ i ] == "EVENTS")
						{
							//hitEnd = true;
							break;
						}
						data.Add(cleanedLines[ i ]);
					}
				}
				partData.Add(data.ToArray());
			}

			return ParseCraft(partData);
		}

		public static Craft ParseCraft( List<string[]> allPartData )
		{
			Craft outputCraft = new Craft();
			List<Part> craftParts = new List<Part>();

			// Loops through the global ship data
			foreach (var data in allPartData[ 0 ])
			{
				string[] variable = data.Split(new string[] { " = " }, StringSplitOptions.None);
				if (variable[ 0 ] == "ship")
				{
					outputCraft.Name = variable[ 1 ];
				}
				else if (variable[ 0 ] == "description")
				{
					outputCraft.Description = variable[ 1 ];
				}
			}

			// Loops through the part data
			for (int i = 1; i < allPartData.Count; i++)
			{
				// Creates a new part and seperates the needed part data from the raw part data.
				Part newPart = new Part();
				for (int j = 0; j < allPartData[ i ].Length; j++)
				{
					// Splits eatch variable and stores the data in the new part. (Also parses the stage into an Int16)
					string[] variable = allPartData[ i ][ j ].Split(new string[] { " = " }, StringSplitOptions.None);
					if (variable[ 0 ] == "part")
					{
						newPart.FileName = variable[ 1 ].Split(new string[] { "_" }, StringSplitOptions.None)[ 0 ];
					}
					else if (variable[ 0 ] == "dstg")
					{
						newPart.Stage = Int16.Parse(variable[ 1 ]);
					}
				}
				outputCraft.AllParts.Add(newPart);
			}

			return outputCraft;
		}

		public static Craft SortParts( Craft craft, CraftModel allParts )
		{
			foreach (var part in craft.AllParts)
			{
				bool partFound = false;
				partFound = FindPart(craft.CommandPods, part, allParts.CommandPods, partFound);
				partFound = FindPart(craft.Tanks, part, allParts.Tanks, partFound);
				partFound = FindPart(craft.LiquidEngines, part, allParts.LiquidEngines, partFound);
				partFound = FindPart(craft.SolidEngines, part, allParts.SolidEngines, partFound);
				partFound = FindPart(craft.JetEngines, part, allParts.JetEngines, partFound);
				partFound = FindPart(craft.Controls, part, allParts.Controls, partFound);
				partFound = FindPart(craft.Structures, part, allParts.Structures, partFound);
				partFound = FindPart(craft.Robotics, part, allParts.Robotics, partFound);
				partFound = FindPart(craft.Couplers, part, allParts.Couplers, partFound);
				partFound = FindPart(craft.Payloads, part, allParts.Payloads, partFound);
				partFound = FindPart(craft.Aerodynamics, part, allParts.Aerodynamics, partFound);
				partFound = FindPart(craft.Ground, part, allParts.Ground, partFound);
				partFound = FindPart(craft.ThermalControls, part, allParts.ThermalControls, partFound);
				partFound = FindPart(craft.Generators, part, allParts.Generators, partFound);
				partFound = FindPart(craft.Batteries, part, allParts.Batteries, partFound);
				partFound = FindPart(craft.Antennas, part, allParts.Antennas, partFound);
				partFound = FindPart(craft.Science, part, allParts.Science, partFound);
				partFound = FindPart(craft.Scanners, part, allParts.Scanners, partFound);
				partFound = FindPart(craft.Utility, part, allParts.Utility, partFound);
				partFound = FindPart(craft.Harvesters, part, allParts.Harvesters, partFound);
				_ = FindPart(craft.Cargo, part, allParts.Cargo, partFound);
			}

			return craft;
		}

		public static bool FindPart( List<Part> newParts, Part part, List<PartModel> allParts, bool partFound )
		{
			if (!partFound)
			{
				foreach (var p in allParts)
				{
					if (part.FileName == p.FileName)
					{
						part.Data = p.Data;
						part.Name = p.Name;
						part.Type = p.Type;
						part.Parse();
						newParts.Add(part);
						return true;
					}
				}
				return false;
			}
			return partFound;
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
