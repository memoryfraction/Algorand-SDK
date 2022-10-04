# Algorand-SDK

Unofficial Algorand SDK in .NET Core for Algorand API

## How to use

First you need to choose Algod API Endpoint to use:

- Algod BetaNet API (`https://betanet-algorand.api.purestake.io/ps2`)
- Algod TestNet API (`https://testnet-algorand.api.purestake.io/ps2`)
- Algod MainNet API (`https://mainnet-algorand.api.purestake.io/ps2`)

Above endpoints are from [PureStake]([PureStake Developer Portal](https://developer.purestake.io/apis)) so you do not need to run Algorand Node on your own machine.

    var algoApi = new AlgorandApiClient("https://mainnet-algorand.api.purestake.io/ps2");//ps2 means V3.8.1,idx2 means V2.12.4

You will also need the Api Key it is available also on [PureStake](https://developer.purestake.io/dashboard)

    algoApi.SetApiKey("X-API-Key", "");
    
    var algoClient = new AlgoClientV2(algoApi);

## Algo API status from PureStake

    var status = await algoClient.GetHealthAsync();

Returns OK if healthy.

## Algod Process

The algod process handles processing the protocol, proposing blocks, interacting with the ledger, and building voting committees. The algod process also provides an API that retrieves information about the blockchain, like specific transactions, blocks, and network status.

### Account Endpoint

Given a specific account public key, this call returns the accounts status, balance and spendable amounts.

    var accountInfo = await algoClient.GetAccountInformationAsync("LHHQJ6UMXRG..");

Given a wallet address and a transaction id, it returns the confirmed transaction information. This call scans up to .MaxTxnLife blocks in the past.

    var transactionsInfo = await algoClient.GetTransactionInformationAsync("LHHQ..", "6GZWBHH..");

Returns the list of confirmed transactions between within a date range. This call is available only when the indexer is running.

    var transactions = await algoClient.GetTransactionsAsync("LHHQJ6UM...);

Get the list of pending transactions by address, sorted by priority, in decreasing order, truncated at the end at MAX. If MAX = 0, returns all pending transactions.

    var pendingTx = await algod.GetTransactionsPendingAsync("LHHQJ6UM..");

### All test cases passed

[![image](https://github.com/memoryfraction/Algorand-SDK/blob/master/resources/pics/TestCases.png?raw=true)](/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8A%E8%8D%A3.pdf)

pls download the UnitTests project for more details
