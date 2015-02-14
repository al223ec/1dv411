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
    public class Layout : BaseDto
    {
        public string Name { get; set; }
        public string TemplateUrl { get; set; }
        public ICollection<Partial> Partials { get; set; }

        [JsonIgnore]
        //Json kan inte hantera detta just nu, därav jsonIgnore, leder till ett StackOverflow exception antagligen problem med att definera relation layout screen
        public virtual ICollection<LayoutScreen> LayoutScreens { get; set; }
    }
}
