using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Image : BaseDto
    {
        [ForeignKey("Layout")]
        [Column(Order = 2)] 
        public int LayoutId { get; set; }

        public virtual Layout Layout { get; set; }
        public string Url { get; set; }
    }
}
