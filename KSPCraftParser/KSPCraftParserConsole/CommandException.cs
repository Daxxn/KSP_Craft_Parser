using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KSPCraftParserConsole
{
    public class CommandException : Exception
    {
        public string BadInput { get; set; }
        public CommandException( ) { }

        public CommandException( string message ) : base(message) { }
        public CommandException( string message, string input ) : base(message)
        {
            BadInput = input;
        }

        public CommandException( string message, Exception innerException ) : base(message, innerException) { }
    }
}
