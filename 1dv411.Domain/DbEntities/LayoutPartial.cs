using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public enum LayoutPartialType
    {
        Diagram,
        Text,
        Image
    }
    public class LayoutPartial : BaseDto
    {
        public LayoutPartialType Type { get; set; }
        public virtual Layout Layout { get; set; }
        public string Value { get; set; }

        //kan vara null tveksam om denna ska vara med
       // public virtual DiagramData DiagramData { get; set; }
    }
}
