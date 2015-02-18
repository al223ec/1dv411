using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IService<T> : IDisposable where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        //void AddOrUpdate(T entity); vet inte om denna kan användas
    }
}
