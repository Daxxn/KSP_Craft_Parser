using KSPCraftParserConsole.ConsoleFormatters;
using KSPCraftParserConsole.DataContainers;
using KSPCraftParserConsole.Decisions_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.Commands
{
	/// <summary>
	/// Maybe wont need??
	/// </summary>
    public class ListStrategy : IMainStrategy
	{
		#region - Fields & Properties
		public DirectoryData Dir { get; set; } = DirectoryData.Instance;
		public string ObjectData { get; set; }
		public SecondWord Second { get; set; } = SecondWord.Null;
		#endregion

		#region - Constructors
		public ListStrategy( ) { }
		public ListStrategy( SecondWord sec)
		{
			Second = sec;
		}
		#endregion

		#region - Methods
		public void Execute( )
		{
			if (Second == SecondWord.dir)
			{
				Console.WriteLine("Folders :");
				#region OLD
				//for (int i = 0; i < Dir.Directories.Length; i++)
				//{
				//	Console.WriteLine($"{i} : {Path.GetFileName(Dir.Directories[ i ])}");
				//}
				#endregion

				string[] formattedDirs = PathFormatter.RemoveMiddleOfPaths(Dir.Directories);
				DataGrid<string> dirGrid = new DataGrid<string>(formattedDirs);
				dirGrid.PrintDataGrid();

				PrintFileStatus();
			}
			else if (Second == SecondWord.file)
			{
				Console.WriteLine("\nFiles :");
				#region OLD
				//for (int i = 0; i < Dir.Files.Length; i++)
				//{
				//	Console.WriteLine($"{i} : {Path.GetFileName(Dir.Files[ i ])}");
				//}
				#endregion

				string[] formattedFiles = PathFormatter.RemoveMiddleOfPaths(Dir.Files);
				DataGrid<string> fileGrid = new DataGrid<string>(formattedFiles);
				fileGrid.PrintDataGrid();

				PrintFileStatus();
			}
			else if (Second == SecondWord.Null)
			{
				Console.WriteLine("Folders :");

				#region OLD
				// Original
				//for (int i = 0; i < Dir.Directories.Length; i++)
				//{
				//	Console.WriteLine($"{i} : {Path.GetFileName(Dir.Directories[ i ])}");
				//}

				// Old Console Formatter
				//string[] formattedPaths = ConsoleFormatter.ReplaceMiddlePathFolders(Dir.Directories, false);
				//ConsoleFormatter.PrintDataGridVertical(formattedPaths, true);
				#endregion

				// New Console Formatter
				string[] formattedDirs = PathFormatter.RemoveMiddleOfPaths(Dir.Directories);
				DataGrid<string> dirGrid = new DataGrid<string>(formattedDirs);
				dirGrid.PrintDataGrid();

				Console.WriteLine("\nFiles :");

				#region OLD
				// Original
				//for (int i = 0; i < Dir.Files.Length; i++)
				//{
				//	Console.WriteLine($"{i} : {Path.GetFileName(Dir.Files[i])}");
				//}

				// Old Console Formatter
				//string[] formattedDirs = ConsoleFormatter.ReplaceMiddlePathFolders(Dir.Files, true);
				//ConsoleFormatter.PrintDataGridVertical(formattedDirs, true);
				#endregion

				// New Console Formatter
				string[] formattedFiles = PathFormatter.RemoveMiddleOfPaths(Dir.Files);
				DataGrid<string> fileGrid = new DataGrid<string>(formattedFiles);
				fileGrid.PrintDataGrid();

				PrintFileStatus();
			}
			else if (Second == SecondWord.settings)
			{

			}
			else
			{
				throw new CommandException("Second word doesnt make sense.");
			}
		}

		public void PrintLeft( string input, int leftOffset )
		{
			Console.SetCursorPosition(leftOffset, Console.CursorTop);
			Console.WriteLine(input);
		}

		public void PrintFileStatus( )
		{
			string curFile = String.IsNullOrEmpty(Dir.CurrentFile) ? "No File Selected" : Dir.CurrentFile;
			string curDir = String.IsNullOrEmpty(Dir.CurrentDir) ? "No Folder Selected" : Dir.CurrentDir;
			Console.SetCursorPosition(0, Console.CursorTop + 1);
			Console.Write("Selected File");
			Console.SetCursorPosition(16, Console.CursorTop);
			Console.WriteLine($" : {curFile}");

			Console.WriteLine("Current Folder");
			Console.SetCursorPosition(16, Console.CursorTop - 1);
			Console.WriteLine($" : {curDir}");
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
