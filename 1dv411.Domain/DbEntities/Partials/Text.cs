using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public enum TextType
    {
        String,
        Header
    }
    public class Text : Partial
    {
        public TextType Type { get; set; }
        public string Value { get; set; }

    }
}
