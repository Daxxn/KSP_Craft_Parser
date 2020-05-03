using KSPCraftParserConsole.FileControl;
using PartDataReaderLibrary;
using PartDataReaderLibrary.Calculators;
using PartDataReaderLibrary.CraftModels;
using PartDataReaderLibrary.Exceptions;
using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.DataContainers
{
    public class CraftData
	{
		#region - Fields & Properties
		private static CraftData _instance;
		public string CraftPath { get; set; }
		public string PartsPath { get; set; }
		public string SciencePath { get; set; }

		public Craft Craft { get; set; }
		public CraftModel PartData { get; set; }
		public ScienceExperiments ScienceData { get; set; }

		public CalcManager Calculator { get; set; }
		#endregion

		#region - Constructors
		private CraftData( ) { }
		#endregion

		#region - Methods
		public static void OnStartup( )
		{
			Instance.PartsPath = Properties.Settings.Default.PartDataFile;
			Instance.SciencePath = Properties.Settings.Default.ScienceDataFile;
			Instance.OpenDataFiles();
		}
		public bool CheckFile( string file, string ext )
		{
			if (Path.GetExtension(file) == ext)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void OpenCraftFile( )
		{
			try
			{
				Craft = CraftController.ParseCraftFile(FileController.ReadCraftFile(CraftPath));
				Craft = CraftController.SortParts(Craft, PartData);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void Calculate( )
		{
			ScienceData.SortExperiments(Craft);
			Calculator = new CalcManager(Craft);

			Calculator.Calculate();
		}

		public void Print( )
		{
			string dataString = Calculator.PrintData();
		}

		public void OpenDataFiles( )
		{
			PartData = OpenDataFile<CraftModel>(PartsPath);
			ScienceData = OpenDataFile<ScienceExperiments>(SciencePath);
		}

		public void OpenDataFiles( bool openParts )
		{
			if (openParts)
			{
				PartData = OpenDataFile<CraftModel>(PartsPath);
			}
			else
			{
				ScienceData = OpenDataFile<ScienceExperiments>(SciencePath); 
			}
		}

		public TModel OpenDataFile<TModel>( string path ) where TModel : IJson
		{
			try
			{
				return JsonController.OpenJsonFile<TModel>(path);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		#endregion

		#region - Full Properties
		public static CraftData Instance
		{
			get
			{
				if (_instance is null)
				{
					_instance = new CraftData();
				}
				return _instance;
			}
		}
		#endregion
	}
}
