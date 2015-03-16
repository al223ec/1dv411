using _1dv411.Domain;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1d411.ViewModel
{
    public class PageViewModel
    {

        public Page Page { get; set; }
        public List<PartialViewModel> Partials { get; set; }

    }

    public class PartialViewModel
    {
        public string PartialType { get; set; }

        public DiagramType? DiagramType { get; set; }

        public int Position { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }
        public string Align { get; set; }
        public string Valign { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public int FontSize { get; set; }
    }
}