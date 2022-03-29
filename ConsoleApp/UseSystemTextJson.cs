using ConsoleApp.Interfaces;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp
{
    internal class UseSystemTextJson : IJsonReaderWriter
    {
        readonly JsonSerializerOptions _serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public IJsonData? Read(string jsonStr) => JsonSerializer.Deserialize<JsonData>(jsonStr, _serializeOptions);

        public string Serialize(IJsonData value) => JsonSerializer.Serialize(value, _serializeOptions);

        public record class JsonData : IJsonData
        {
            public string? StringData { get; set; }

            public decimal? NumricData { get; set; }

            /////////////////////////////////////////////////
            ////// JsonPropertyOrder が何故か無視される？？？？？
            /////////////////////////////////////////////////

            [JsonPropertyOrder(-2)]
            public decimal? OrderFirstNumericData { get; set; }

            [JsonPropertyOrder(100)]
            public decimal? OrderLastNumericData { get; set; }

            public List<decimal>? NumericArray { get; set; }

            public List<string>? StringArray { get; set; }
        }
    }
}
