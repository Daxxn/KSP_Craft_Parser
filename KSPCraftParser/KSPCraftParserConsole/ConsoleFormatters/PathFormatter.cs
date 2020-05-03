using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole.ConsoleFormatters
{
    public enum PathOptions
    {
        ReplaceMiddle,
        ReplaceFolders,
        Auto
    }
    public static class PathFormatter
	{
        #region - Fields & Properties
        public static bool KeepExtensions { get; set; }
        #endregion

        #region - Methods
        #region File Printer Methods
        public static string[] RemoveMiddleOfPaths( string[] paths )
        {
            List<string> output = new List<string>();

            output.Add($"0 : {paths[ 0 ]}");
            for (int i = 1; i < paths.Length; i++)
            {
                string drive = Path.GetPathRoot(paths[ i ]);
                string folder = Path.GetFileName(Path.GetDirectoryName(paths[ i ]));
                string name = KeepExtensions ? Path.GetFileName(paths[ i ]) : Path.GetFileNameWithoutExtension(paths[ i ]);

                output.Add($@"{i} : {drive}...\{folder}\{name}");
            }

            return output.ToArray();
        }

        public static string[] ReplaceMiddlePathFolders( string[] paths )
        {
            List<string> output = new List<string>();

            output.Add($"0 : {paths[ 0 ]}");
            for (int k = 1; k < paths.Length; k++)
            {
                string newPath = $"{k} : ";
                newPath += Path.GetPathRoot(paths[ k ]);
                string[] splitPath = paths[ k ].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                if (splitPath.Length > 3)
                {
                    for (int i = 1; i < splitPath.Length - 2; i++)
                    {
                        newPath += "..\\";
                    }
                    newPath += $"{splitPath[ splitPath.Length - 2 ]}\\";
                    if (KeepExtensions)
                    {
                        newPath += Path.GetFileName(paths[ k ]);
                    }
                    else
                    {
                        newPath += Path.GetFileNameWithoutExtension(paths[ k ]);
                    }

                    output.Add(newPath);
                }
                else
                {
                    output.Add($"{k} : {paths[ k ]}");
                }
            }

            //foreach (var path in paths)
            //{
            //    string newPath = Path.GetPathRoot(path);
            //    string[] splitPath = path.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

            //    if (splitPath.Length > 3)
            //    {
            //        for (int i = 1; i < splitPath.Length - 2; i++)
            //        {
            //            newPath += "..\\";
            //        }
            //        newPath += $"{splitPath[ splitPath.Length - 2 ]}\\";
            //        if (keepExt)
            //        {
            //            newPath += Path.GetFileName(path);
            //        }
            //        else
            //        {
            //            newPath += Path.GetFileNameWithoutExtension(path);
            //        }

            //        output.Add(newPath);
            //    }
            //    else
            //    {
            //        output.Add(path);
            //    }
            //}

            return output.ToArray();
        }
        #endregion
        #endregion

        #region - Full Properties

        #endregion
    }
}
