using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Layout : BaseDto
    {
        public string Name { get; set; }
        
        [ForeignKey("Design")]
        [Column(Order = 2)] 
        public int DesignId { get; set; }

        public virtual Design Design { get; set; }
        
        public virtual ICollection<Diagram> Diagrams { get; set; }

        public virtual ICollection<Text> Texts{ get; set; }

        public virtual ICollection<Image> Images{ get; set; }
    }
}
