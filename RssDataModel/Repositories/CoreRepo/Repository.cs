using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RssDataModel.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private DbSet<T> _contextSet;

        public Repository(DbContext context)
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
        public T GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties )
        {
            var query = Include(includeProperties);
            return query.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _contextSet.Where(predicate);
        }

        public async Task Add(T entity)
        {
            _contextSet.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            _contextSet.AddRange(entity);
            await Context.SaveChangesAsync();
        }


        public IEnumerable<TType> Get<TType>(Expression<Func<T, TType>> select) where TType : class
        {
            return _contextSet.Select(select).ToList();
        }
    }
}
