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
        Heading,
        Paragraph,
        Footer,
    }

    public class TextContent : BaseDto
    {
        [JsonIgnore]
        [ForeignKey("Text")]
        [Column(Order = 2)]
        public int TextId { get; set; }

        [JsonIgnore]
        public Text Text { get; set; }

        public string Content { get; set; }

        public TextType TextType  { get; set; }

        public string Type 
        {
            get 
            { 
                return this.TextType.ToString(); 
            }
        }
    }
}
