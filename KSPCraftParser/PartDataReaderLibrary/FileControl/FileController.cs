using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KSPCraftParserConsole.FileControl
{
    public static class FileController
	{
		#region - Fields & Properties
		public static string CraftExt { get; } = "craft";
		#endregion

		#region - Methods
		// (                                             Main Folder                                             )(      Save      )( Building )(   Ship    )( Ext )
		// D:\Games\steamapps\common\Kerbal Space Program\saves-1_9 Science Ships\VAB-Apolooo 1-.craft
		// D:\Games\steamapps\common\Kerbal Space Program\saves\1_9 Science\Ships\VAB\Apoloo 1.craft
		public static string ReadCraftFile( string gameFolder, string saveName, string building, string shipName )
		{
			string buildingPath;

			if (building.ToLower() == "vab")
			{
				buildingPath = @"Ships\VAB";
			}
			else if (building.ToLower() == "sph")
			{
				buildingPath = @"Ships\SPH";
			}
			else
			{
				throw new Exception("Building must be the SPH or VAB.");
			}

			string fullPath = Path.Combine(gameFolder, saveName, buildingPath, Path.ChangeExtension(shipName, CraftExt));

			if (File.Exists(fullPath))
			{
				return ReadFileToEnd(fullPath);
			}
			else
			{
				throw new FileNotFoundException("Full file path doesnt match any files.");
			}
		}

		public static string ReadCraftFile( string filePath )
		{
			if (File.Exists(filePath))
			{
				return ReadFileToEnd(filePath);
			}
			else
			{
				throw new FileNotFoundException("Full file path doesnt match any files.");
			}
		}

		public static List<string> ReadFileLines( string path )
		{
			List<string> rawCraftData = new List<string>();

			using (StreamReader reader = new StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					rawCraftData.Add(reader.ReadLine());
				}
			}

			return rawCraftData;
		}

		public static string ReadFileToEnd( string path )
		{
			if (File.Exists(path))
			{
				using (StreamReader reader = new StreamReader(path))
				{
					return reader.ReadToEnd();
				}
			}
			else
			{
				throw new FileNotFoundException("Full file path doesnt match any files.");
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
