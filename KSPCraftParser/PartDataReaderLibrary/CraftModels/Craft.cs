using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
	public class Craft
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string Description { get; set; }
		public int StageCount { get; set; }
		public List<Part> AllParts { get; set; } = new List<Part>();
		public List<Part> CommandPods { get; set; } = new List<Part>();
		public List<Part> Tanks { get; set; } = new List<Part>();
		public List<Part> LiquidEngines { get; set; } = new List<Part>();
		public List<Part> SolidEngines { get; set; } = new List<Part>();
		public List<Part> JetEngines { get; set; } = new List<Part>();
		public List<Part> Controls { get; set; } = new List<Part>();
		public List<Part> Structures { get; set; } = new List<Part>();
		public List<Part> Robotics { get; set; } = new List<Part>();
		public List<Part> Couplers { get; set; } = new List<Part>();
		public List<Part> Payloads { get; set; } = new List<Part>();
		public List<Part> Aerodynamics { get; set; } = new List<Part>();
		public List<Part> Ground { get; set; } = new List<Part>();
		public List<Part> ThermalControls { get; set; } = new List<Part>();
		public List<Part> Generators { get; set; } = new List<Part>();
		public List<Part> Batteries { get; set; } = new List<Part>();
		public List<Part> Antennas { get; set; } = new List<Part>();
		public List<Part> Science { get; set; } = new List<Part>();
		public List<Part> Scanners { get; set; } = new List<Part>();
		public List<Part> Utility { get; set; } = new List<Part>();
		public List<Part> Harvesters { get; set; } = new List<Part>();
		public List<Part> Cargo { get; set; } = new List<Part>();

		public List<ScienceModel> Experiments { get; set; } = new List<ScienceModel>();
		#endregion

		#region - Constructors
		public Craft( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
