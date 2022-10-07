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

        public AlgoClientV2(IAlgorandApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void SetApiVersion(string apiVersion)
        {
            _apiVersion = apiVersion;
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

        #region Account

        // todo: v2/accounts/address

        // todo: v2/accounts/address/assets/asset-id



        /// <summary>
        /// v2/accounts/account-id
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<ResponseBase<AlgoAccount>> GetAccountInformationAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<AlgoAccount>($"{_apiVersion}/accounts/{address}");

                return ResponseBase<AlgoAccount>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AlgoAccount>.Error(null, FormatError(ex));
            }
        }


        public async Task<ResponseBase<Transaction>> GetTransactionInformationAsync(string address, string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<Transaction>($"{_apiVersion}/account/{address}/transaction/{txId}");

                return ResponseBase<Transaction>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Transaction>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TransactionRoot>> GetTransactionsAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<TransactionRoot>($"{_apiVersion}/account/{address}/transactions");

                return ResponseBase<TransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TransactionRoot>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TruncatedTransactionRoot>> GetTransactionsPendingAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<TruncatedTransactionRoot>($"{_apiVersion}/account/{address}/transactions/pending");

                return ResponseBase<TruncatedTransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TruncatedTransactionRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Asset
        // todo v2/assets

        // todo v2/assets/assetid

        // todo v2/assets/assetid/balance

        #endregion

        #region Amount
        public async Task<ResponseBase<AssetInfo>> GetAssetInformationAsync(string assetId)
        {
            try
            {
                var model = await _apiClient.GetAsync<AssetInfo>($"{_apiVersion}/assets/{assetId}");
                return ResponseBase<AssetInfo>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AssetInfo>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<AccountAsset>> GetAccountAssetAsync(string assetId, string accountAddr)
        {
            try
            {
                var model = await _apiClient.GetAsync<AccountAsset>($"{_apiVersion}/accounts/{accountAddr}/assets/{assetId}");
                return ResponseBase<AccountAsset>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AccountAsset>.Error(null, FormatError(ex));
            }
        }



        public async Task<ResponseBase<AssetRoot>> GetAssetListAsync(int max, string index)
        {
            try
            {
                var model = await _apiClient.GetAsync<AssetRoot>($"{_apiVersion}/assets?max={max}&assetIdx={index}");

                return ResponseBase<AssetRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AssetRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Block
        public async Task<ResponseBase<Block>> GetBlockInformationAsync(int round)
        {
            try
            {
                var model = await _apiClient.GetAsync<Block>($"{_apiVersion}/block/{round}");

                return ResponseBase<Block>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Block>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Ledger
        public async Task<ResponseBase<TotalSupply>> GetLedgerSupplyAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TotalSupply>($"{_apiVersion}/ledger/supply");

                return ResponseBase<TotalSupply>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TotalSupply>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Status
        public async Task<ResponseBase<NodeStatus>> GetNodeStatusAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<NodeStatus>($"{_apiVersion}/status");

                return ResponseBase<NodeStatus>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<NodeStatus>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<NodeStatus>> GetNodeStatusAfterRoundAsync(int round)
        {
            try
            {
                var model = await _apiClient.GetAsync<NodeStatus>($"{_apiVersion}/status/wait-for-block-after/{round}");

                return ResponseBase<NodeStatus>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<NodeStatus>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Transactions

        // todo v2/assets/assetid/transactions
        public async Task<ResponseBase<Transaction>> GetSingleTransactionInformationAsync(string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<Transaction>($"{_apiVersion}/transaction/{txId}");

                return ResponseBase<Transaction>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Transaction>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<FeeRoot>> GetSuggestedFeeAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<FeeRoot>($"{_apiVersion}/transactions/fee");

                return ResponseBase<FeeRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<FeeRoot>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TransactionParams>> GetTransactionParamsAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TransactionParams>($"{_apiVersion}/transactions/params");

                return ResponseBase<TransactionParams>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TransactionParams>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TruncatedTransactionRoot>> GetUnconfirmedTransactionAsync(string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<TruncatedTransactionRoot>($"{_apiVersion}/transactions/pending/{txId}");

                return ResponseBase<TruncatedTransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TruncatedTransactionRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Version
        /// <summary>
        /// versions , todo response model
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<VersionRootV2>> GetVersionsAsync()
        {
            try
            {
                var response = await _apiClient.GetAsync<VersionRootV2>("versions");
                return ResponseBase<VersionRootV2>.Success(response);
            }
            catch (Exception ex)
            {
                return ResponseBase<VersionRootV2>.Error(null, FormatError(ex));
            }
        }
        #endregion

        private string FormatError(Exception ex)
            => $"Exception: {ex.Message} | StackTrace: {ex.StackTrace}";
    }
}
