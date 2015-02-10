using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseDto
    {
        private DbContext _context;
        private DbSet<T> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<T> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy == null ? query.ToList() : orderBy(query).ToList();
        }

        public T GetById(object id)
        {
            return _set.Find(id);
        }
        public void Remove(object id)
        {
            T entityToDelete = _set.Find(id);
            _set.Remove(entityToDelete);
        }

        public void AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
            {
                _set.Add(entity);
            }
            else
            {
                _set.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}