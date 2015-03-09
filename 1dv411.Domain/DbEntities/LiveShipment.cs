using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    [Table("Scand_ Design Online AB$Sales Shipment Header")]
    public class LiveShipment
    {
        [Key]
        public String No_ { get; set; }
        [Column("Posting Date")]
        public DateTime PostingDate { get; set; }
    }
}
