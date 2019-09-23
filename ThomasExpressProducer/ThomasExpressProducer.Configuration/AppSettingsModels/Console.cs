using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class Console
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("minimumLevel")]
        public string MinimumLevel { get; set; }
    }
}
