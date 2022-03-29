using ConsoleApp.Interfaces;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp
{
    internal class UseJsonNet : IJsonReaderWriter
    {
        public IJsonData? Read(string jsonStr) => JsonConvert.DeserializeObject<JsonData>(jsonStr);

        public string Serialize(IJsonData value) => JsonConvert.SerializeObject(value);

        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public record class JsonData : IJsonData
        {
            public string? StringData { get; set; }

            public decimal? NumricData { get; set; }

            [JsonProperty(Order = -2)]
            public decimal? OrderFirstNumericData { get; set; }

            [JsonProperty(Order = 2)]
            public decimal? OrderLastNumericData { get; set; }

            public List<decimal>? NumericArray { get; set; }

            public List<string>? StringArray { get; set; }
        }
    }
}
