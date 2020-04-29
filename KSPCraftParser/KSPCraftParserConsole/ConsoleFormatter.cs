using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole
{
    public static class ConsoleFormatter
	{
        #region - Fields & Properties

        #endregion

        //#region - Methods
        ///// <summary>
        ///// Prints an array of strings from left to right.
        ///// </summary>
        ///// <param name="data">The string data to be printed.</param>
        ///// <param name="spanScreen">Selects between dividing the columns between screen width or the longest string in the array. (best for long strings.)</param>
        ///// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        //public static void PrintDataGridHorizontal( string[] data, bool spanScreen, int columns = 4 )
        //{
        //    if (data != null || data.Length > 0)
        //    {
        //        if (columns > 1)
        //        {
        //            if (data.Length / 2 > columns)
        //            {
        //                int startPos = Console.CursorTop;
        //                int offset = 10;
        //                int currentCol = 0;
        //                int currentRow = 0;

        //                if (!spanScreen)
        //                {
        //                    foreach (var item in data)
        //                    {
        //                        if (item.Length > offset)
        //                        {
        //                            offset = item.Length + 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    offset = Console.WindowWidth / columns;
        //                }

        //                for (int i = 0; i < data.Length; i++)
        //                {
        //                    int colPos = offset * currentCol;
        //                    Console.SetCursorPosition(colPos, currentRow + startPos);
        //                    Console.WriteLine(data[ i ]);

        //                    if (currentCol < columns - 1)
        //                    {
        //                        currentCol++;
        //                    }
        //                    else
        //                    {
        //                        currentCol = 0;
        //                        currentRow++;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                PrintDataGridHorizontal(data, spanScreen, columns - 1);
        //            }
        //        }
        //        else
        //        {
        //            NormalPrint(data);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Prints an array of strings from top to bottom.
        ///// </summary>
        ///// <param name="data">The string data to be printed.</param>
        ///// <param name="spanScreen">Selects between dividing the columns between screen width or the longest string in the array. (best for long strings.)</param>
        ///// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        //public static void PrintDataGridVertical( string[] data, bool spanScreen, int columns = 4 )
        //{
        //    if (data != null || data.Length > 0)
        //    {
        //        if (columns > 1)
        //        {
        //            if (data.Length / 2 > columns)
        //            {
        //                int startPos = Console.CursorTop;
        //                int rowLength = data.Length / columns;
        //                int offset = 10;

        //                if (!spanScreen)
        //                {
        //                    foreach (var item in data)
        //                    {
        //                        if (item.Length > offset)
        //                        {
        //                            offset = item.Length + 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    offset = Console.WindowWidth / columns;
        //                }

        //                int rowIndex = 0;
        //                int colIndex = 0;
        //                for (int i = 0; i < data.Length; i++)
        //                {
        //                    int left = colIndex * offset;
        //                    Console.SetCursorPosition(left, rowIndex + startPos);
        //                    Console.WriteLine(data[ i ]);

        //                    if (i >= rowLength - 1)
        //                    {
        //                        colIndex++;
        //                        rowIndex = 0;
        //                        rowLength *= 2;
        //                    }
        //                    else
        //                    {
        //                        rowIndex++;
        //                    }
        //                }
        //                Console.CursorTop++;
        //            }
        //            else
        //            {
        //                PrintDataGridVertical(data, spanScreen, columns - 1);
        //            }
        //        }
        //        else
        //        {
        //            NormalPrint(data);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Default line-by-line print.
        ///// </summary>
        ///// <param name="data">The string data to be printed.</param>
        //public static void NormalPrint( string[] data )
        //{
        //    foreach (var d in data)
        //    {
        //        Console.WriteLine(d);
        //    }
        //}

        //#region File Printer Methods
        //public static string[] RemoveMiddleOfPaths( string[] paths, bool keepExt )
        //{
        //    List<string> output = new List<string>();

        //    for (int i = 0; i < paths.Length; i++)
        //    {
        //        string drive = Path.GetPathRoot(paths[i]);
        //        string folder = Path.GetFileName(Path.GetDirectoryName(paths[i]));
        //        string name = keepExt ? Path.GetFileName(paths[i]) : Path.GetFileNameWithoutExtension(paths[i]);

        //        output.Add($@"{i} : {drive}...\{folder}\{name}");
        //    }

        //    //foreach (var path in paths)
        //    //{
        //    //    string drive = Path.GetPathRoot(path);
        //    //    string folder = Path.GetFileName(Path.GetDirectoryName(path));
        //    //    string name = keepExt ? Path.GetFileName(path) : Path.GetFileNameWithoutExtension(path);

        //    //    output.Add($@"{drive}...\{folder}\{name}");
        //    //}

        //    return output.ToArray();
        //}

        //public static string[] ReplaceMiddlePathFolders( string[] paths, bool keepExt )
        //{
        //    List<string> output = new List<string>();

        //    for (int k = 0; k < paths.Length; k++)
        //    {
        //        string newPath = $"{k} : ";
        //        newPath += Path.GetPathRoot(paths[k]);
        //        string[] splitPath = paths[k].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

        //        if (splitPath.Length > 3)
        //        {
        //            for (int i = 1; i < splitPath.Length - 2; i++)
        //            {
        //                newPath += "..\\";
        //            }
        //            newPath += $"{splitPath[ splitPath.Length - 2 ]}\\";
        //            if (keepExt)
        //            {
        //                newPath += Path.GetFileName(paths[k]);
        //            }
        //            else
        //            {
        //                newPath += Path.GetFileNameWithoutExtension(paths[k]);
        //            }

        //            output.Add(newPath);
        //        }
        //        else
        //        {
        //            output.Add($"{k} : {paths[k]}");
        //        }
        //    }

        //    //foreach (var path in paths)
        //    //{
        //    //    string newPath = Path.GetPathRoot(path);
        //    //    string[] splitPath = path.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

        //    //    if (splitPath.Length > 3)
        //    //    {
        //    //        for (int i = 1; i < splitPath.Length - 2; i++)
        //    //        {
        //    //            newPath += "..\\";
        //    //        }
        //    //        newPath += $"{splitPath[ splitPath.Length - 2 ]}\\";
        //    //        if (keepExt)
        //    //        {
        //    //            newPath += Path.GetFileName(path);
        //    //        }
        //    //        else
        //    //        {
        //    //            newPath += Path.GetFileNameWithoutExtension(path);
        //    //        }

        //    //        output.Add(newPath);
        //    //    }
        //    //    else
        //    //    {
        //    //        output.Add(path);
        //    //    }
        //    //}

        //    return output.ToArray();
        //}
        //#endregion
        //#endregion

        #region - Full Properties

        #endregion
    }
}
