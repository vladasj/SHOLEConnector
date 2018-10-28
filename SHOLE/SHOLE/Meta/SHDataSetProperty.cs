using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOLE.Meta
{
    [AttributeUsage(AttributeTargets.Property)]
    class SHDataSetPropertyMeta: Attribute
    {
        public string PropertyCode { get; set; }

    }
}
