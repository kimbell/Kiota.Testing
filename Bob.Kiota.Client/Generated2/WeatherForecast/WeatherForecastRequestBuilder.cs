using Bob.Kiota.Client2.WeatherForecast.Animals;
using Bob.Kiota.Client2.WeatherForecast.EchoAnimals;
using Bob.Kiota.Client2.WeatherForecast.Weather;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace Bob.Kiota.Client2.WeatherForecast {
    /// <summary>
    /// Builds and executes requests for operations under \WeatherForecast
    /// </summary>
    public class WeatherForecastRequestBuilder : BaseRequestBuilder {
        /// <summary>The animals property</summary>
        public AnimalsRequestBuilder Animals { get =>
            new AnimalsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The echoAnimals property</summary>
        public EchoAnimalsRequestBuilder EchoAnimals { get =>
            new EchoAnimalsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The weather property</summary>
        public WeatherRequestBuilder Weather { get =>
            new WeatherRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new WeatherForecastRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WeatherForecastRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/WeatherForecast", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WeatherForecastRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WeatherForecastRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/WeatherForecast", rawUrl) {
        }
    }
}
