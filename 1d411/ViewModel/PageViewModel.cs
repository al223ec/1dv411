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

        public List<TextContent> TextContents { get; set; }
    }
}