using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class ScienceModel
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public int DataSize { get; set; }
		public int BaseValue { get; set; }
		public int MaxValue { get; set; }
		public int TransmitEfficiency { get; set; }
		#endregion

		#region - Constructors
		public ScienceModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties
		public double TransmitEfficiencyDecimal
		{
			get
			{
				return TransmitEfficiency / 100;
			}
		}
		#endregion
	}
}
