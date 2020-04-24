using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class PartModel
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string FileName { get; set; }
		public string Type { get; set; }
		public List<DataPoint> Data { get; set; }
		#endregion

		#region - Constructors
		public PartModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
