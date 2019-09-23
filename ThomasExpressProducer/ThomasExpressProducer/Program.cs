using SimpleInjector;
using ThomasExpressProducer.Infrastructure.IoC;
using Topshelf;

namespace ThomasExpressProducer
{
    public static class Program
    {
        private static readonly Container container = new Container();

        static Program()
        {
            container.InjectDependencies();
        }


        static void Main(string[] args)
        {
            HostFactory.Run(host =>
            {
                host.Service<ThomasExpressProducerService>(s =>
                {
                    s.ConstructUsing(cs => container.GetInstance<ThomasExpressProducerService>());
                    s.WhenStarted(tep => tep.Start());
                    s.WhenStopped(tep => tep.Stop());
                });
                host.StartManually();
                host.RunAsLocalSystem();

                host.SetDescription("Serviço responsável por produzir dados da Thomas Express");
                host.SetDisplayName("Thomas Express - Producer");
                host.SetServiceName("Thomas Express - Producer");
                host.UseSerilog();
            });
        }
    }
}
