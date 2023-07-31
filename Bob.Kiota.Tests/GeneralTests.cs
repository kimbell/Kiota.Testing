using Bob.Kiota.Client;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bob.Kiota.Tests
{
    public class GeneralTests
    {
        [Fact]
        public async Task SomeTest()
        {
            using (var ts = new TestScope())
            {
                var client = ts.Services.GetRequiredService<IExternalClient>();

                var response = await client.GetForecastAsync();

                Assert.NotNull(response);
            }
        }
    }
}
