using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Exceptions
{
    public class CraftException : Exception
    {
        public string Name { get; set; }
        public CraftException( ) { }
        public CraftException( string message ) : base(message) { }
        public CraftException( string message, string name ) : base(message)
        {
            Name = name;
        }
        public CraftException( string message, Exception innerException ) : base(message, innerException) { }
    }
}
