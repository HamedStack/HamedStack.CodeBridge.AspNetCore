using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamedStack.CodeBridge.AspNetCore
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class CodeBridgeEndpoint : Attribute
    {
        public CodeBridgeEndpoint(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(route));
            Route = route;
        }

        public string Route { get; }
    }
}
