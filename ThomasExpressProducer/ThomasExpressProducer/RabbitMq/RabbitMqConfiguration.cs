using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasExpressProducer.Configuration;

namespace ThomasExpressProducer.RabbitMq
{
    public class RabbitMqConfiguration
    {
        public string Host { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int Port { get; private set; }
        public ushort RequestHeartBeatInSeconds { get; private set; }
        public string VirtualHost { get; private set; }
        public string Exchange { get; private set; }
        public string Queue { get; private set; }
        public string ConnectionName { get; private set; }

        public RabbitMqConfiguration()
        {
            Host = AppSettings.Settings.RabbitMqSettings.Host;
            UserName = AppSettings.Settings.RabbitMqSettings.UserName;
            Password = AppSettings.Settings.RabbitMqSettings.Password;
            Port = AppSettings.Settings.RabbitMqSettings.Port;
            RequestHeartBeatInSeconds = AppSettings.Settings.RabbitMqSettings.RequestHeartBeatInSeconds;
            VirtualHost = AppSettings.Settings.RabbitMqSettings.VirtualHost;
            Exchange = AppSettings.Settings.RabbitMqSettings.Exchange;
            Queue = AppSettings.Settings.RabbitMqSettings.Queue;
            ConnectionName = AppSettings.Settings.RabbitMqSettings.ConnectionName;
        }
    }
}
