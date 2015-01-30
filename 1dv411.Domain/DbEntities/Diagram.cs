using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Diagram : BaseDto
    {
        public int LayoutId { get; set;  }
        [ForeignKey("LayoutId")]
        public virtual Layout Layout { get; set; }
    }
}
