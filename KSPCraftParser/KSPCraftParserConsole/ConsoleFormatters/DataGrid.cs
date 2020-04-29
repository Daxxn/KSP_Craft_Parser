using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.ConsoleFormatters
{
    public class DataGrid<T> where T : class
    {
        #region - Fields & Properties
        #region -- Static Properties
        public static bool AutoColumns { get; set; } = true;
        public static int ManulaColumnCount { get; set; } = 4;
        public static bool PrintVertical { get; set; } = true;
        public static bool PrintDecorations { get; set; } = true;
        public static ConsoleColor TextColor { get; private set; } = ConsoleColor.Cyan;
        public static Dictionary<string, int> UTFBlocks { get; set; } = new Dictionary<string, int>()
            {
                {"Upper", 9600 },
                {"Full", 9608 },
                {"Left", 9612 },
                {"Right", 9616 },
                {"LightShade", 9617 },
                {"MedShade", 9618 },
                {"DarkShade", 9619 },
                {"Square", 9632 }
            };
        #endregion
        public T[] Data { get; set; }
        private string[] StringData { get; set; }
        public bool SpanScreen { get; set; }
        #endregion

        #region - Constructors
        public DataGrid( T[] data )
        {
            Data = data;
        }
        #endregion

        #region - Methods
        public void PrintDataGrid( )
        {
            if (typeof(T) != typeof(string))
            {
                StringData = new string[ Data.Length ];
                for (int i = 0; i < Data.Length; i++)
                {
                    StringData[ i ] = Data[ i ].ToString();
                }
            }
            else
            {
                StringData = Data as string[];
            }

            if (AutoColumns)
            {
                if (PrintVertical)
                {
                    (int longestItem, int col) = GetColumnCount_2();

                    if (PrintDecorations)
                    {
                        PrintDataGridVerticalDeco(longestItem, col);
                    }
                    else
                    {
                        PrintDataGridVertical(longestItem, col);
                    }
                }
                else
                {
                    PrintDataGridHorizontal();
                }
            }
            else
            {
                if (PrintVertical)
                {
                    if (PrintDecorations)
                    {
                        PrintDataGridVerticalDeco(ManulaColumnCount);
                    }
                    else
                    {
                        PrintDataGridVertical(ManulaColumnCount);
                    }
                }
                else
                {
                    PrintDataGridHorizontal(ManulaColumnCount);
                }
            }
        }

        /// <summary>
        /// Prints an array of strings from left to right.
        /// </summary>
        /// <param name="data">The string data to be printed.</param>
        /// <param name="spanScreen">Selects between dividing the columns between screen width or the longest string in the array. (best for long strings.)</param>
        /// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        public void PrintDataGridHorizontal( int columns = 4 )
        {
            if (StringData != null || StringData.Length > 0)
            {
                if (columns > 1)
                {
                    if (StringData.Length / 2 > columns)
                    {
                        int startPos = Console.CursorTop + 1;
                        int offset = 10;
                        int currentCol = 0;
                        int currentRow = 0;
                        int itemSize = 0;

                        foreach (var item in StringData)
                        {
                            if (item.Length > offset)
                            {
                                itemSize = item.Length + 1;
                            }
                        }

                        if (SpanScreen)
                        {
                            offset = Console.WindowWidth / columns;
                        }
                        else
                        {
                            offset = itemSize;
                        }

                        if (Console.BufferWidth <= offset + itemSize)
                        {
                            Console.BufferWidth = offset + itemSize + 8;
                        }

                        for (int i = 0; i < StringData.Length; i++)
                        {
                            int colPos = offset * currentCol;
                            Console.SetCursorPosition(colPos, currentRow + startPos);
                            string buffer = StringData.Length < offset ? StringData[ i ] : $"{StringData[ i ].Substring(0, offset - 2)}..";
                            Console.WriteLine(buffer);

                            if (currentCol < columns - 1)
                            {
                                currentCol++;
                            }
                            else
                            {
                                currentCol = 0;
                                currentRow++;
                            }
                        }

                        Console.CursorTop = startPos + 2;
                    }
                    else
                    {
                        PrintDataGridHorizontal(columns - 1);
                    }
                }
                else
                {
                    NormalPrint();
                }
            }
        }

        /// <summary>
        /// Prints an array of strings from top to bottom.
        /// </summary>
        /// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        public void PrintDataGridVertical( int columns = 4 )
        {
            if (StringData != null || StringData.Length > 0)
            {
                if (columns > 1)
                {
                    if (StringData.Length / 2 > columns)
                    {
                        int startPos = Console.CursorTop + 1;
                        int rowLength = StringData.Length / columns;
                        int offset = 10;
                        int itemSize = 0;

                        foreach (var item in StringData)
                        {
                            if (item.Length > offset)
                            {
                                itemSize = item.Length;
                            }
                        }

                        if (SpanScreen)
                        {
                            offset = Console.WindowWidth / columns;
                        }
                        else
                        {
                            offset = itemSize;
                        }

                        if (Console.BufferWidth <= offset + itemSize)
                        {
                            Console.BufferWidth = offset + itemSize + 8;
                        }

                        int rowPos = rowLength;
                        int rowIndex = 0;
                        int colIndex = 0;
                        for (int i = 0; i < StringData.Length; i++)
                        {
                            int left = colIndex * offset;
                            Console.SetCursorPosition(left, rowIndex + startPos);
                            string buffer = StringData.Length < offset ? StringData[ i ] : $"{StringData[ i ].Substring(0, offset - 2)}..";
                            Console.WriteLine(buffer);

                            if (rowIndex >= rowPos)
                            {
                                colIndex++;
                                rowIndex = 0;
                                //rowPos = 0;
                            }
                            else
                            {
                                rowIndex++;
                            }
                        }
                        Console.CursorTop = startPos + rowLength + 2;
                    }
                    else
                    {
                        PrintDataGridVertical(columns - 1);
                    }
                }
                else
                {
                    NormalPrint();
                }
            }
        }

        /// <summary>
        /// Prints an array of strings from top to bottom. Used with AutoColumns
        /// </summary>
        /// <param name="longestItem">The longest string in the data.</param>
        /// <param name="columns">Number of columns.</param>
        public void PrintDataGridVertical( int longestItem, int columns = 4 )
        {
            if (StringData != null || StringData.Length > 0)
            {
                if (columns > 1)
                {
                    if (StringData.Length / 2 > columns)
                    {
                        int startPos = Console.CursorTop + 1;
                        int rowLength = StringData.Length / columns;
                        int offset;

                        if (SpanScreen)
                        {
                            offset = Console.WindowWidth / columns;
                        }
                        else
                        {
                            offset = longestItem;
                        }

                        if (Console.BufferWidth <= offset + longestItem)
                        {
                            Console.BufferWidth = offset + longestItem + 8;
                        }

                        int rowPos = rowLength;
                        int rowIndex = 0;
                        int colIndex = 0;
                        for (int i = 0; i < StringData.Length; i++)
                        {
                            int left = colIndex * offset;
                            Console.SetCursorPosition(left, rowIndex + startPos);
                            string buffer = StringData.Length < offset ? StringData[ i ] : $"{StringData[ i ].Substring(0, offset - 2)}..";
                            Console.WriteLine(buffer);

                            if (rowIndex >= rowPos)
                            {
                                colIndex++;
                                rowIndex = 0;
                                //rowPos = 0;
                            }
                            else
                            {
                                rowIndex++;
                            }
                        }
                        Console.CursorTop = startPos + rowLength + 2;
                    }
                    else
                    {
                        PrintDataGridVertical(columns - 1);
                    }
                }
                else
                {
                    NormalPrint();
                }
            }
        }

        /// <summary>
        /// Prints an array of strings from top to bottom.
        /// </summary>
        /// <param name="data">The string data to be printed.</param>
        /// <param name="spanScreen">Selects between dividing the columns between screen width or the longest string in the array. (best for long strings.)</param>
        /// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        public void PrintDataGridVerticalDeco( int columns = 4 )
        {
            if (StringData != null || StringData.Length > 0)
            {
                if (columns > 1)
                {
                    if (StringData.Length / 2 > columns)
                    {
                        int startPos = Console.CursorTop + 1;
                        int rowLength = StringData.Length / columns;
                        int offset = 10;
                        int itemSize = 0;

                        foreach (var item in StringData)
                        {
                            if (item.Length > offset)
                            {
                                itemSize = item.Length;
                            }
                        }

                        if (SpanScreen)
                        {
                            offset = Console.WindowWidth / columns;

                            for (int i = 0; i < Console.WindowWidth; i++)
                            {
                                Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Full" ]));
                            }
                            //Console.CursorTop++;
                        }
                        else
                        {
                            offset = itemSize;
                        }

                        if (Console.BufferWidth <= offset + itemSize)
                        {
                            Console.BufferWidth = offset + itemSize + 8;
                        }

                        int rowPos = rowLength;
                        int rowIndex = 0;
                        int colIndex = 0;
                        for (int i = 0; i < StringData.Length; i++)
                        {
                            int left = colIndex * offset;
                            Console.SetCursorPosition(left, rowIndex + startPos);
                            string buffer = $"{Char.ConvertFromUtf32(UTFBlocks[ "Left" ])} ";
                            buffer += StringData.Length < offset ? StringData[ i ] : $"{StringData[ i ].Substring(0, offset - 2)}..";
                            Console.WriteLine(buffer);

                            if (rowIndex >= rowPos)
                            {
                                colIndex++;
                                rowIndex = 0;
                                //rowPos = 0;
                            }
                            else
                            {
                                rowIndex++;
                            }
                        }

                        for (int i = 0; i < rowLength + 1; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth - 1, i + startPos);
                            Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Right" ]));
                        }

                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Full" ]));
                        }

                        Console.CursorTop = startPos + rowLength + 2;
                    }
                    else
                    {
                        PrintDataGridVerticalDeco(columns - 1);
                    }
                }
                else
                {
                    NormalPrint();
                }
            }
        }

        /// <summary>
        /// Prints an array of strings from top to bottom.
        /// </summary>
        /// <param name="data">The string data to be printed.</param>
        /// <param name="spanScreen">Selects between dividing the columns between screen width or the longest string in the array. (best for long strings.)</param>
        /// <param name="columns">Manually set the number of columns. Default is 4, will decrease columns if data count is lower than 8.</param>
        public void PrintDataGridVerticalDeco( int longestItem, int columns = 4 )
        {
            if (StringData != null || StringData.Length > 0)
            {
                if (columns > 1)
                {
                    if (StringData.Length / 2 > columns)
                    {
                        int startPos = Console.CursorTop + 1;
                        int rowLength = StringData.Length / columns;
                        int offset = 10;

                        if (SpanScreen)
                        {
                            offset = Console.WindowWidth / columns;

                            for (int i = 0; i < Console.WindowWidth; i++)
                            {
                                Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Full" ]));
                            }
                            //Console.CursorTop++;
                        }
                        else
                        {
                            offset = longestItem;
                        }

                        if (Console.BufferWidth <= offset + longestItem + 4)
                        {
                            Console.BufferWidth = offset + longestItem + 8;
                        }

                        int rowPos = rowLength;
                        int rowIndex = 0;
                        int colIndex = 0;
                        for (int i = 0; i < StringData.Length; i++)
                        {
                            int left = colIndex * offset;
                            Console.SetCursorPosition(left, rowIndex + startPos);
                            string buffer = $"{Char.ConvertFromUtf32(UTFBlocks[ "Left" ])} ";
                            buffer += StringData[i].Length < offset - 2 ? StringData[ i ] : $"{StringData[ i ].Substring(0, offset - 4)}..";
                            Console.WriteLine(buffer);

                            if (rowIndex >= rowPos)
                            {
                                colIndex++;
                                rowIndex = 0;
                                //rowPos = 0;
                            }
                            else
                            {
                                rowIndex++;
                            }
                        }

                        for (int i = 0; i < rowLength + 1; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth - 1, i + startPos);
                            Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Right" ]));
                        }

                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(Char.ConvertFromUtf32(UTFBlocks[ "Full" ]));
                        }

                        Console.CursorTop = startPos + rowLength + 2;
                    }
                    else
                    {
                        PrintDataGridVerticalDeco(columns - 1);
                    }
                }
                else
                {
                    NormalPrint();
                }
            }
        }

        /// <summary>
        /// Default line-by-line print.
        /// </summary>
        /// <param name="data">The string data to be printed.</param>
        public void NormalPrint( )
        {
            foreach (var d in StringData)
            {
                Console.WriteLine(d);
            }
        }

        private (int longestItem, int columns) GetColumnCount( )
        {
            // LongestItem = 30
            // DataLength  = 10
            // Columns        = 4
            // rowLength    = 7.5
            // colLength      = 120
            // Default window size: 120

            int columns = 4;
            double lengthRatio = 0;
            double rowratio = 0;
            int rowLen = Data.Length / 4;
            int longestItem = 0;
            foreach (var item in StringData)
            {
                if (item.Length > longestItem)
                {
                    longestItem = item.Length;
                }
            }

            // longestItem = 28
            // columns = 4
            // lenRatio = 0.9333333333
            lengthRatio = (double)longestItem * (double)columns / (double)Console.WindowWidth;
            if (lengthRatio > 1)
            {
                SpanScreen = true;
            }
            else
            {
                SpanScreen = false;
            }

            // Data Len = 16
            // rowLen = 4
            // rowratio = 0.142857142857142857142857142
            rowratio = rowLen / longestItem;
            if (rowratio > lengthRatio)
            {
                columns = (int)Math.Round(rowratio - lengthRatio) * 10;
            }

            return (longestItem, columns);
        }

        private (int longestItem, int columns) GetColumnCount_2( )
        {
            int columns = 4;
            double columsWeight = 1.1;
            double lengthRatio = 0;
            double rowratio = 0;
            int rowLen = Data.Length / 4;
            int longestItem = 0;
            foreach (var item in StringData)
            {
                if (item.Length > longestItem)
                {
                    longestItem = item.Length;
                }
            }

            lengthRatio = (double)longestItem * (double)columns / (double)Console.WindowWidth;
            if (lengthRatio < 1)
            {
                columns += (int)Math.Round(lengthRatio);
            }
            else
            {
                SpanScreen = true;
            }

            rowratio = (double)columns / (double)Data.Length /** columsWeight*/;
            //columns += (int)Math.Round(rowratio);
            if (rowratio < 0.5)
            {
                columns += (int)Math.Round(rowratio * columsWeight);
            }
            else if (rowratio > 0.5)
            {
                columns--;
            }

            return (longestItem, columns);
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
