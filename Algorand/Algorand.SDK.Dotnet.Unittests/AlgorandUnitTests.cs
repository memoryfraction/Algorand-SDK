using Algorand.SDK.Dotnet.Api.Models;
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
        string _testAlgoAddress = "";
        string _lfoAssetId = "";
        String _reserveAddress = "";
        public AlgorandUnitTests()
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
        }

        [TestMethod]
        public async Task GetAccountInfo_Should_Work()
        {
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var accountInfoResponse = await algoClient.GetAccountInformationAsync(_testAlgoAddress);
            var account = accountInfoResponse.Response == null ? null : (AlgoAccount)accountInfoResponse.Response;
            Assert.IsTrue(account.ActualBalance > 1);
        }

        

        [TestMethod]
        public async Task GetAssetInfo_Should_Work()
        {
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var lfoAssetInfoResponse = await algoClient.GetAssetInformationAsync(_lfoAssetId);
            Assert.IsTrue(lfoAssetInfoResponse.Succeed);
            Assert.IsNotNull(lfoAssetInfoResponse.Response);
        }

        [TestMethod]
        public async Task GetAccountAsset_Should_Work()
        {
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var lfoAccountAssetResponse = await algoClient.GetAccountAssetAsync(_lfoAssetId,_testAlgoAddress);
            Assert.IsTrue(lfoAccountAssetResponse.Succeed);
            Assert.IsNotNull(lfoAccountAssetResponse.Response);
        }

        [TestMethod]
        public async Task GetAssetBalance_Should_Work()
        {
            // 1 get asset decimals
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var lfoAssetInfoResponse = await algoClient.GetAssetInformationAsync(_lfoAssetId);
            var decimals = lfoAssetInfoResponse.Response.Params.decimals;

            //2 get asset amount
            var lfoAccountAssetResponse = await algoClient.GetAccountAssetAsync(_lfoAssetId, _testAlgoAddress);

            //3 asset actual balance = amount / decimals
            lfoAccountAssetResponse.Response.Balance = (double)lfoAccountAssetResponse.Response.AssetHolding.amount / (double) (Math.Pow(10,decimals));
            Assert.IsTrue(lfoAccountAssetResponse.Response.Balance > 0);
        }

        [TestMethod]
        public async Task GetTotalCirculation_Should_Work()
        {
            //1 get total/ 10^decimal
            var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4
            algoApi.SetApiKey("X-API-Key", _apiKey);
            var algoClient = new AlgoClientV2(algoApi);

            var lfoAssetInfoResponse = await algoClient.GetAssetInformationAsync(_lfoAssetId);
            var decimals = lfoAssetInfoResponse.Response.Params.decimals;
            var total = lfoAssetInfoResponse.Response.Params.total;
            var totalLfoBalance = (double)total / (double)Math.Pow(10,decimals);

            //2 get amount from reserve account
            var reserveAddrLfoResponse = await algoClient.GetAccountAssetAsync(_lfoAssetId, _reserveAddress);
            reserveAddrLfoResponse.Response.Balance = (double)reserveAddrLfoResponse.Response.AssetHolding.amount / (double)(Math.Pow(10, decimals));

            //3 Circulation = Total - reserveBalance
            var ciraulation = totalLfoBalance - reserveAddrLfoResponse.Response.Balance;
            Assert.IsTrue(ciraulation > 20000);
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