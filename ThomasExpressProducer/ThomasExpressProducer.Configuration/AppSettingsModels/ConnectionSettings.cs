using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class ConnectionSettings
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

    }
}
