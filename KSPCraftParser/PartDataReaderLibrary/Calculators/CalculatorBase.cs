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
		public Craft Craft { get; set; }
		#endregion

		#region - Constructors
		public CalculatorBase( ) { }
		#endregion

		#region - Methods
		public virtual void Calculate( ) { }

		protected dynamic GetValue( List<DataPoint> data, string name )
		{
			if (data.Count > 1)
			{
				dynamic output = 0;
				bool foundName = false;
				foreach (var datum in data)
				{
					if (datum.Name == name)
					{
						output = datum.ParseValue;
					}
				}
				if (foundName)
				{
					return output;
				}
				else
				{
					throw new Exception("No data found with that name.");
				}
			}
			else
			{
				return data[ 0 ].ParseValue;
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
