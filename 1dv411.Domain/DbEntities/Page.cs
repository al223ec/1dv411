using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Page : BaseDto
    {
        [JsonIgnore]
        [ForeignKey("Template")]
        [Column(Order = 2)]
        public int TemplateId { get; set; }

        public virtual Template Template { get; set; }

        public string Name { get; set; }


        public virtual ICollection<Partial> Partials { get; set; }

        [JsonIgnore]
        //Json kan inte hantera detta just nu, därav jsonIgnore, leder till ett StackOverflow exception antagligen problem med att definera relation layout screen
        public virtual ICollection<PageScreen> PageScreens { get; set; }
    }
}
