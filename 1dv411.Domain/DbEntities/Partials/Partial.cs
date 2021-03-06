﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public abstract class Partial : BaseDto
    {
        [JsonIgnore]
        [ForeignKey("Page")]
        [Column(Order = 2)]
        public int PageId { get; set; }

        [JsonIgnore]
        public virtual Page Page { get; set; }

        public int Position { get; set; }
        public string Align { get; set; }
        public string Valign { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public int FontSize { get; set; }

        public abstract string PartialType { get; }

    }
}
