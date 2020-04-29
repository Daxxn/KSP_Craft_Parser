using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Decisions_2
{
    public static class Grammar
	{
		#region - Fields & Properties
		private static readonly string[] matches = new string[] { @"(?<word>\w+)" };
		#endregion

		#region - Methods
		public static void ReadGrammar( string input )
		{
			for (int i = 0; i < matches.Length; i++)
			{

			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
