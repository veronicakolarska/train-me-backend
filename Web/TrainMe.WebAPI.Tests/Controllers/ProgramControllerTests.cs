using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrainMe.WebAPI.Models;
using Xunit;

namespace TrainMe.WebAPI.Tests.Controllers
{
    public class ProgramControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProgramControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetNoPrograms()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/program");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var programs = JsonConvert.DeserializeObject<IEnumerable<ProgramViewModel>>(stringResponse);
            Assert.StrictEqual(0, programs.Count());

            // Assert.Contains(players, p => p.FirstName == "Wayne");
            // Assert.Contains(players, p => p.FirstName == "Mario");
        }
    }
}