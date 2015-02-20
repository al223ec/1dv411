using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Screen : BaseDto
    {
        public string Name { get; set; }

        public int Timer { get; set; }

        [JsonIgnore]
        public virtual ICollection<PageScreen> PageScreens { get; set; }
    }
}
