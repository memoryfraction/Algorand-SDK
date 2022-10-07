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
    public class AlgoAccountTests
    {
        string _apiKey = "";
        string _testAlgoAddress = "";
        string _lfoAssetId = "";
        string _reserveAddress = "";
        string _hostAddress = "";
        AlgoClientV2 _clientV2;

        public AlgoAccountTests()
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
        public async Task GetAccountInfo_Should_Work()
        {
            var accountInfoResponse = await _clientV2.GetAccountInformationAsync(_testAlgoAddress);
            var account = accountInfoResponse.Response == null ? null : (AlgoAccount)accountInfoResponse.Response;
            Assert.IsTrue(accountInfoResponse.Succeed);
            Assert.IsTrue(account.ActualBalance > 1);
        }

        [TestMethod]
        public async Task GetAccountAsset_Should_Work()
        {
            var lfoAccountAssetResponse = await _clientV2.GetAccountAssetAsync(_lfoAssetId, _testAlgoAddress);
            Assert.IsTrue(lfoAccountAssetResponse.Succeed);
            Assert.IsNotNull(lfoAccountAssetResponse.Response);
        }

    

    }
}
