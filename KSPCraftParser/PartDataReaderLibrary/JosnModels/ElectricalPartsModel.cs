using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.JosnModels
{
    public class ElectricalPartsModel : IJson
	{
		#region - Fields & Properties
		public List<ElectricalModel> pods { get; set; }
		public List<ElectricalModel> Engines { get; set; }
		public List<ElectricalModel> JetEngines { get; set; }
		public List<ElectricalModel> Controls { get; set; }
		public List<ElectricalModel> WheelMotors { get; set; }
		public List<ElectricalModel> Radiators { get; set; }
		public List<ElectricalModel> Generators { get; set; }
		public List<ElectricalModel> Batteries { get; set; }
		public List<ElectricalModel> Communication { get; set; }
		public List<ElectricalModel> Science { get; set; }
		public List<ElectricalModel> Scanners { get; set; }
		public List<ElectricalModel> Lights { get; set; }
		public List<ElectricalModel> Drills { get; set; }
		public List<ElectricalModel> Converters { get; set; }
		public List<ElectricalModel> Robotics { get; set; }
		#endregion

		#region - Constructors
		public ElectricalPartsModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
