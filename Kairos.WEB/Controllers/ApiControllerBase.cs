using Kairos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kairos.WEB.Controllers
{
    /// <summary>
    /// Base Class for all the ApiControllers
    /// Declares the IDbUnit and makes sure it is disposed.
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        protected IDbUnit _dbUnit;
        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_dbUnit != null)
                        _dbUnit.Dispose();
                }
                disposed = true;
            }
            base.Dispose(disposing);
        }
        
    }
}