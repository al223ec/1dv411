﻿using Newtonsoft.Json;
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
       
        public override string PartialType { get { return "Text"; } }
    }
}
