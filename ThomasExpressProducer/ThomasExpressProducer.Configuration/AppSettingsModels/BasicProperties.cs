using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class BasicProperties
    {
        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("persistent")]
        public bool Persistent { get; set; }
    }
}
