using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Exceptions
{
    public class PartNotFoundException : Exception
    {
        public string PartName { get; set; }
        public PartNotFoundException( ) { }

        public PartNotFoundException( string message ) : base(message) { }
        public PartNotFoundException( string message, string partName ) : base(message)
        {
            PartName = partName;
        }

        public PartNotFoundException( string message, Exception innerException ) : base(message, innerException) { }
    }
}
