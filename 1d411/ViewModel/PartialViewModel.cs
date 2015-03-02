using _1dv411.Domain;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1d411.ViewModel
{
    public class PartialViewModel
    {

        public Page page { get; set; }
        public List<Partial> Partials { get; set; }
    }
}