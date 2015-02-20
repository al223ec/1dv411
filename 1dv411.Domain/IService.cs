using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IService<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);       
    }

}
