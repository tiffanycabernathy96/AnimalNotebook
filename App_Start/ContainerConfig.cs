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
            //builder.RegisterType<InMemoryAppointmentData>()
            //       .As<IAppointmentData>()
            //       .SingleInstance();
            //builder.RegisterType<InMemoryMedicineData>()
            //       .As<IMedicineData>()
            //       .SingleInstance();
            builder.RegisterType<SqlAnimalData>()
                   .As<IAnimalData>()
                   .InstancePerRequest();
            builder.RegisterType<AnimalDBContext>().InstancePerRequest();
            builder.RegisterType<SqlAppointmentData>()
                   .As<IAppointmentData>()
                   .InstancePerRequest();
            builder.RegisterType<AppointmentDBContext>().InstancePerRequest();
            builder.RegisterType<SqlMedicineData>()
                   .As<IMedicineData>()
                   .InstancePerRequest();
            builder.RegisterType<MedicineDBContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
