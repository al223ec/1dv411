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
        public virtual Text Text { get; set; }

        public string Content { get; set; }

        public string Type 
        { 
            get 
            { 
                return _textType.ToString();  
            } 
        }
        private TextType _textType;
        public TextType TextType 
        { 
            set 
            { 
                _textType = value; 
            } 
        }
    }
}
