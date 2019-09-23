using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThomasExpressProducer.Configuration.AppSettingsModels;
using ThomasExpressProducer.Configuration.Reader;

namespace ThomasExpressProducer.Configuration
{
    public class AppSettings
    {
        public static AppSettings Settings => AppSettingsReader.ReadSettings<AppSettings>($"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json");

        [JsonProperty("connectionSettings")]
        public List<ConnectionSettings> ConnectionSettings { get; set; }

        [JsonProperty("log")]
        public Log Log { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("rabbitMqSettings")]
        public RabbitMQSettings RabbitMqSettings { get; set; }

        [JsonProperty("basicProperties")]
        public BasicProperties BasicProperties { get; set; }

        [JsonProperty("applicationSettings")]
        public ApplicationSettings ApplicationSettings { get; set; }
    }
}
