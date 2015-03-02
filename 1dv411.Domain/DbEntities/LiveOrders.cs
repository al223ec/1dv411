using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    [Table("PurchaseOrders")]
    public class LiveOrder
    {
        [Key]
        public Guid OrderGroupId { get; set; }

        [Column("Created")]
        public DateTime Created { get; set; }
    }
}
