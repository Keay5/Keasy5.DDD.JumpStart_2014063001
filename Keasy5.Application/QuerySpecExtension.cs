using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteartRetail.DataObjects;

namespace Keasy5.Application
{
    public static class QuerySpecExtension
    {
        public static bool IsVerbose(this QuerySpec spec)
        {
            return spec.Verbose ?? false;
        }
    }
}
