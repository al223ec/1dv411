using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IDiagramService : IDisposable
    {
        IEnumerable<DiagramData> GetDiagramData(int numberOfDays);
        IEnumerable<DiagramData> GetDiagramDataThisWeek();
        IEnumerable<DiagramData> GetDiagramDataThisMonth();
    }
}
