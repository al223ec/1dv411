using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public enum TextType{

    }
    public class Text : BaseDto
    {
        public TextType Type { get; set; }
        
        [ForeignKey("Id")]
        public virtual Layout Layout { get; set; }
    }
}
