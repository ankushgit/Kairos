using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Kairos.DAL;

namespace Kairos.WEB
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = buildContainer();
            
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static UnityContainer buildContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDbUnit, DbUnit>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}