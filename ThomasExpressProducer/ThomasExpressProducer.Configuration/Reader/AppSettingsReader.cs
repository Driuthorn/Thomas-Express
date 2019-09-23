using Newtonsoft.Json;
using System;
using System.IO;

namespace ThomasExpressProducer.Configuration.Reader
{
    internal sealed class AppSettingsReader
    {
        public static T ReadSettings<T>(string filename)
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
    }
}
