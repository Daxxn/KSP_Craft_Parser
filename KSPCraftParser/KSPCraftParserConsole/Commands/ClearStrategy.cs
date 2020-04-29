using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Commands
{
    public class ClearStrategy : IMainStrategy
	{
		#region - Fields & Properties

		#endregion

		#region - Constructors
		public ClearStrategy( ) { }

		#endregion

		#region - Methods
		public void Execute( )
		{
			Console.Clear();
		}

		#endregion

		#region - Full Properties

		#endregion
	}
}
