using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ThomasExpressProducer.Configuration.AppSettingsModels;

namespace ThomasExpressProducer.Configuration
{
    public class AppSettings
    {

        public static AppSettings Settings => ReadSettings<AppSettings>($"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json");

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

        #region Reader

        private static T ReadSettings<T>(string filename)
        {
            T returnObject;

            if (!File.Exists(filename))
                throw new Exception($"{filename} not found.");

            using (var reader = new StreamReader(filename))
            {
                var json = reader.ReadToEnd();
                returnObject = JsonConvert.DeserializeObject<T>(json);
            }

            return returnObject;
        }

        #endregion
    }
}
