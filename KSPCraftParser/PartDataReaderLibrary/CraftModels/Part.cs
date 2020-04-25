using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class Part
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string FileName { get; set; }
		public string Type { get; set; }
		public int Stage { get; set; }
		public List<DataPoint> Data { get; set; }
		#endregion

		#region - Constructors
		public Part( ) { }
		#endregion

		#region - Methods
		public void Parse( )
		{
			foreach (var d in Data)
			{
				d.Parse();
			}
		}

		public dynamic GetValue( string name )
		{
			if (Data.Count > 1)
			{
				dynamic output = 0;
				bool foundName = false;

				foreach (var datum in Data)
				{
					if (datum.Name == name)
					{
						output = datum.ParseValue;
						foundName = true;
						break;
					}
				}
				if (foundName)
				{
					return output;
				}
				else
				{
					throw new Exception("Data value not found.");
				}
			}
			else
			{
				return Data[ 0 ].ParseValue;
			}
		}

		public dynamic SearchValue( string name )
		{
			if (Data.Count > 1)
			{
				dynamic output = 0;
				bool foundName = false;

				foreach (var datum in Data)
				{
					if (datum.Name == name)
					{
						output = datum.ParseValue;
						foundName = true;
						break;
					}
				}
				if (foundName)
				{
					return output;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				return Data[ 0 ].ParseValue;
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
