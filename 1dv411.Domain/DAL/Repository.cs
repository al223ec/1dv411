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
        private IApplicationContext _context;
        private DbSet<T> _set;

        public Repository(IApplicationContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,  string includeProperties = "")
        {
            IQueryable<T> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy == null ? query.ToList() : orderBy(query).ToList();
        }

        public T GetOne(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return orderBy == null ? query.FirstOrDefault() : orderBy(query).FirstOrDefault();
        }

        public T GetById(object id)
        {
            return _set.Find(id);
        }
        public bool Remove(object id)
        {
            T entityToDelete = _set.Find(id);
            _set.Remove(entityToDelete);
            return entityToDelete != null;
        }

        public void AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
            {
                entity.CreatedAt = DateTime.Now;
                entity.ModifiedAt = DateTime.Now; 
                _set.Add(entity);
            }
            else
            {
                entity.ModifiedAt = DateTime.Now; 
                _set.Attach(entity);
                _context.SetModified(entity);
            }
        }


        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }

    }
}