using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RssDataModel.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private DbSet<T> _contextSet;

        protected Repository(DbContext context)
        {
            Context = context;
            _contextSet = context.Set<T>();
        }
        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _contextSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public T GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).FirstOrDefault();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _contextSet.Where(predicate);
        }
        public Task Add(T entity)
        {
            return Task.Run(() => _contextSet.Add(entity));
        }
        public Task AddRange(IEnumerable<T> entity)
        {
            return Task.Run(() => _contextSet.AddRange(entity));
        }
        public IEnumerable<TType> Select<TType>(Expression<Func<T, TType>> select) where TType : class
        {
            return _contextSet.Select(select).ToList();
        }
    }
}
