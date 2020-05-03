using KSPCraftParserConsole.DataContainers;
using KSPCraftParserConsole.Decisions;
using KSPCraftParserConsole.Decisions_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Commands
{
    public class OpenStrategy : IMainStrategy
	{
		#region - Fields & Properties
		private const string pathDelimiter = "*";
		public DirectoryData Dir { get; set; }  = DirectoryData.Instance;
		public CraftData CraftData { get; set; } = CraftData.Instance;
		public string FileName { get; set; }
		public int SelectionIndex { get; set; }
		public List<string> Data { get; set; }
		public SecondWord Second { get; set; }
		#endregion

		#region - Constructors
		public OpenStrategy( SecondWord sec, List<string> data )
		{
			Second = sec;
			Data = data;
		}
		#endregion

		#region - Methods
		public void Execute( )
		{
			if (Data.Count == 0)
			{
				throw new CommandException("No file name given.");
			}
			if (Data.Count > 2)
			{
				throw new CommandException("File name cant include spaces. If file has spaces, use index.");
			}

			if (Second == SecondWord.dir)
			{
				ParseDirectory();
                #region OLD
                //bool indexSuccess = Int32.TryParse(Data[ 0 ], out int selectOut);
                //bool backSuccess = false;
                //int backOut = 1;
                //if (Data.Count == 2)
                //{
                //	backSuccess = Int32.TryParse(Data[ 1 ], out backOut);
                //}
                //bool setDir = false;

                //if (indexSuccess)
                //{
                //	SelectionIndex = selectOut;
                //	if (backSuccess)
                //	{
                //		setDir = Dir.Back(backOut);
                //	}
                //	else
                //	{
                //		setDir = Dir.SetCurrentDir(SelectionIndex);
                //	}
                //}
                //else
                //{
                //	if (Data[0].Contains(pathDelimiter))
                //	{
                //		if (Data.Count > 1)
                //		{

                //		}
                //		else
                //		{
                //			setDir = Dir.SetCurrentDir(Data[ 0 ]);
                //		}
                //	}
                //	else
                //	{
                //		setDir = Dir.SetCurrentDir(Data[ 0 ]);
                //	}
                //}
                //SuccessMessage(setDir);
                #endregion
            }
            else if (Second == SecondWord.file)
			{
				ParseFile();
				#region OLD
				//bool success = Int32.TryParse(Data[ 0 ], out int selectOut);
				//bool setFile = false;

				//if (success)
				//{
				//	SelectionIndex = selectOut;
				//	setFile = Dir.SetCurrentFile(SelectionIndex);
				//}
				//else
				//{
				//	setFile = Dir.SetCurrentFile(Data[ 0 ]);
				//}
				//SuccessMessage(setFile);
				#endregion
			}
			else if (Second == SecondWord.craft)
			{
				bool craftFound = ParseCraft();

				if (craftFound)
				{
					try
					{
						CraftData.OpenCraftFile();
						Console.WriteLine("Craft parsed successfully.");
					}
					catch (Exception e)
					{
						throw e;
					}
				}
			}
			else if (Second == SecondWord.parts)
			{
				ParseJson(true);
			}
			else if (Second == SecondWord.science)
			{
				ParseJson(false);
			}
		}

		private void ParseDirectory( )
		{
			bool indexSuccess = Int32.TryParse(Data[ 0 ], out int selectOut);
			bool backSuccess = false;
			int backOut = 1;
			if (Data.Count == 2)
			{
				backSuccess = Int32.TryParse(Data[ 1 ], out backOut);
			}
			bool setDir = false;

			if (indexSuccess)
			{
				SelectionIndex = selectOut;
				if (backSuccess)
				{
					setDir = Dir.Back(backOut);
				}
				else
				{
					setDir = Dir.SetCurrentDir(SelectionIndex);
				}
			}
			else
			{
				setDir = Dir.SetCurrentDir(Data[ 0 ]);
			}
			SuccessMessage(setDir);
		}

		private void ParseFile( )
		{
			bool setFile = GetFile();
			SuccessMessage(setFile);
		}

		private bool ParseCraft( )
		{
			bool goodFile = false;
			bool setFile = GetFile();

			goodFile = CraftData.CheckFile(Dir.CurrentFile, Properties.Settings.Default.CraftFileExt);
			if (goodFile)
			{
				CraftData.CraftPath = Dir.CurrentFile;
			}
			SuccessMessage(setFile, goodFile);
			return goodFile;
		}

		private void ParseJson( bool isParts )
		{
			bool goodFile = false;
			bool setFile = GetFile();

			goodFile = CraftData.CheckFile(Dir.CurrentFile, Properties.Settings.Default.DataFileExt);
			if (goodFile)
			{
				if (isParts)
				{
					CraftData.PartsPath = Dir.CurrentFile;
					CraftData.OpenDataFiles(isParts);
				}
				else
				{
					CraftData.SciencePath = Dir.CurrentFile;
					CraftData.OpenDataFiles(isParts);
				}
			}
			SuccessMessage(setFile, goodFile);
		}

		private bool GetFile( )
		{
			bool success = Int32.TryParse(Data[ 0 ], out int selectOut);
			if (success)
			{
				SelectionIndex = selectOut;
				return Dir.SetCurrentFile(SelectionIndex);
			}
			else
			{
				return Dir.SetCraftFile(Data[ 0 ]);
			}
		}

		public void SuccessMessage( bool success )
		{
			if (Second == SecondWord.dir)
			{
				if (success)
				{
					Console.WriteLine($"Current Directory set to {Dir.CurrentDir}");
				}
				else
				{
					Console.WriteLine("Unable to set directory.");
				}
			}
			else if (Second == SecondWord.file)
			{
				if (success)
				{
					Console.WriteLine($"Current Directory set to {Dir.CurrentFile}");
				}
				else
				{
					Console.WriteLine("Unable to set file.");
				}
			}
		}

		public void SuccessMessage( bool success, bool goodFile )
		{
			if (success)
			{
				if (Second == SecondWord.craft || Second == SecondWord.parts || Second == SecondWord.science)
				{
					if (goodFile)
					{
						Console.WriteLine($"{Second} file set to {CraftData.CraftPath}");
						Console.WriteLine($"{Second} file opened and parsing...");
					}
					else
					{
						Console.WriteLine($"File isnt a usable {Second} file.");
					}
				}
			}
			else
			{
				Console.WriteLine("Unable to set file.");
			}
		}
		#endregion

		#region - Full Properties

		#endregion

	}
}
