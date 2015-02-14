using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    [JsonObject(Title = "Text")]
    public class Text : Partial
    {
        public override string PartialType { get { return "Text"; } }
        public string Heading { get; set; }
        public string Footer { get; set; }
        public IEnumerable<string> Paragraphs { get; set; }

    }
}
