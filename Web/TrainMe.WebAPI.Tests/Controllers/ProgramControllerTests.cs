using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrainMe.WebAPI.Models;
using Xunit;

namespace TrainMe.WebAPI.Tests.Controllers
{
    public class ProgramControllerTests
    {
        public ProgramControllerTests()
        {
        }

        [Fact]
        public async Task GetNoPrograms()
        {
            // This is a dummy test for now
            Assert.True(true);
        }
    }
}