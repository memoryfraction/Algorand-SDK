using Algorand.SDK.Dotnet.Client;
using Algorand.SDK.Dotnet.Api;
using Microsoft.Extensions.Configuration;

namespace Algorand.sdk.Net.UnitTests
{
    [TestClass]
    public class AlgoIntegratedTests
    {
        string _apiKey = "";
        string _testAlgoAddress = "";
        string _lfoAssetId = "";
        string _reserveAddress = "";
        string _hostAddress = "";
        AlgoClientV2 _clientV2;

        public AlgoIntegratedTests()
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
        public async Task GetAssetBalance_Should_Work()
        {
            // 1 get asset decimals
            var lfoAssetInfoResponse = await _clientV2.GetAssetInformationAsync(_lfoAssetId);
            var decimals = lfoAssetInfoResponse.Response.@params.decimals;

            //2 get asset amount
            var lfoAccountAssetResponse = await _clientV2.GetAccountAssetAsync(_lfoAssetId, _testAlgoAddress);

            //3 asset actual balance = amount / decimals
            lfoAccountAssetResponse.Response.Balance = (double)lfoAccountAssetResponse.Response.AssetHolding.amount / (double) (Math.Pow(10,decimals));
            Assert.IsTrue(lfoAccountAssetResponse.Response.Balance > 0);
        }



        [TestMethod]
        public async Task GetTotalCirculation_Should_Work()
        {
            //1 get total/ 10^decimal
            var lfoAssetInfoResponse = await _clientV2.GetAssetInformationAsync(_lfoAssetId);
            var decimals = lfoAssetInfoResponse.Response.@params.decimals;
            var total = lfoAssetInfoResponse.Response.@params.total;
            var totalLfoBalance = (double)total / (double)Math.Pow(10,decimals);

            //2 get amount from reserve account
            var reserveAddrLfoResponse = await _clientV2.GetAccountAssetAsync(_lfoAssetId, _reserveAddress);
            reserveAddrLfoResponse.Response.Balance = (double)reserveAddrLfoResponse.Response.AssetHolding.amount / (double)(Math.Pow(10, decimals));

            //3 Circulation = Total - reserveBalance
            var ciraulation = totalLfoBalance - reserveAddrLfoResponse.Response.Balance;
            Assert.IsTrue(ciraulation > 20000);
        }

        

    }
}