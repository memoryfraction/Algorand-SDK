using Algorand.Dotnet;
using Algorand.SDK.Dotnet.Api;
using Algorand.SDK.Dotnet.Api.Models;
using Algorand.SDK.Dotnet.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

        [TestMethod]
        public void Deserialize_AccountInfo_Should_Work()
        {
            var responseStr = "{\"index\":721366337,\"params\":{\"clawback\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"creator\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"decimals\":4,\"default-frozen\":false,\"freeze\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"manager\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"name\":\"LeaderFundOne\",\"name-b64\":\"TGVhZGVyRnVuZE9uZQ==\",\"reserve\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"total\":10000000000000,\"unit-name\":\"LFO\",\"unit-name-b64\":\"TEZP\"}}\r\n";
            var assetInfo = JsonConvert.DeserializeObject<AssetInfo>(responseStr);
            Assert.IsNotNull(assetInfo);
        }

        [TestMethod]
        public void Deserialize_AccountAsset_Should_Work()
        {
            var responseStr = "{\"asset-holding\":{\"amount\":1292580000,\"asset-id\":721366337,\"is-frozen\":false},\"round\":23880100}\n";
            var accountAsset = JsonConvert.DeserializeObject<AccountAsset>(responseStr);
            Assert.IsNotNull(accountAsset);
        }

        [TestMethod]
        public void TypeConvert_Should_Work()
        {
            long amount = 247082437;
            double actualAmount = amount / 1000000.0;
            Assert.IsTrue(actualAmount > 0);
        }

    }
}
