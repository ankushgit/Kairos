using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kairos.MODEL;
using System.Data.Entity;
namespace Kairos.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private DbContext _dbContext;

        public Repository(DbContext context)
        {
            _dbContext = context;
        }

        private IDbSet<TEntity> DbSet
        {
            get { return _dbContext.Set<TEntity>(); }
        }


        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity FindByID(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return DbSet;
        }
    }
}
