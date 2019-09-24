using ThomasExpressProducer.Configuration;

namespace ThomasExpressProducer.RabbitMq
{
    public class BasicPropertiesConfiguration
    {
        public string Expiration { get; private set; }
        public bool Persistent { get; private set; }

        public BasicPropertiesConfiguration()
        {
            Expiration = AppSettings.Settings.BasicProperties.Expiration;
            Persistent = AppSettings.Settings.BasicProperties.Persistent;
        }
    }
}
