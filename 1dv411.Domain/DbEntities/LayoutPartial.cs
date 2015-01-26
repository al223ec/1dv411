using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public enum LayoutPartialType
    {

    }
    class LayoutPartial : BaseDto
    {
        public LayoutPartialType Type { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
