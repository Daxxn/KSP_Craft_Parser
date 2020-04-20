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
		// D:\Games\steamapps\common\Kerbal Space Program\saves-1_9 Science Ships\VAB-Apoloo 1-.craft
		public static string CreatePath( string gameFolder, string saveName, string building, string shipName )
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
				return fullPath;
			}
			else
			{
				throw new FileNotFoundException("Full file path doesnt match any files.");
			}
		}

		private static List<string> ReadFile( string path )
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
		#endregion

		#region - Full Properties

		#endregion
	}
}
