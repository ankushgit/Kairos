using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kairos.MODEL;
namespace Kairos.DAL
{
    public interface IDbUnit : IDisposable
    {
        IRepository<Opportunity> Opportunities { get; }

        void Commit();
    }
}
