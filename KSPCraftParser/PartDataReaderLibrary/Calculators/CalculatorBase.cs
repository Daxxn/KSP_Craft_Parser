using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class CalculatorBase
	{
		#region - Fields & Properties
		public delegate void PrintResult( string output );
		public Craft Craft { get; set; }

		#region Shared Values
		public double LowestAntennaLoad { get; set; } = Double.MaxValue;
		public double HighestAntennaPowerRequired { get; set; }
		public double TotalAntennaPowerRequired { get; set; }
		public int LargestFile { get; set; }
		public int TotalData { get; set; }
		#endregion
		#endregion

		#region - Constructors
		public CalculatorBase( ) { }
		#endregion

		#region - Methods
		public virtual void Calculate( ) { }

		public virtual string PrintData()
		{
			return $"Lowest Antenna : {LowestAntennaLoad}\nMin Antenna Power Required : {HighestAntennaPowerRequired}\nMax Antenna Power Required : {TotalAntennaPowerRequired}";
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
