using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.PartModels
{
    public class AntennaModel
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string FileName { get; set; }
		public double ECperMit { get; set; }
		public double MitsperSec { get; set; }
		public int Range { get; set; }
		#endregion

		#region - Constructors
		public AntennaModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
