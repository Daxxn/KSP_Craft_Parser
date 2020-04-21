using KSPCraftParserConsole.FileControl;
using KSPCraftParserConsole.Properties;
using PartDataReaderLibrary.CraftModels;
using PartDataReaderLibrary.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary
{
    public static class CraftController
	{
		#region - Fields & Properties

		#endregion

		#region - Methods
		public static Craft ParseElectricalParts( string saveName, string building, string shipName )
		{
			string fullPath = FileController.CreatePath(PathSettings.Default.GamePath, saveName, building, shipName);
			string fileData = FileController.ReadJsonFile(fullPath);

			Craft allPartsCraft = ParseCraftFile(fileData);
			ElectricalPartsModel electricalParts = JsonController.OpenJsonFile<ElectricalPartsModel>("ElectricalData");

			return AddElectricalParts(allPartsCraft, electricalParts);
		}
		public static Craft AddElectricalParts( Craft craft, ElectricalPartsModel partsModel )
		{
			Craft neededCraft = new Craft();
			neededCraft.Name = craft.Name;
			neededCraft.Description = craft.Description;

			foreach (var part in craft.ElectricalParts)
			{
				if (part.Stage > neededCraft.StageCount)
				{
					neededCraft.StageCount = part.Stage;
				}
				foreach (var ePart in partsModel.ElectricalParts)
				{
					if (part.FileName == ePart.FileName)
					{
						part.Electrical.Load = ePart.Load;
						part.Electrical.LoadScale = (TimeDivision)Enum.Parse(typeof(TimeDivision), ePart.LoadScale);
						part.Electrical.RWLoad = ePart.RWLoad;
						part.Electrical.RWScale = (TimeDivision)Enum.Parse(typeof(TimeDivision), ePart.RWScale);
						part.Electrical.Production = ePart.Production;
						neededCraft.ElectricalParts.Add(part);
					}
				}
			}
			return neededCraft;
		}

		public static Craft AddAntennaParts( Craft craft, AntennaPartsModel antennas )
		{
			Craft neededCraft = new Craft();
			neededCraft.Name = craft.Name;
			neededCraft.Description = craft.Description;

			foreach (var part in craft.ElectricalParts)
			{
				if (part.Stage > neededCraft.StageCount)
				{
					neededCraft.StageCount = part.Stage;
				}
				foreach (var ePart in antennas.Antennas)
				{
					if (part.FileName == ePart.FileName)
					{
						part.Electrical.Load = ePart.Load;
						part.Electrical.LoadScale = (TimeDivision)Enum.Parse(typeof(TimeDivision), ePart.LoadScale);
						part.Electrical.RWLoad = ePart.RWLoad;
						part.Electrical.RWScale = (TimeDivision)Enum.Parse(typeof(TimeDivision), ePart.RWScale);
						part.Electrical.Production = ePart.Production;
						neededCraft.ElectricalParts.Add(part);
					}
				}
			}
			return neededCraft;
		}

		public static Craft ParseCraftFile( string rawCraftData )
		{
			List<string> splitData = rawCraftData.Split(new string[] { "PART\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			List<string[]> partData = new List<string[]>();
			foreach (var part in splitData)
			{
				string[] lines = part.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
				string[] cleanedLines = new string[lines.Length];
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

			// Loops through the global ship data
			foreach (var data in allPartData[0])
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
				for (int j = 0; j < allPartData[i].Length; j++)
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
				outputCraft.ElectricalParts.Add(newPart);
			}

			return outputCraft;
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
