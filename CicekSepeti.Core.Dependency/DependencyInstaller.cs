using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CicekSepeti.Core.Dependency
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public const string _mask = "CicekSepeti.*";
        public const string _assemblyDirectoryName = "";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(_assemblyDirectoryName, mask: _mask);
            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter).BasedOn()
                    .Configure(p => p.LifestyleScoped()
                    ));
        }
    }
}
