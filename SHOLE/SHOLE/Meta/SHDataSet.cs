using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOLE.Meta
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.Property)]
    class SHDataSetMeta: Attribute
    {
        public int DSIndex { get; set; }
        public bool IsInput { get; set; }
    }
}
