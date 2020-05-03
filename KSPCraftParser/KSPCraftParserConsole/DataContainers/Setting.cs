using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.DataContainers
{
    public class Setting
	{
		#region - Fields & Properties
		public object Value { get; set; }
		public Type Type { get; private set; }
		#endregion

		#region - Constructors
		public Setting( object val, Type type )
		{
			Value = val;
			Type = type;
		}
		#endregion

		#region - Methods
		public override string ToString( )
		{
			return $"V: {Value} T: {Type.Name}";
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
