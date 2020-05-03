using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.DataContainers
{
    public class SettingsData
	{
		#region - Fields & Properties
		private static SettingsData _instance;

		//public Dictionary<string, object> AllSettings { get; set; }
		public Dictionary<string, Setting> AllSettings { get; set; }
		//public List<Setting> NewSettings { get; set; }
		//public string Data { get; set; }
		#endregion

		#region - Constructors
		private SettingsData( ) { }
		#endregion

		#region - Methods
		public static void OnStartup( )
		{
			Instance.ReadSettings();
		}

		//public void ReadSettings( )
		//{
		//	AllSettings = new Dictionary<string, object>();

		//	var settings = Properties.Settings.Default.Properties;
		//	foreach (var setting in settings)
		//	{
		//		var sett = setting as SettingsProperty;
		//		if (sett != null)
		//		{
		//			AllSettings.Add(sett.Name, sett.DefaultValue);
		//		}
		//		else
		//		{
		//			AllSettings.Add("Dud", null);
		//		}
		//	}
		//}

		//public void ReadSettings_2( )
		//{
		//	NewSettings = new List<Setting>();
		//	var settings = Properties.Settings.Default.Properties;
		//	foreach (var setting in settings)
		//	{
		//		var sett = setting as SettingsProperty;
		//		NewSettings.Add(new Setting(sett.Name, sett.DefaultValue, sett.PropertyType));
		//	}
		//}

		public void ReadSettings( )
		{
			AllSettings = new Dictionary<string, Setting>();
			var settings = Properties.Settings.Default.Properties;
			foreach (var setting in settings)
			{
				var sett = setting as SettingsProperty;
				AllSettings.Add(sett.Name, new Setting(sett.DefaultValue, sett.PropertyType));
			}
		}

		//public bool ChangeSetting( string name, string value )
		//{
		//	bool success = false;
		//	bool boolSuccess = bool.TryParse(value, out bool boolOut);

		//	foreach (var setting in AllSettings.Keys)
		//	{
		//		if (name == setting)
		//		{
		//			if (boolSuccess)
		//			{
		//				AllSettings[ setting ] = boolOut;
		//				success = true;
		//			}
		//			else
		//			{
		//				AllSettings[ setting ] = value;
		//				success = true;
		//			}
		//			break;
		//		}
		//	}
		//	return success;
		//}

		//public bool ChangeSetting_2( string name, string value )
		//{
		//	bool success = false;
		//	bool boolSuccess = bool.TryParse(value, out bool boolOut);
		//	bool intSuccess = Int32.TryParse(value, out int intOut);

		//	if (boolSuccess)
		//	{
		//		foreach (var setting in NewSettings)
		//		{
		//			if (name == setting.Name)
		//			{
		//				if (setting.Type == typeof(bool))
		//				{
		//					setting.Value = boolOut;
		//					success = true;
		//				}
		//				break;
		//			}
		//		}
		//	}
		//	if (intSuccess)
		//	{
		//		foreach (var setting in NewSettings)
		//		{
		//			if (name == setting.Name)
		//			{
		//				if (setting.Type == typeof(int))
		//				{
		//					setting.Value = intOut;
		//					success = true;
		//				}
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		foreach (var setting in NewSettings)
		//		{
		//			if (name == setting.Name)
		//			{
		//				if (setting.Type == typeof(string))
		//				{
		//					setting.Value = value;
		//					success = true;
		//				}
		//				break;
		//			}
		//		}
		//	}

		//	return success;
		//}

		public bool ChangeSetting( string name, string value )
		{
			//bool success = false;
			//try
			//{
			//	var setting = AllSettings[ name ];
			//	var val = Convert.ChangeType(value, setting.Type);
			//	setting.Value = val;
			//	SaveSettings();
			//	success = true;
			//}
			//catch (Exception e)
			//{
			//	throw e;
			//}
			//return success;
			bool success = false;

			return success;
		}

		private bool SearchSettings( string name, bool value, Type type )
		{
			throw new NotImplementedException();
		}

		//public void SaveSettings( )
		//{
		//	var settings = Properties.Settings.Default.Properties;
		//	foreach (var setting in settings)
		//	{
		//		var sett = setting as SettingsProperty;
		//		foreach (var curSetting in AllSettings.Keys)
		//		{
		//			if (sett.Name == curSetting)
		//			{
		//				sett.DefaultValue = AllSettings[ curSetting ];
		//			}
		//		}
		//	}
		//}

		//public void SaveSettings_2( )
		//{
		//	var settings = Properties.Settings.Default.Properties;
		//	foreach (var setting in settings)
		//	{
		//		var sett = setting as SettingsProperty;
		//		foreach (var curSetting in NewSettings)
		//		{
		//			if (sett.Name == curSetting.Name)
		//			{
		//				if (sett.PropertyType == curSetting.Type)
		//				{
		//					sett.DefaultValue = curSetting.Value;
		//				}
		//			}
		//		}
		//	}
		//}

		public void SaveSettings( )
		{
			var settings = Properties.Settings.Default.Properties;
			foreach (var setting in settings)
			{
				var sett = setting as SettingsProperty;
				foreach (var curSetting in AllSettings.Keys)
				{
					if (sett.Name == curSetting)
					{
						if (sett.PropertyType == AllSettings[curSetting].Type)
						{
							sett.DefaultValue = AllSettings[ curSetting ].Value;
						}
						break;
					}
				}
			}
			Properties.Settings.Default.Save();
		}
		#endregion

		#region - Full Properties
		public static SettingsData Instance
		{
			get
			{
				if (_instance is null)
				{
					_instance = new SettingsData();
				}
				return _instance;
			}
		}
		#endregion
	}
}
