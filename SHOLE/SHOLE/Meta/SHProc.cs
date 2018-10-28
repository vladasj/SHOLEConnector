using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOLE.Meta
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct)]
    class SHProcMeta: Attribute
    {
        public string Name { get; set; }
    }
}
