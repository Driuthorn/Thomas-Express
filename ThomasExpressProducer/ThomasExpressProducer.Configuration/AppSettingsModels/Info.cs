using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class Info
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
