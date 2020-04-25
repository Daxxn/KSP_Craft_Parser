using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class ThrustCalculator : CalculatorBase
	{
		#region - Fields & Properties
		public double TotalDryMass { get; set; }
		public double TotalWetMass { get; set; }
		public double TotalThrust { get; set; }
		public double TotalISP { get; set; }
		#endregion

		#region - Constructors
		public ThrustCalculator( Craft craft )
		{
			Craft = craft;
		}
		#endregion

		#region - Methods
		public override void Calculate( )
		{
			SumMasses();
		}

		public override string PrintData( )
		{
			StringBuilder builder = new StringBuilder("Thrust Data :");
			builder.AppendLine($"Dry Mass : {TotalDryMass}");
			builder.AppendLine($"Wet Mass : {TotalWetMass}");
			builder.AppendLine($"Total Thrust : {TotalThrust}");
			builder.AppendLine($"Total ISP : {TotalISP}");
			return builder.ToString();
		}

		private void SumMasses( )
		{
			LoopParts(Craft.CommandPods, "DryMass");
			LoopParts(Craft.Tanks, "DryMass");
			LoopParts(Craft.LiquidEngines, "DryMass");
			LoopParts(Craft.SolidEngines, "DryMass");
			LoopParts(Craft.JetEngines, "DryMass");
			LoopParts(Craft.Controls, "DryMass");
			LoopParts(Craft.Structures, "DryMass");
			LoopParts(Craft.Robotics, "DryMass");
			LoopParts(Craft.Couplers, "DryMass");
			LoopParts(Craft.Payloads, "DryMass");
			LoopParts(Craft.Aerodynamics, "DryMass");
			LoopParts(Craft.Ground, "DryMass");
			LoopParts(Craft.ThermalControls, "DryMass");
			LoopParts(Craft.Generators, "DryMass");
			LoopParts(Craft.Batteries, "DryMass");
			LoopParts(Craft.Antennas, "DryMass");
			LoopParts(Craft.Science, "DryMass");
			LoopParts(Craft.Scanners, "DryMass");
			LoopParts(Craft.Utility, "DryMass");
			LoopParts(Craft.Harvesters, "DryMass");
			LoopParts(Craft.Cargo, "DryMass");


			LoopParts(Craft.CommandPods, "WetMass");
			LoopParts(Craft.Tanks, "WetMass");
			LoopParts(Craft.LiquidEngines, "WetMass");
			LoopParts(Craft.SolidEngines, "WetMass");
			LoopParts(Craft.JetEngines, "WetMass");
			LoopParts(Craft.Controls, "WetMass");
			LoopParts(Craft.Structures, "WetMass");
			LoopParts(Craft.Robotics, "WetMass");
			LoopParts(Craft.Couplers, "WetMass");
			LoopParts(Craft.Payloads, "WetMass");
			LoopParts(Craft.Aerodynamics, "WetMass");
			LoopParts(Craft.Ground, "WetMass");
			LoopParts(Craft.ThermalControls, "WetMass");
			LoopParts(Craft.Generators, "WetMass");
			LoopParts(Craft.Batteries, "WetMass");
			LoopParts(Craft.Antennas, "WetMass");
			LoopParts(Craft.Science, "WetMass");
			LoopParts(Craft.Scanners, "WetMass");
			LoopParts(Craft.Utility, "WetMass");
			LoopParts(Craft.Harvesters, "WetMass");
			LoopParts(Craft.Cargo, "WetMass");
		}

		private void LoopParts( List<Part> partList, string name )
		{
			foreach (var part in partList)
			{
				TotalDryMass += part.SearchValue(name);
			}
		}
		#endregion

		#region - Full Properties
		public double TotalFuelMass
		{
			get
			{
				return TotalWetMass - TotalDryMass;
			}
		}
		#endregion
	}
}
