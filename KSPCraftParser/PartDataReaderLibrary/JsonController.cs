﻿using Newtonsoft.Json;
using PartDataReaderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary
{
    public class JsonController
	{
		#region - Fields & Properties

		#endregion

		#region - Constructors
		public JsonController( ) { }
        #endregion

        #region - Methods
        public static string ConvertObjectToString<T>( T convertObject ) where T : IJson
        {
            try
            {
                return JsonConvert.SerializeObject(convertObject, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ConvertStringToObject<T>( string input ) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveJsonToFolder<T>( string path, string fileName, T input )
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(path, fileName + ".json")))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    };
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(writer, input, input.GetType());
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T OpenJsonFile<T>( string path, string name )
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(path, name + ".json")))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    };
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    JsonTextReader jsonReader = new JsonTextReader(reader);
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
