using Algorand.SDK.Dotnet.Api;
using Algorand.SDK.Dotnet.Api.Models;
using Algorand.SDK.Dotnet.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorand.sdk.Net.UnitTests
{
    [TestClass]
    public class AlgoTransactionsTests
    {
        string _apiKey = "";
        string _testAlgoAddress = "";
        string _lfoAssetId = "";
        string _reserveAddress = "";
        string _hostAddress = "";
        AlgoClientV2 _clientV2;

        public AlgoTransactionsTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AlgoIntegratedTests>();
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
        public async Task GetTransactionsParams_Should_Work()
        {
            var response = await _clientV2.GetTransactionsParamsAsync();
            Assert.IsTrue(response.Succeed);
            Assert.IsNotNull(response.Response);
        }

        [TestMethod]
        public async Task GetTransactionsPending_Should_Work()
        {
            var response = await _clientV2.GetTransactionsPendingAsync();
            Assert.IsTrue(response.Succeed);
            Assert.IsNotNull(response.Response);
        }



    }
}
