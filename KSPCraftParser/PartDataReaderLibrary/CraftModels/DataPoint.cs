using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.CraftModels
{
    public class DataPoint
	{
		#region - Fields & Properties
		public string Name { get; set; }
		public string Value { get; set; }
		public dynamic ParseValue { get; set; }
		public bool IsString { get; set; }
		#endregion

		#region - Constructors
		public DataPoint( ) { }
		#endregion

		#region - Methods
		public void Parse( int current = 0 )
		{
			bool success = false;
			double dOut = 0;
			int iOut = 0;
			bool bOut = false;

			if (current == 0)
			{
				success = Double.TryParse(Value, out dOut);
				if (success)
				{
					ParseValue = dOut;
				}
			}
			else if (current == 1)
			{
				success = Int32.TryParse(Value, out iOut);
				if (success)
				{
					ParseValue = iOut;
				}
			}
			else if (current == 2)
			{
				success = Boolean.TryParse(Value, out bOut);
				if (success)
				{
					ParseValue = bOut;
				}
			}
			else
			{
				ParseValue = Value;
				IsString = true;
				success = true;
			}

			if (!success)
			{
				current++;
				Parse(current);
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
