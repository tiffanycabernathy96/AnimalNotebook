using AnimalNotebook.Models;
using AnimalNotebook.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace AnimalNotebook
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //Use for In Memory Data 
            //builder.RegisterType<InMemoryAnimalData>()
            //       .As<IAnimalData>()
            //       .SingleInstance();
            builder.RegisterType<SqlAnimalData>()
                   .As<IAnimalData>()
                   .InstancePerRequest();
            builder.RegisterType<AnimalDBContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
