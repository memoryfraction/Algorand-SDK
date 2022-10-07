using Algorand.SDK.Dotnet.Api.Models;
using Algorand.SDK.Dotnet.Api.Response;
using Algorand.SDK.Dotnet.Api;
using System;
using System.Threading.Tasks;
using Algorand.sdk.net.Api.ModelsV2;

namespace Algorand.SDK.Dotnet.Client
{
    public class AlgoClientV2
    {
        private readonly IAlgorandApiClient _apiClient;
        private string _apiVersion = "v2";

        public string ApiVersion { get => _apiVersion; set => _apiVersion = value; }

        public AlgoClientV2(IAlgorandApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void SetApiVersion(string apiVersion)
        {
            ApiVersion = apiVersion;
        }

        #region Health
        /// <summary>
        /// health check
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<string>> GetHealthAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<string>("health");
                return ResponseBase<string>.Success("OK");
            }
            catch (Exception ex)
            {
                return ResponseBase<string>.Error(default, FormatError(ex));
            }
        }
        #endregion

        #region Accoun

        /// <summary>
        /// v2/accounts/account-id
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<ResponseBase<AlgoAccount>> GetAccountInformationAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<AlgoAccount>($"{ApiVersion}/accounts/{address}");

                return ResponseBase<AlgoAccount>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AlgoAccount>.Error(null, FormatError(ex));
            }
        }

        #endregion

        #region Asset

        #endregion

        #region AccountRelated

        public async Task<ResponseBase<AccountAsset>> GetAccountAssetAsync(string assetId, string accountAddr)
        {
            try
            {
                var model = await _apiClient.GetAsync<AccountAsset>($"{ApiVersion}/accounts/{accountAddr}/assets/{assetId}");
                return ResponseBase<AccountAsset>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AccountAsset>.Error(null, FormatError(ex));
            }
        }


        public async Task<ResponseBase<AssetV2>> GetAssetInformationAsync(string assetId)
        {
            try
            {
                var model = await _apiClient.GetAsync<AssetV2>($"{ApiVersion}/assets/{assetId}");
                return ResponseBase<AssetV2>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AssetV2>.Error(null, FormatError(ex));
            }
        }

        #endregion

        #region Ledger
        public async Task<ResponseBase<TotalSupplyV2>> GetLedgerSupplyAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TotalSupplyV2>($"{ApiVersion}/ledger/supply");
                return ResponseBase<TotalSupplyV2>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TotalSupplyV2>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Status
        public async Task<ResponseBase<StatusV2>> GetStatusAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<StatusV2>($"{ApiVersion}/status");
                return ResponseBase<StatusV2>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<StatusV2>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Transactions

        public async Task<ResponseBase<TransactionsParametersV2>> GetTransactionsParamsAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TransactionsParametersV2>($"{ApiVersion}/transactions/params");

                return ResponseBase<TransactionsParametersV2>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TransactionsParametersV2>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<PendingTransactionsV2>> GetTransactionsPendingAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<PendingTransactionsV2>($"{ApiVersion}/transactions/pending");
                return ResponseBase<PendingTransactionsV2>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<PendingTransactionsV2>.Error(null, FormatError(ex));
            }
        }


        #endregion

        #region Version
        /// <summary>
        /// versions , todo response model
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<VersionV2>> GetVersionsAsync()
        {
            try
            {
                var response = await _apiClient.GetAsync<VersionV2>("versions");
                return ResponseBase<VersionV2>.Success(response);
            }
            catch (Exception ex)
            {
                return ResponseBase<VersionV2>.Error(null, FormatError(ex));
            }
        }
        #endregion

        private string FormatError(Exception ex)
            => $"Exception: {ex.Message} | StackTrace: {ex.StackTrace}";
    }
}
