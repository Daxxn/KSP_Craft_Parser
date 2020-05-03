using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.DataContainers
{
    public class DirectoryData
	{
		#region - Fields & Properties
		private static DirectoryData _instance;
		public string CurrentDir { get; set; } = "";
		public string CurrentFile { get; set; } = "";
		public string[] Directories { get; set; } = new string[ 0 ];
		public string[] Files { get; set; } = new string[ 0 ];
		#endregion

		#region - Methods
		public bool SetCurrentDir( string newDir )
		{
			string tempDir = Path.Combine(CurrentDir, newDir);
			if (Directory.Exists(tempDir))
			{
				CurrentDir = tempDir;
				GetDirectories();
				GetFiles();
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool SetCurrentDir( int newDir )
		{
			if (newDir != 0)
			{
				string tempDir = Path.Combine(CurrentDir, Directories[ newDir ]);
				if (Directory.Exists(tempDir))
				{
					CurrentDir = tempDir;
					GetDirectories();
					GetFiles();
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return Back(1);
			}
		}
		public bool SetCurrentFile( string newFile )
		{
			string tempFile = Path.Combine(CurrentDir, newFile);
			if (File.Exists(tempFile))
			{
				CurrentFile = tempFile;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool SetCurrentFile( int newFile )
		{
			string tempFile = Files[ newFile ];
			if (File.Exists(tempFile))
			{
				CurrentFile = tempFile;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool SetCraftFile( string fileName )
		{
			string tempFile = Path.Combine(CurrentDir, fileName);
			string newFile = Path.ChangeExtension(tempFile, Properties.Settings.Default.CraftFileExt);
			if (File.Exists(newFile))
			{
				CurrentFile = newFile;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Back( int count )
		{
			string tempDir = CurrentDir;
			for (int i = 0; i < count; i++)
			{
				DirectoryInfo dirInfo = Directory.GetParent(tempDir);
				if (dirInfo != null)
				{
					tempDir = dirInfo.FullName;
				}
			}

			if (Directory.Exists(tempDir))
			{
				CurrentDir = tempDir;
				GetDirectories();
				GetFiles();
				return true;
			}
			else
			{
				return false;
			}
		}

		public string[] GetDirectories( string path )
		{
			if (Directory.Exists(path))
			{
				List<string> tempDirs = new List<string>()
				{
					"--Back"
				};
				tempDirs.AddRange(Directory.GetDirectories(path).ToList());
				return tempDirs.ToArray();
			}
			else
			{
				throw new DirectoryNotFoundException($"Directory doesnt exist :\n{path}");
			}
		}

		public void GetDirectories( )
		{
			if (Directory.Exists(CurrentDir))
			{
				List<string> tempDirs = new List<string>()
				{
					"--Back"
				};
				tempDirs.AddRange(Directory.GetDirectories(CurrentDir).ToList());
				Directories = tempDirs.ToArray();
			}
			else
			{
				throw new DirectoryNotFoundException($"Directory doesnt exist :\n{CurrentDir}");
			}
		}

		public string[] GetFiles( string path )
		{
			if (Directory.Exists(path))
			{
				return Directory.GetFiles(path);
			}
			else
			{
				throw new DirectoryNotFoundException($"Directory doesnt exist :\n{path}");
			}
		}

		public void GetFiles( )
		{
			if (Directory.Exists(CurrentDir))
			{
				Files = Directory.GetFiles(CurrentDir);
			}
			else
			{
				throw new DirectoryNotFoundException($"Directory doesnt exist :\n{CurrentDir}");
			}
		}

		public string GetParentDir( )
		{
			return Directory.GetParent(CurrentDir).FullName;
		}

		public void PrintDirectories( string path )
		{
			if (Directory.Exists(path))
			{
				Directories = GetDirectories(path);

				for (int i = 0; i < Directories.Length; i++)
				{
					Console.WriteLine($"{i} : ");
				}
			}
		}

		public static void OnStartup( string[] args )
		{
			if (args.Length == 2 )
			{
				if (args[ 0 ] == "drive")
				{
					string[] drives = Environment.GetLogicalDrives();

					if (drives.Length > 1)
					{
						if (args.Length == 2)
						{
							if (Directory.Exists(args[ 1 ]))
							{
								Instance.SetCurrentDir(args[ 1 ]);
							}
						}
					}
					else
					{
						Instance.SetCurrentDir(@"C:\");
					}
				}
			}
			else
			{
				Instance.SetCurrentDir(@"C:\");
			}
		}

		public static void OnStartup( )
		{
			string[] drives = Environment.GetLogicalDrives();

			Instance.SetCurrentDir(drives[ 0 ]);
		}
		#endregion

		#region - Full Properties
		public static DirectoryData Instance
		{
			get
			{
				if (_instance is null)
				{
					_instance = new DirectoryData();
				}
				return _instance;
			}
		}
		#endregion
	}
}
