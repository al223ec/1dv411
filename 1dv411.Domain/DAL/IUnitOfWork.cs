using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<DiagramData> DiagramDataRepository { get; }
        void Save();
    }
}
