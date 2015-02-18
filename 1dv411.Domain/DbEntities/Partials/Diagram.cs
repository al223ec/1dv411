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
    public enum DiagramType
    {
        Week,
        Day,
        Month
    }
    public class Diagram : Partial
    {
        //TODO::Vilken info är nödvändig
        public int DiagramInfo { get; set; }
        public string Type { get { return this.DiagramType.ToString(); } }
       
        [JsonIgnore]
        public DiagramType? DiagramType { get; set; }
    }
}
