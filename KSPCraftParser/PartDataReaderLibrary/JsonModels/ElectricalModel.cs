using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.JsonModels
{
    public class ElectricalModel
	{
		#region - Fields & Properties
		public string name { get; set; }
		public string FileName { get; set; }
		public double Load { get; set; }
		public string LoadScale { get; set; }
		public double RWLoad { get; set; }
		public string RWScale { get; set; }
		public double Production { get; set; }
		public int Battery { get; set; }
		#endregion

		#region - Constructors
		public ElectricalModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
