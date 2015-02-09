using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class LayoutScreen : BaseDto
    {
        [ForeignKey("Screen")]
        [Column(Order = 2)]
        public int ScreenId { get; set; }
        public Screen Screen { get; set; }
        
        [ForeignKey("Layout")]
        [Column(Order = 3)]
        public int LayoutId { get; set; }
        public Layout Layout { get; set; }
    }
}
