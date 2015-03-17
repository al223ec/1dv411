using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Order : BaseDto
    {
        [Index]
        public Guid OrderGroupId { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Date { get; set; }
    }
}
