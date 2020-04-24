using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class CommunicationCalculator : CalculatorBase
	{
		#region - Fields & Properties
		private Dictionary<int, double> KSCPowerLevels { get; set; } = new Dictionary<int, double> { { 1, 2000000000 }, { 2, 50000000000 }, { 3, 250000000000 } };
		public int KSCTrackingStationLevel { get; set; } = 3;
		public double CombinabilityExponent { get; set; } = 1;
		public double SignalStrength { get; set; }
		public double MaximumRange { get; set; }
		public double CraftPower { get; set; }
		public double CraftPowerSum { get; set; }
		public double StrongestAntenna { get; set; } = 5000;
		#endregion

		#region - Constructors
		public CommunicationCalculator( Craft craft )
		{
			Craft = craft;
		}
		#endregion

		#region - Methods
		public override void Calculate( )
		{
			CalcAntennas();
			CalcCraftPower();
			CalcMaxRange();
		}

		private void CalcAntennas( )
		{
			if (Craft.Antennas.Count != 0)
			{
				#region V-1
				//if (Craft.Antennas.Count > 1)
				//{
				//	List<double> combExponents = new List<double>();
				//	List<double> powers = new List<double>()
				//	{
				//		KSCPowerLevels[KSCTrackingStationLevel],
				//		5000
				//	};

				//	foreach (var antenna in Craft.Antennas)
				//	{
				//		double antRange = antenna.GetValue("Range");
				//		if (StrongestAntenna < antRange)
				//		{
				//			StrongestAntenna = antRange;
				//		}
				//		combExponents.Add(antenna.GetValue("CombineExp"));
				//		powers.Add(antRange);
				//	}
				//	CraftPowerSum = powers.Sum();
				//	CalcCombineExp(combExponents.ToArray(), powers.ToArray());
				//}
				//else
				//{

				//	CombinabilityExponent = Craft.Antennas[ 0 ].GetValue("CombineExp");
				//}
				#endregion

				#region V-2
				if (Craft.Antennas.Count > 1)
				{
					CalcCombinedAntenna();
				}
				else
				{
					StrongestAntenna = Craft.Antennas[ 0 ].GetValue("Range");
					CraftPowerSum = StrongestAntenna;
				}
				#endregion
			}
			else
			{
				StrongestAntenna = 5000;
				CraftPowerSum = 5000;
				//CraftPower = 5000;
			}
		}

		private void CalcCombinedAntenna( )
		{
			List<double> powers = new List<double>();
			List<double> combExp = new List<double>();

			foreach (var antenna in Craft.Antennas)
			{
				double antPower = antenna.GetValue("Range");

				if (antPower > StrongestAntenna)
				{
					StrongestAntenna = antPower;
				}

				powers.Add(antPower);
				combExp.Add(antenna.GetValue("CombineExp"));

			}
			CalcCombineExp(combExp.ToArray(), powers.ToArray());
			CraftPowerSum = powers.Sum();
		}

		private void CalcCombineExp( double[] combExps, double[] powers )
		{
			double top = 0;
			double bot = 0;
			for (int i = 0; i < combExps.Length; i++)
			{
				top += combExps[ i ] * powers[ i ];
				bot += powers[ i ];
			}

			if (bot != 0)
			{
				CombinabilityExponent = top / bot;
			}
			else
			{
				CombinabilityExponent = 0;
			}
		}

		private void CalcCraftPower( )
		{
			CraftPower = StrongestAntenna * (CraftPowerSum / StrongestAntenna) * CombinabilityExponent;
		}

		private void CalcMaxRange( )
		{
			MaximumRange = Math.Sqrt(KSCPowerLevels[ KSCTrackingStationLevel ] * CraftPower);
		}


		#endregion

		#region - Full Properties

		#endregion
	}
}
