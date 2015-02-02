using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public abstract class BaseDto
    {
        [Key]
        [Column(Order = 1)] 
        public int Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreatedAt { get; set; }
        
        [Column(TypeName = "DateTime2")]
        public DateTime ModifiedAt { get; set; }

    }
}
