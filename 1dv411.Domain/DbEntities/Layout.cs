using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public enum LayoutType 
    {
    }
    class Layout : BaseDto
    {
        public LayoutType Type { get; set; }
        public virtual ICollection<LayoutPartial> LayoutPartials { get; set; }
    }
}
