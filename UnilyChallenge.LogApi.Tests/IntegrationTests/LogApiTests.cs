using System;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace UnilyChallenge.LogApi.Tests.IntegrationTests
{
    public class LogApiTests
    {

        [Fact]
        public async Task WriteLogEndpointTest()
        {
            // Arrange
            //var appSettings = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");  // use integration test specific appsettings
            var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "unilychallenge.log");
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    //webHost.ConfigureAppConfiguration((context, config) =>
                    //{
                    //    config.AddJsonFile(appSettings);
                    //});
                    webHost.UseStartup<UnilyChallenge.LogApi.Startup>();
                });

            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            // Act
            var timeStamp = DateTime.Now;
            var json = $"{{\"Id\": \"{Guid.Empty}\",\"Timestamp\": \"{timeStamp:s}\",\"Message\": \"Lorem ipsum dolor sit amet sanct tetur.\"}}";
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/log", content);
            
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.True(File.Exists(logFilePath));
            //TODO: assert on file contents

            // Teardown
            File.Delete(logFilePath);
        }
    }
}
