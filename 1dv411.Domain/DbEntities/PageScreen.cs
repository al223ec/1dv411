using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class PageScreen : BaseDto
    {
        [ForeignKey("Screen")]
        [Column(Order = 2)]
        public int ScreenId { get; set; }
        public virtual Screen Screen { get; set; }
        
        [ForeignKey("Page")]
        [Column(Order = 3)]
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
