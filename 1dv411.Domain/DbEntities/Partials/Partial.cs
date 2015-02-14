using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public abstract class Partial : BaseDto
    {
        [JsonIgnore]
        [ForeignKey("Layout")]
        [Column(Order = 2)]
        public int LayoutId { get; set; }

        [JsonIgnore]
        public virtual Layout Layout { get; set; }

        public int Position { get; set; }

        //Detta borde kunna lösas med reflektion också tex.  this.getType().Name; 
        public abstract string PartialType { get; }
    }
}
