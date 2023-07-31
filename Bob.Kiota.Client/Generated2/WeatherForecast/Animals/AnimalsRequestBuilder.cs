using Bob.Kiota.Client2.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Bob.Kiota.Client2.WeatherForecast.Animals {
    /// <summary>
    /// Builds and executes requests for operations under \WeatherForecast\animals
    /// </summary>
    public class AnimalsRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new AnimalsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AnimalsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/WeatherForecast/animals", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new AnimalsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AnimalsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/WeatherForecast/animals", rawUrl) {
        }
        /// <summary>
        /// Gets animals
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<Animals>?> GetAsync(Action<AnimalsRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<List<Animals>> GetAsync(Action<AnimalsRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<Animals>(requestInfo, Animals.CreateFromDiscriminatorValue, default, cancellationToken);
            return collectionResult?.ToList();
        }
        /// <summary>
        /// Gets animals
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<AnimalsRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<AnimalsRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new AnimalsRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Composed type wrapper for classes Animal, Dog, Cat
        /// </summary>
        public class Animals : IComposedTypeWrapper, IParsable {
            /// <summary>Composed type representation for type Animal</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Bob.Kiota.Client2.Models.Animal? Animal { get; set; }
#nullable restore
#else
            public Bob.Kiota.Client2.Models.Animal Animal { get; set; }
#endif
            /// <summary>Composed type representation for type Cat</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Bob.Kiota.Client2.Models.Cat? Cat { get; set; }
#nullable restore
#else
            public Bob.Kiota.Client2.Models.Cat Cat { get; set; }
#endif
            /// <summary>Composed type representation for type Dog</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Bob.Kiota.Client2.Models.Dog? Dog { get; set; }
#nullable restore
#else
            public Bob.Kiota.Client2.Models.Dog Dog { get; set; }
#endif
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static Animals CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("bob")?.GetStringValue();
                var result = new Animals();
                if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.Animal = new Bob.Kiota.Client2.Models.Animal();
                }
                else if("c".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.Cat = new Bob.Kiota.Client2.Models.Cat();
                }
                else if("d".Equals(mappingValue, StringComparison.OrdinalIgnoreCase)) {
                    result.Dog = new Bob.Kiota.Client2.Models.Dog();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                if(Animal != null) {
                    return Animal.GetFieldDeserializers();
                }
                else if(Cat != null) {
                    return Cat.GetFieldDeserializers();
                }
                else if(Dog != null) {
                    return Dog.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(Animal != null) {
                    writer.WriteObjectValue<Bob.Kiota.Client2.Models.Animal>(null, Animal);
                }
                else if(Cat != null) {
                    writer.WriteObjectValue<Bob.Kiota.Client2.Models.Cat>(null, Cat);
                }
                else if(Dog != null) {
                    writer.WriteObjectValue<Bob.Kiota.Client2.Models.Dog>(null, Dog);
                }
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class AnimalsRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new animalsRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public AnimalsRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
