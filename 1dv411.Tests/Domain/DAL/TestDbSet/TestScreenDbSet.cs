using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Tests.Domain.DAL
{
    public class TestScreenDbSet : TestDbSet<Screen>
    {
        public override Screen Find(params object[] keyValues)
        {
            return this.SingleOrDefault(screen => screen.Id == (int)keyValues.Single());
        }
    }
}
