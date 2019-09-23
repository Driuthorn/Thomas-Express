using Newtonsoft.Json;

namespace ThomasExpressProducer.Configuration.AppSettingsModels
{
    public class ApplicationSettings
    {
        [JsonProperty("executionFrequency")]
        public int ExecutionFrequency { get; set; }
    }
}
