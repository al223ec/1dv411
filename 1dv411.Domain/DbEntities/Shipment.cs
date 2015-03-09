using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Shipment : BaseDto
    {
        [Index]
        public String No_ { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime PostingDate { get; set; }
    }
}
