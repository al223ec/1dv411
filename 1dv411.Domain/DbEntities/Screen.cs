using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    class Screen : BaseDto
    {
        public string Name { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
