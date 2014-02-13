using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.DAL
{
    /// <summary>
    /// Generic Repository interface
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindByID(int id);
        IQueryable<TEntity> FindAll();
    }
}
