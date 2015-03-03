﻿using Newtonsoft.Json;
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
        Month,
        Quarter,
        Year
    }
    public class Diagram : Partial
    {
        //TODO::Vilken info är nödvändig
        public int DiagramInfo { get; set; }
        public string Type { get { return this.DiagramType.ToString(); } }

        public virtual IEnumerable<DiagramData> Data { get; set; }
        [JsonIgnore]
        public DiagramType? DiagramType { get; set; }


        public override string PartialType { get { return "Diagram"; } }
    }
}
