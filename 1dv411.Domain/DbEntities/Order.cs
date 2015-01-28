using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    class Order : BaseDto
    {
        public string OrderGroupId { get; set; }
        public DateTime Created { get; set; }
    }
}
