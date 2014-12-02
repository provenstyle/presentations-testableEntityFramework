using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Data.Mappings;
using Highway.Data;

namespace Web.DI
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.AppSettings["connectionString"];

            container.Register(
                Component
                    .For<IMappingConfiguration>()
                    .ImplementedBy<ConferenceDemoMappingConfiguration>()
                    .LifestyleSingleton(),
                Component
                    .For<IDataContext>()
                    .ImplementedBy<DataContext>()
                    .DependsOn(new {ConnectionString = connectionString})
                    .LifestyleTransient(),
                Component
                    .For<IRepository>()
                    .ImplementedBy<Repository>()
                    .LifestyleTransient();
            );
        }
    }
}