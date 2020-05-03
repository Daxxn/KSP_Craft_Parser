using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class CraftModel : IJson
	{
		#region - Fields & Properties
		public List<PartModel> CommandPods { get; set; }
		public List<PartModel> Tanks { get; set; }
		public List<PartModel> LiquidEngines { get; set; }
		public List<PartModel> SolidEngines { get; set; }
		public List<PartModel> JetEngines { get; set; }
		public List<PartModel> Controls { get; set; }
		public List<PartModel> Structures { get; set; }
		public List<PartModel> Robotics { get; set; }
		public List<PartModel> Couplers { get; set; }
		public List<PartModel> Payloads { get; set; }
		public List<PartModel> Aerodynamics { get; set; }
		public List<PartModel> Ground { get; set; }
		public List<PartModel> ThermalControls { get; set; }
		public List<PartModel> Generators { get; set; }
		public List<PartModel> Batteries { get; set; }
		public List<PartModel> Antennas { get; set; }
		public List<PartModel> Science { get; set; }
		public List<PartModel> Scanners { get; set; }
		public List<PartModel> Utility { get; set; }
		public List<PartModel> Harvesters { get; set; }
		public List<PartModel> Cargo { get; set; }
		#endregion

		#region - Constructors
		public CraftModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
