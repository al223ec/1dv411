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
    [JsonObject(Title = "Diagram")]
    public class Diagram : Partial
    {
        public override string PartialType { get { return "Diagram"; } }
        public int DiagramInfo { get; set; }
    }
}
