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
		public DirectoryData Dir { get; set; }  = DirectoryData.Instance;
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
					SuccessMessage(setDir);
				}
				else
				{
					setDir = Dir.SetCurrentDir(Data[ 0 ]);
					SuccessMessage(setDir);
				}

				
			}
			else if (Second == SecondWord.file)
			{
				bool success = Int32.TryParse(Data[ 0 ], out int selectOut);
				bool setFile = false;

				if (success)
				{
					SelectionIndex = selectOut;
					setFile = Dir.SetCurrentFile(SelectionIndex);
					SuccessMessage(setFile);
				}
				else
				{
					setFile = Dir.SetCurrentFile(Data[ 0 ]);
					SuccessMessage(setFile);
				}
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
		#endregion

		#region - Full Properties

		#endregion

	}
}
