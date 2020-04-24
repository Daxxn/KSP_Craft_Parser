using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class ScienceCalculator : CalculatorBase
	{
		#region - Fields & Properties
		public ScienceExperiments Science { get; set; }
		public double TotalBaseSciencePoints { get; set; }
		public double TotalMaxSciencePoints { get; set; }
		public double TotalData { get; set; }
		public int ExperimentCount { get; set; }
		public int LargestFile { get; set; }
		#endregion

		#region - Constructors
		public ScienceCalculator( Craft craft )
		{
			Craft = craft;
		}
		#endregion

		#region - Methods
		public override void Calculate( )
		{
			SumTotals();
		}

		private void SumTotals( )
		{
			ExperimentCount = Craft.Experiments.Count;
			foreach (var exper in Craft.Experiments)
			{
				TotalBaseSciencePoints += exper.BaseValue;
				TotalMaxSciencePoints += exper.MaxValue;
				TotalData += exper.DataSize;

				if (LargestFile < exper.DataSize)
				{
					LargestFile = exper.DataSize;
				}
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
