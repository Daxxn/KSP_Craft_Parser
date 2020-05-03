using KSPCraftParserConsole.Commands;
using KSPCraftParserConsole.Decisions_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole
{
    public class Command
	{
		#region - Fields & Properties
		private static readonly char[] space = new char[] { ' ' };
		private static readonly char[] pathDelim = new char[] { '*' };
		public FirstWord First { get; set; }
		public SecondWord Second { get; set; }
		public List<string> Data { get; set; }
		public IMainStrategy Strategy { get; set; }
		#endregion

		#region - Constructors
		public Command( ) { }
		public Command( FirstWord first, List<string> data )
		{
			First = first;
			Data = data;

			Second = SecondWord.Null;

			SetStrategy(first);
		}
		public Command( FirstWord first, SecondWord sec, List<string> data )
		{
			First = first;
			Second = sec;
			Data = data;
			SetStrategy(first);
		}
		public Command( IMainStrategy strategy, SecondWord sec, List<string> data)
		{
			Strategy = strategy;
			Second = sec;
			Data = data;
		}
		#endregion

		#region - Methods
		public static Command ParseCommand( string input )
		{
			Command cmd = new Command();
			string[] split;
			if (input.Contains("*"))
			{
				List<string> temp = new List<string>();
				var pathSplit = input.Split(pathDelim, StringSplitOptions.RemoveEmptyEntries);
				string path = pathSplit[ 1 ];
				temp.AddRange(pathSplit[ 0 ].Split(space, StringSplitOptions.RemoveEmptyEntries));
				temp.Add(path);
				split = temp.ToArray();
			}
			else
			{
				split = input.Split(space, StringSplitOptions.RemoveEmptyEntries); 
			}

			bool firstSuccess = Enum.TryParse(split[ 0 ].ToLower(), out FirstWord firstOut);
			bool secondSuccess = false;
			SecondWord secOut = SecondWord.Null;
			if (split.Length > 1)
			{
				secondSuccess = Enum.TryParse(split[ 1 ].ToLower(), out secOut);
			}
			List<string> dataOutput = new List<string>();

			switch (split.Length)
			{
				case 1 :
					if (firstSuccess)
					{
						cmd = new Command(firstOut, SecondWord.Null, dataOutput);
					}
					break;
				case 2:
					if (firstSuccess)
					{
						if (secondSuccess)
						{
							cmd = new Command(firstOut, secOut, dataOutput);
						}
						else
						{
							dataOutput.Add(split[ 1 ]);
							goto case 1;
						}
					}
					else
					{
						goto default;
					}
					break;
				case 3:
					if (firstSuccess)
					{
						if (secondSuccess)
						{
							dataOutput.Add(split[ 2 ]);
							cmd = new Command(firstOut, secOut, dataOutput);
						}
						else
						{
							for (int i = 1; i < split.Length; i++)
							{
								dataOutput.Add(split[ i ]);
							}
							cmd = new Command(firstOut, dataOutput);
						}
					}
					else
					{
						throw new Exception("Invalid Command.");
					}
					break;
				case 4:
					if (firstSuccess)
					{
						if (secondSuccess)
						{
							dataOutput.Add(split[ 2 ]);
							dataOutput.Add(split[ 3 ]);
							cmd = new Command(firstOut, secOut, dataOutput);
						}
						else
						{
							for (int i = 1; i < split.Length; i++)
							{
								dataOutput.Add(split[ i ]);
							}
							cmd = new Command(firstOut, dataOutput);
						}
					}
					else
					{
						throw new Exception("Invalid Command.");
					}
					break;
				case 5:
					for (int i = 2; i < split.Length; i++)
					{
						dataOutput.Add(split[ i ]);
					}
					goto case 2;
				case 0 :
					throw new Exception("No command given.");
				default:
					throw new Exception("Command couldnt parse. probably too many commands.");
			}
			return cmd;
		}

		public void SetStrategy( )
		{
			switch (First)
			{
				case FirstWord.calc:
					Strategy = new CalcStrategy();
					break;
				case FirstWord.clear:
					Strategy = new ClearStrategy();
					break;
				case FirstWord.delete:
					Strategy = new DeleteStrategy();
					break;
				case FirstWord.list:
					Strategy = new ListStrategy(Second);
					break;
				case FirstWord.move:
					Strategy = new MoveStrategy(Second, Data);
					break;
				case FirstWord.open:
					Strategy = new OpenStrategy(Second, Data);
					break;
				case FirstWord.part:
					Strategy = new PartStrategy();
					break;
				case FirstWord.set:
					Strategy = new SetStrategy(Data);
					break;
				default:
					throw new Exception("Could not find strategy.");
			}
		}

		public void SetStrategy( FirstWord action)
		{
			switch (action)
			{
				case FirstWord.calc:
					Strategy = new CalcStrategy();
					break;
				case FirstWord.clear:
					Strategy = new ClearStrategy();
					break;
				case FirstWord.delete:
					Strategy = new DeleteStrategy();
					break;
				case FirstWord.list:
					Strategy = new ListStrategy(Second);
					break;
				case FirstWord.move:
					Strategy = new MoveStrategy(Second, Data);
					break;
				case FirstWord.open:
					Strategy = new OpenStrategy(Second, Data);
					break;
				case FirstWord.part:
					Strategy = new PartStrategy();
					break;
				case FirstWord.set:
					Strategy = new SetStrategy(Data);
					break;
				default:
					throw new Exception("Could not find strategy.");
			}
		}

		//public static Command ParseCommand( string userInput )
		//{
		//	string[] splitOut = userInput.Split(space, StringSplitOptions.RemoveEmptyEntries);
		//	if (splitOut.Length != 3)
		//	{
		//		throw new CommandException("Must be a 'verb' 'noun' structure", userInput);
		//	}
		//	bool verbSuccess = Enum.TryParse(splitOut[ 0 ], out Verb verbOutput);
		//	bool nounSuccess = Enum.TryParse(splitOut[ 1 ], out Noun nounOutput);

		//	if (!verbSuccess)
		//	{
		//		throw new CommandException("Verb was not parsable.", splitOut[0]);
		//	}

		//	if (!nounSuccess)
		//	{
		//		throw new CommandException("Noun was not parsable.", splitOut[1]);
		//	}
		//	return new Command(verbOutput, nounOutput, splitOut[2]);
		//}

		public void ExecuteCommand(  )
		{

		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
