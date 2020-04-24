using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class ElectricalCalculator : CalculatorBase
	{
		#region - Fields & Properties
		public double TotalLoad { get; set; }
		public double TotalRWLoad { get; set; }
		public double TotalProduction { get; set; }
		public double TotalBattery { get; set; }
		#endregion

		#region - Constructors
		public ElectricalCalculator( Craft craft )
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
			// Need to add all the new part lists
			SumList(Craft.CommandPods);
			SumList(Craft.LiquidEngines);
			SumList(Craft.SolidEngines);
			SumList(Craft.JetEngines);
			SumList(Craft.Controls);
			SumList(Craft.Robotics);
			SumList(Craft.Ground);
			SumList(Craft.ThermalControls);
			SumList(Craft.Generators);
			SumList(Craft.Batteries);
			SumList(Craft.Science);
			SumList(Craft.Scanners);
			SumList(Craft.Utility);
			SumList(Craft.Harvesters);
		}

		private void SumList( List<Part> parts )
		{
			foreach (var part in parts)
			{
				string loadScale = "";
				double loadValue = 0;
				string RWScale = "";
				double RWValue = 0;
				foreach (var datum in part.Data)
				{
					if (!datum.IsString)
					{
						if (datum.Name == "Load")
						{
							loadValue += datum.ParseValue;
						}


						if (datum.Name == "RWLoad")
						{
							RWValue = datum.ParseValue;
						}


						if (datum.Name == "Battery")
						{
							TotalBattery += datum.ParseValue;
						}

						if (datum.Name == "ECProduced")
						{
							TotalProduction += datum.ParseValue;
						}
					}
					else
					{
						if (datum.Name == "LoadScale")
						{
							loadScale = datum.ParseValue;
						}

						if (datum.Name == "RWScale")
						{
							RWScale = datum.ParseValue;
						}
					}
				}
				TotalLoad += ConvertSeconds(loadScale, loadValue);
				TotalRWLoad += ConvertSeconds(RWScale, RWValue);
			}
		}

		private double ConvertSeconds( string scale, dynamic value )
		{
			if (scale == "min")
			{
				return value / 60;
			}
			else if (scale == "hr")
			{
				return value / (60 * 60);
			}
			else
			{
				return value;
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
