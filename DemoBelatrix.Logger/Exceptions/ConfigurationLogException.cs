using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    [Serializable()]
    public class ConfigurationLogException : System.Exception
    {
        public ConfigurationLogException() : base() { }
        public ConfigurationLogException(string message) : base(message) { }
        public ConfigurationLogException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ConfigurationLogException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
