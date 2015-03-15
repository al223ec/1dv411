using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Text : Partial
    {
        public string Content { get; set; }
        public string Align { get; set; }
        public string Valign { get; set; }
        public bool  Bold { get; set; }
        public bool Italic { get; set; }
        public int FontSize { get; set; }
        public override string PartialType { get { return "Text"; } }
    }
}
