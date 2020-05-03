using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.DataContainers
{
    public class SettingsData_2 : SettingsBase
	{
		#region - Fields & Properties
		private static SettingsData_2 _instance;
		public Setting MyProperty { get; set; }
		#endregion

		#region - Constructors
		private SettingsData_2( )
		{
		}
		#endregion

		#region - Methods
		public static void OnStartup( )
		{
			//_instance = (SettingsData_2)KSPCraftParserConsole.Properties.Settings.Synchronized(Instance);
		}
		public bool ReadSetting( string name, object value )
		{
			try
			{
				var setting = this[ name ];
				setting = value;
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
		#endregion

		#region - Full Properties
		public static SettingsData_2 Instance
		{
			get 
			{
				if (_instance is null)
				{
					_instance = new SettingsData_2();
				}
				return _instance; 
			}
		}
		#endregion
	}
}
