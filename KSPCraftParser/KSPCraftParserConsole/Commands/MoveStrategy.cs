using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KSPCraftParserConsole.Decisions_2;

namespace KSPCraftParserConsole.Commands
{
    public class MoveStrategy : IMainStrategy
	{
		#region - Fields & Properties
		public static string CurrentDir { get; set; } = "";
		public static string[] Directories { get; set; }
		public SecondWord Second { get; set; }
		public List<string> Data { get; set; }
		#endregion

		#region - Constructors
		public MoveStrategy( SecondWord sec, List<string> data)
		{
			Second = sec;
			Data = data;
		}

		#endregion

		#region - Methods
		public void Execute( )
		{
			switch (Second)
			{
				case SecondWord.build:
					break;
				case SecondWord.dir:
					break;
				case SecondWord.file:
					break;
				case SecondWord.craft:
					break;
				case SecondWord.settings:
					break;
				case SecondWord.Null:
					break;
				default:
					break;
			}
		}

		#endregion

		#region - Full Properties

		#endregion
	}
}
