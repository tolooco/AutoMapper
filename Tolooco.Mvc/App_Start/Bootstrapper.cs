using Autofac;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Tolooco.Data.DatabaseContext;
using Tolooco.Data.Infrastructure;
using Tolooco.Data.Repositories;
using Tolooco.Mvc.AutoMaaper;
using Tolooco.Service;

namespace Tolooco.Mvc.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork<FirstDb>>().As<IUnitOfWork<FirstDb>>().InstancePerRequest();
            builder.RegisterType<DbFactory<FirstDb>>().As<IDbFactory<FirstDb>>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}