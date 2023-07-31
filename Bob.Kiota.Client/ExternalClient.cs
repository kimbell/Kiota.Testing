using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Bob.Kiota.Client
{
    public interface IExternalClient
    {
        Task<IEnumerable<Models.WeatherForecast>?> GetForecastAsync();
    }

    public class ExternalClient : IExternalClient
    {
        private readonly IAuthenticationProvider _authProvider = new AnonymousAuthenticationProvider();
        private readonly TypeClient _client;

        public ExternalClient(HttpClient httpClient)
        {
            var adapter = new HttpClientRequestAdapter(_authProvider, httpClient: httpClient);
            _client = new TypeClient(adapter);
        }

        public async Task<IEnumerable<Models.WeatherForecast>?> GetForecastAsync()
        {
            return await _client.WeatherForecast.Weather.GetAsync();
        }
    }
}
