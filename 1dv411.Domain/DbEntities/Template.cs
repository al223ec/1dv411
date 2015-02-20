using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Template : BaseDto
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public int NumberOfPartials { get; set; }
    }
}
