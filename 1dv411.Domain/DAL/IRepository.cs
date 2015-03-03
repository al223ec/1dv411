using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public interface IRepository<T> where T : BaseDto
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);
        T GetOne(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        void Remove(object id);
        void AddOrUpdate(T entity);
        int Count(Expression<Func<T, bool>> filter = null);
    }
}
