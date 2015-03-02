using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Tests.Domain.DAL.TestDbSet
{
    public class TestPageDbSet : TestDbSet<Page>
    {
        public override Page Find(params object[] keyValues)
        {
            return this.SingleOrDefault(page => page.Id == (int)keyValues.Single());
        }
    }
}
