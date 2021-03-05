using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CicekSepeti.Core.Dependency;
using System;

namespace CicekSepeti.Core.Infrastructure
{
    public static class IocManager
    {
        private static WindsorContainer container;
        public static void Install()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(DependencyInstaller._assemblyDirectoryName, mask: DependencyInstaller._mask))
                    .BasedOn()
                    .WithServiceBase()
                    .LifestyleTransient());
            foreach (var item in container.ResolveAll<IWindsorInstaller>())
            {
                container.Install(item);
            }
        }
        #region Private Methods
        public static T Resolve<T>()
        {
            using (BeginScope())
            {
                return container.Resolve<T>();
            }
        }
        public static IDisposable BeginScope()
        {
            return container.BeginScope();
        }
        public static object Resolve(Type service)
        {
            return container.Resolve(service);
        }
        public static void Dispose()
        {
            container.Dispose();
        }
        public static T[] ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }
        public static void Release(object instance)
        {
            container.Release(instance);
        }
        #endregion
    }
}
