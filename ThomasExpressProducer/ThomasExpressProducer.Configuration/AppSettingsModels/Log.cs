using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class Log
    {
        [JsonProperty("console")]
        public Console Console { get; set; }
    }
}
