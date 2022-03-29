using ConsoleApp.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class UseDataContractJsonSerializor : IJsonReaderWriter
    {
        public IJsonData? Read(string jsonStr)
        {
            using var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonStr));
            var serializer = new DataContractJsonSerializer(typeof(JsonData));
            if (ms is not null)
            {
                var data = (JsonData?)serializer?.ReadObject(ms);
                if (data is not null)
                {
                    return data;
                }
            }
            return null;
        }

        public string Serialize(IJsonData value)
        {
            using var stream = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(JsonData));
            serializer.WriteObject(stream, value);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        [DataContract]
        public record class JsonData : IJsonData
        {
            [DataMember(Name = "stringData", Order = 1)]
            public string? StringData { get; set; }

            [DataMember(Name = "numericData", Order = 2)]
            public decimal? NumricData { get; set; }

            [DataMember(Name = "orderFirstNumericData", Order = 0)]
            public decimal? OrderFirstNumericData { get; set; }

            [DataMember(Name = "orderLastNumericData", Order = 99)]
            public decimal? OrderLastNumericData { get; set; }

            [DataMember(Name = "numericArray", Order = 3)]
            public List<decimal>? NumericArray { get; set; }

            [DataMember(Name = "stringArray", Order = 4)]
            public List<string>? StringArray { get; set; }
        }
    }

}
