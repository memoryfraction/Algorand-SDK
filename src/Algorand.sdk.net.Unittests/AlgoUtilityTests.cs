using Algorand.Dotnet;
using Algorand.SDK.Dotnet.Api;
using Algorand.SDK.Dotnet.Client;
using Microsoft.Extensions.Configuration;

namespace Algorand.sdk.Net.UnitTests
{
    [TestClass]
    public class AlgoUtilityTests
    {
        string _apiKey = "";
        string _testAlgoAddress = "";
        string _lfoAssetId = "";
        string _reserveAddress = "";
        string _hostAddress = "";
        AlgoClientV2 _clientV2;

        public AlgoUtilityTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AlgorandUnitTests>();
            var config = builder.Build();

            _apiKey = config["Configuration:ApiKey"];
            _testAlgoAddress = config["Configuration:TestAlgoAddress"];
            _lfoAssetId = config["Configuration:LFOAssetId"];
            _reserveAddress = config["Configuration:ReserveAddress"];
            _hostAddress = config["Configuration:HostAddress"];

            var algoApi = new AlgorandApiClient(_hostAddress);//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            _clientV2 = new AlgoClientV2(algoApi);
        }

        [TestMethod]
        public async Task Health_Should_Work()
        {
            var response = await _clientV2.GetHealthAsync();
            Assert.IsTrue(response.Succeed);
            Assert.IsTrue(response.Response.ToLower() == "ok");
        }

        [TestMethod]
        public async Task GetVersions_Should_Work()
        {
            var response = await _clientV2.GetVersionsAsync();
            Assert.IsTrue(response.Succeed);
            Assert.IsTrue(response.Response != null);
        }

        [TestMethod]
        public async Task GetStatus_Should_Work()
        {
            var response = await _clientV2.GetStatusAsync();
            Assert.IsTrue(response.Succeed);
            Assert.IsTrue(response.Response != null);
        }


    }
}
