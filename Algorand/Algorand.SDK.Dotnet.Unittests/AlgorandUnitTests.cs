using Algorand.SDK.Dotnet.Client;
using Algorand.Tools.Api;
using Algorand.Tools.Api.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Algorand.Dotnet
{
    [TestClass]
    public class AlgorandUnitTests
    {
        string _apiKey = "";
        string _rexAlgoAddress = "";
        string _lfoAssetId = "";
        public AlgorandUnitTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AlgorandUnitTests>();
            var config = builder.Build();

            _apiKey = config["Configuration:ApiKey"];
            _rexAlgoAddress = config["Configuration:RexAlgoAddress"];
            _lfoAssetId = config["Configuration:LFOAssetId"];
        }

        [TestMethod]
        public async Task GetAlgoAccountInfo_Should_Work()
        {
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var version = algoClient.GetVersionAsync().Result;
            var health = algoClient.GetHealthAsync().Result;
            var accountResponse = await algoClient.GetAccountInformationAsync(_rexAlgoAddress);
            var account = accountResponse.Response == null ? null : (AlgoAccount)accountResponse.Response;
            Assert.IsTrue(account.ActualBalance > 1);
        }

        [TestMethod]
        public void TypeConvert_Should_Work()
        {
            long amount = 247082437;
            double actualAmount = amount / 1000000.0;
            Assert.IsTrue(actualAmount > 0);
        }

        [TestMethod]
        public async Task GetAsset_Should_Work()
        {
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var lfoAssetResponse = await algoClient.GetAssetInformationAsync(_lfoAssetId);
            Assert.IsTrue(lfoAssetResponse.Succeed);
            Assert.IsNotNull(lfoAssetResponse.Response);
        }

        [TestMethod]
        public async Task GetAssetBalance_Should_Work()
        {
            //var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            //algoApi.SetApiKey("X-API-Key", _apiKey);
            //var algoClient = new AlgoClientV2(algoApi);

            //var lfoAssetResponse = await algoClient.GetAssetInformationAsync(_lfoAssetId);
            //Assert.IsTrue(lfoAssetResponse.Succeed);
            //Assert.IsNotNull(lfoAssetResponse.Response);

            //Todo 1 get asset decimals
            //Todo 2 get asset amount
            //todo 3 asset actual balance = amount / decimals
        }

        [TestMethod]
        public void Deserialize_Should_Work()
        {
            var responseStr = "{\"index\":721366337,\"params\":{\"clawback\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"creator\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"decimals\":4,\"default-frozen\":false,\"freeze\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"manager\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"name\":\"LeaderFundOne\",\"name-b64\":\"TGVhZGVyRnVuZE9uZQ==\",\"reserve\":\"FYVAOJZDQFCRTW6J4HRD6N3ZIHROQOA75KEBEUSADZPLNFNHDS5MHTDG5Y\",\"total\":10000000000000,\"unit-name\":\"LFO\",\"unit-name-b64\":\"TEZP\"}}\r\n";
            var asset = JsonConvert.DeserializeObject<Asset>(responseStr);
            Assert.IsNotNull(asset);
        }

    }
}