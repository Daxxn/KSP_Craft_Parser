using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class ElectricalData
	{
		#region - Fields & Properties
		public double Load { get; set; } = 0;
		public TimeDivision LoadScale { get; set; } = TimeDivision.sec;
		public double RWLoad { get; set; } = 0;
		public TimeDivision RWScale { get; set; } = TimeDivision.sec;
		public double Production { get; set; } = 0;
		public int Battery { get; set; } = 0;
		#endregion

		#region - Constructors
		public ElectricalData( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
