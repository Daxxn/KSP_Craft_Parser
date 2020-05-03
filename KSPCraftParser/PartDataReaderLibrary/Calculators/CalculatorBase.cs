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
		public static double LowestAntennaLoad { get; set; } = Double.MaxValue;
		public static double HighestAntennaPowerRequired { get; set; }
		public static double TotalAntennaPowerRequired { get; set; }
		public static int LargestFile { get; set; }
		public static int TotalData { get; set; }
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
