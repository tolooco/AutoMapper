using Tolooco.Mvc.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tolooco.Data.SeedData;

namespace Tolooco.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Init database
            System.Data.Entity.Database.SetInitializer(new SeedFirstDb());

            // Autofac and Automapper configurations
            Bootstrapper.Run();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
