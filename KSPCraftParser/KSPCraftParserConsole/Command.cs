using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole
{
    public class Command
	{
		#region - Fields & Properties
		private static readonly char[] space = new char[] { ' ' };
		public Decisions.Verb Action { get; set; }
		public Decisions.Noun Object { get; set; }
		#endregion

		#region - Constructors
		public Command( ) { }
		#endregion

		#region - Methods
		public static Command ParseCommand( string userInput )
		{
			string[] splitOut = userInput.Split(space, StringSplitOptions.RemoveEmptyEntries);
			throw new NotImplementedException(nameof(ParseCommand));
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
