using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Design : BaseDto
    {
        public virtual ICollection<Layout> Layout { get; set; }
        public int NumberOfFields { get; set; }
    }
}
