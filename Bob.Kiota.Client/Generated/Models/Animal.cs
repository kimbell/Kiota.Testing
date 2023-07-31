using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Bob.Kiota.Client.Models {
    public class Animal : IParsable {
        /// <summary>The bob property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Bob { get; set; }
#nullable restore
#else
        public string Bob { get; set; }
#endif
        /// <summary>The chipStatus property</summary>
        public Bob.Kiota.Client.Models.ChipStatus? ChipStatus { get; set; }
        /// <summary>The name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Animal CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("bob")?.GetStringValue();
            return mappingValue switch {
                "c" => new Cat(),
                "d" => new Dog(),
                _ => new Animal(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bob", n => { Bob = n.GetStringValue(); } },
                {"chipStatus", n => { ChipStatus = n.GetEnumValue<ChipStatus>(); } },
                {"name", n => { Name = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("bob", Bob);
            writer.WriteEnumValue<ChipStatus>("chipStatus", ChipStatus);
            writer.WriteStringValue("name", Name);
        }
    }
}