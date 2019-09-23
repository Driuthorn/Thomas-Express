using SimpleInjector;

namespace ThomasExpressProducer.Infrastructure.IoC
{
    public static class ContainerExtensions
    {
        public static Container InjectDependencies(this Container container)
        {
            Bootstrapper.Inject(container);

            return container;
        }
    }
}
