using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    private enum LayoutPartialType
    {

    }
    class LayoutPartial
    {
        public LayoutPartialType Type { get; set; }
        public virtual Layout Layout { get; set;  }
    }
}
