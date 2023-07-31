using Bob.Kiota.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Bob.Kiota.Tests
{
    internal class TestScope : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services
                    .AddHttpClient("Bob")
                    .AddTypedClient<IExternalClient>(httpClient => new ExternalClient(httpClient))
                    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("http://unused"))
                    .ConfigurePrimaryHttpMessageHandler(_ => Server.CreateHandler());
            });
        }
    }
}
