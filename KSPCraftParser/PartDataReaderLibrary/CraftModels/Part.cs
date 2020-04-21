using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class Part
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string FileName { get; set; }
		public int Stage { get; set; }
		public ElectricalData Electrical { get; set; }
		#endregion

		#region - Constructors
		public Part( )
		{
			Electrical = new ElectricalData();
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
