using KSPCraftParserConsole.DataContainers;
using KSPCraftParserConsole.Decisions_2;
using PartDataReaderLibrary;
using PartDataReaderLibrary.CraftModels;
using PartDataReaderLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Commands
{
    public class CalcStrategy : IMainStrategy
	{
		#region - Fields & Properties
		public DirectoryData Dir { get; set; } = DirectoryData.Instance;
		public CraftData CraftData { get; set; } = CraftData.Instance;
		public SecondWord Second { get; set; }
		public List<string> Data { get; set; }

		public string CraftFilePath { get; set; }
		#endregion

		#region - Constructors
		public CalcStrategy( ) { }
		#endregion

		#region - Methods
		public void Execute( )
		{
			if (CraftData.PartData is null)
			{
				throw new CraftException("Part data is not loaded.", nameof(CraftData.PartData));
			}

			if (CraftData.ScienceData is null)
			{
				throw new CraftException("Science data not loaded.", nameof(CraftData.ScienceData));
			}

			CraftData.Calculate();
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
