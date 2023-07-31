using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Bob.Kiota.Client2.Models {
    public class WeatherForecast : IParsable {
        /// <summary>The date property</summary>
        public DateTimeOffset? Date { get; set; }
        /// <summary>The summary property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Summary { get; set; }
#nullable restore
#else
        public string Summary { get; set; }
#endif
        /// <summary>The temperatureC property</summary>
        public int? TemperatureC { get; set; }
        /// <summary>The temperatureF property</summary>
        public int? TemperatureF { get; private set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static WeatherForecast CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WeatherForecast();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"date", n => { Date = n.GetDateTimeOffsetValue(); } },
                {"summary", n => { Summary = n.GetStringValue(); } },
                {"temperatureC", n => { TemperatureC = n.GetIntValue(); } },
                {"temperatureF", n => { TemperatureF = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("date", Date);
            writer.WriteStringValue("summary", Summary);
            writer.WriteIntValue("temperatureC", TemperatureC);
        }
    }
}
