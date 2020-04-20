using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.PartModels
{
    public class AntennaPartsModel : IJson
	{
		#region - Fields & Properties
		public List<AntennaModel> Antennas { get; set; }
		#endregion

		#region - Constructors
		public AntennaPartsModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
