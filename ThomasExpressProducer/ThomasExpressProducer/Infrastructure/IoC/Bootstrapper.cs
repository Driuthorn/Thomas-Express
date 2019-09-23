using Serilog;
using SimpleInjector;
using ThomasExpressProducer.Configuration;

namespace ThomasExpressProducer.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void Inject(Container container)
        {
            InjectLog(container);
        }

        private static void InjectLog(Container container)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("ApplicationName", AppSettings.Settings.Info.Title)
                .ReadFrom.AppSettings()
                .WriteTo.Console()
                .CreateLogger();

            container.Register(() => Log.Logger, Lifestyle.Singleton);
        }
    }
}
