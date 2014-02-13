using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kairos.MODEL;
namespace Kairos.DAL
{
    public class DbUnit : IDbUnit
    {
        private KairosDbContext _dbContext = new KairosDbContext();
        private Repository<Opportunity> _opportunityRepo;
        private Repository<Project> _projectRepo;

        public IRepository<Opportunity> Opportunities
        {
            get 
            {
                if (_opportunityRepo == null)
                    _opportunityRepo = new Repository<Opportunity>(_dbContext);
                return _opportunityRepo;                
            }
        }

        public IRepository<Project> Projects
        {
            get 
            {
                if (_projectRepo == null)
                    _projectRepo = new Repository<Project>(_dbContext);
                return _projectRepo;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #region
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                        _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
