using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class Craft
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string Description { get; set; }
		public int StageCount { get; set; }
		public List<Part> ElectricalParts { get; set; }
		#endregion

		#region - Constructors
		public Craft( )
		{
			ElectricalParts = new List<Part>();
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
