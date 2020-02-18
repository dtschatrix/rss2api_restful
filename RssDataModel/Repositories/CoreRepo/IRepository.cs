
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RssDataModel.Repositories
{
    public interface IRepository<T> where T: class
    {
        T GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);

        IEnumerable<TType> Get<TType>(Expression<Func<T, TType>> select) where TType : class;

    }
}
