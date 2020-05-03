using KSPCraftParserConsole.DataContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Commands
{
    public class SetStrategy : IMainStrategy
	{
		#region - Fields & Properties
		public static SettingsData_2 Settings { get; set; } = SettingsData_2.Instance;
		public List<string> Data { get; set; }
		#endregion

		#region - Constructors
		public SetStrategy( List<string> data )
		{
			Data = data;
		}
		#endregion

		#region - Methods
		public void Execute( )
		{
			if (Data.Count == 3)
			{
				if (Data[1] == "to")
				{
					//PrintStatus(Settings.ChangeSetting(Data[ 0 ], Data[ 2 ]));
					//PrintStatus(Settings.ChangeSetting_2(Data[ 0 ], Data[ 2 ]));
					//PrintStatus(Settings.ChangeSetting(Data[ 0 ], Data[ 2 ]));
					PrintStatus(Settings.ReadSetting(Data[ 0 ], Data[ 2 ]));
				}
				else
				{
					throw new CommandException("Set command is ambiguous.", $"{Data[ 0 ]} {Data[ 1 ]} {Data[ 2 ]}");
				}
			}
			else if (Data.Count == 2)
			{
				//PrintStatus(Settings.ChangeSetting(Data[ 0 ], Data[ 1 ]));
				//PrintStatus(Settings.ChangeSetting_2(Data[ 0 ], Data[ 1 ]));
				//PrintStatus(Settings.ChangeSetting(Data[ 0 ], Data[ 1 ]));
			}
		}

		private void PrintStatus( bool success )
		{
			if (success)
			{
				Console.WriteLine("Setting change completed.");
			}
			else
			{
				Console.WriteLine("Unable to find setting.");
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
