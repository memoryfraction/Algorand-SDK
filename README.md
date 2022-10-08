# Algorand.sdk.net

[Readme]:  [中文](#摘要) | [English](#Introduction)

# 摘要

本项目基于[Purestake.io](https://developer.purestake.io/),用户可以通过调用C#类库，得到、操作Algorand节点信息。

# 术语

**区块链**，一种高级数据库机制，允许在企业网络中透明地共享信息。 区块链数据库将数据存储在区块中，而数据库则一起链接到一个链条中。 数据在时间上是一致的，因为在没有网络共识的情况下，您不能删除或修改链条。 因此，您可以使用区块链技术创建不可改变的分类账，以便跟踪订单、付款、账户和其他交易。

**Algorand**，一个基于[区块链](https://zh.wikipedia.org/wiki/%E5%8C%BA%E5%9D%97%E9%93%BE)的[加密货币](https://zh.wikipedia.org/wiki/%E5%8A%A0%E5%AF%86%E8%B4%A7%E5%B8%81)平台，以安全、高可扩展性与去中心化为宗旨。[[1]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:0-1)阿尔戈兰德平台支持[智能合约](https://zh.wikipedia.org/wiki/%E6%99%BA%E8%83%BD%E5%90%88%E7%BA%A6)功能[[2]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:1-2)，其[共识机制](https://zh.wikipedia.org/wiki/%E5%85%B1%E8%AD%98%E6%A9%9F%E5%88%B6)基于[权益证明](https://zh.wikipedia.org/wiki/%E6%9D%83%E7%9B%8A%E8%AF%81%E6%98%8E)原则和[拜占庭共识](https://zh.wikipedia.org/wiki/%E6%8B%9C%E5%8D%A0%E5%BA%AD%E5%B0%86%E5%86%9B%E9%97%AE%E9%A2%98)协议。[[1]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:0-1)[[3]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:2-3)[[4]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:3-4)该平台的原生加密货币称为阿尔戈（Algo）。[[2]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-:1-2)

Algorand平台的研发由位于[波士顿](https://zh.wikipedia.org/wiki/%E6%B3%A2%E5%A3%AB%E9%A1%BF)的阿尔戈兰公司（Algorand, Inc.）负责。2017年，[麻省理工学院](https://zh.wikipedia.org/wiki/%E9%BA%BB%E7%9C%81%E7%90%86%E5%B7%A5%E5%AD%A6%E9%99%A2)计算机科学教授、[图灵奖](https://zh.wikipedia.org/wiki/%E5%9B%BE%E7%81%B5%E5%A5%96)得主[希尔维奥·米卡利](https://zh.wikipedia.org/wiki/%E5%B8%8C%E7%88%BE%E7%B6%AD%E5%A5%A7%C2%B7%E7%B1%B3%E5%8D%A1%E5%88%A9)创办了这家公司。[[5]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-5)[[6]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-6)

Algorand的测试网络于2019年4月向公众开放[[7]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-7)，主网络则于2019年6月开通。[[8]](https://zh.wikipedia.org/wiki/%E9%98%BF%E5%B0%94%E6%88%88%E5%85%B0%E5%BE%B7#cite_note-8)

**Purestake**，专注于为有限的网络构建广泛的产品,这让我们开发了深入的主题专业知识,并将其交付给您以易于使用的服务。

**Algorand.sdk.net**，基于NetStandard和Net 6开发的跨平台类库，用户可以使用C#语言直接通过简单步骤获取algorand链上信息。根据用户反馈，后期可能增加Post操作。

# 使用步骤

## 1 安装依赖项

1.1 安装对应Nuget包
```
NuGet\Install-Package Algorand.sdk.net -Version 1.0.0
```

1.2 下载整个项目，添加对于Algorand.sdk.net的引用

## 2 设置基础信息

见Algorand.sdk.Net.UniTests, 其基础信息格式如下：

```
{ 
   "Configuration": {
    "HostAddress": "https://mainnet-algorand.api.purestake.io/ps2",
    "ApiKey": "",
    "TestAlgoAddress": "",
    "LFOAssetId": "",
    "ReserveAddress": ""
  }
}
```

右击项目 Algorand.sdk.Net.UniTests -> Manage UserSecret.json, 在其中配置真正的信息。

注意：UserSecret.json不会被上传到Git

## 3 运行TestCases

UserSecret.json配置完毕后，单元测试才能正常运行。

打开View -> TestExplorer。运行所有单元测试

<img src="https://lh3.googleusercontent.com/GFSCIyCR6P5s7NfrGb-omgl2yyTNVIzfhPM-bRbhyeGRb2Snx_OXMIqZuIlHnDGsdUEMV9QrXEN5jX4Dn0nhkzbBQ5UAw6td1a-YiyB35gPRgDkZlnZG7weML2NGxLodGENmhC9UM6aJvChtbdrQ1N6hS2FilLgWoYX171f3JBLQO5IUCxlmx8Sb6w" title="" alt="" data-align="center">

## 4 常用案例

### 4.1 获取账户信息

```C#
var accountInfoResponse = await _clientV2.GetAccountInformationAsync(_testAlgoAddress);
var account = accountInfoResponse.Response == null ? null : (AlgoAccount)accountInfoResponse.Response;
Assert.IsTrue(accountInfoResponse.Succeed);
Assert.IsTrue(account.ActualBalance > 1);

#Response Json
{
    "address": "",
    "amount":,
    "amount-without-pending-rewards":,
    "apps-local-state": [],
    "apps-total-schema": {
        "num-byte-slice": 0,
        "num-uint": 0
    },
    "assets": [
        {
            "amount":,
            "asset-id":,
            "is-frozen": false
        }
    ],
    "created-apps": [],
    "created-assets": [],
    "min-balance": 200000,
    "pending-rewards": 0,
    "reward-base": 218288,
    "rewards": 0,
    "round": 23961492,
    "status": "Offline",
    "total-apps-opted-in": 0,
    "total-assets-opted-in": 1,
    "total-created-apps": 0,
    "total-created-assets": 0
}
```

### 4.2 获取Asset信息

```C#
var assetResponse = await _clientV2.GetAssetInformationAsync(_lfoAssetId);
Assert.IsTrue(assetResponse.Succeed);
Assert.IsTrue(assetResponse.Response != null);

#Response Json
{
    "asset-holding": {
        "amount":,
        "asset-id":,
        "is-frozen": false
    },
    "round": 
}
```

更多案例，详见Algorand.sdk.Net.UnitTests测试Cases。

# 小结

本项目基于purestake.io开发了.NET Core 类库，C#使用者可以方便调用Algorand相关信息。

# 关于作者

热爱C#、区块链等技术。

Email:     [rex.fan18@gmail.com](mailto:rex.fan18@gmail.com)

拥有沃顿商学院: Economics of Blockchain and Digital Assets - Certificate

<img src="https://lh3.googleusercontent.com/9hJTqzfQFkwAkb88ah2WNwd7iTTshO0Ogyj3oVP7f3f6XMHf5lgOHe7IZyBi2_5RUwpV8blE4IgkXm8FgdwQDpAK3nx9tR_GHmcsGU5DJl723uLIzo0VkeVRER73zYdpgvClyoSKTeUpjVUi5Ghewe_qRp9qlMfj7-K51B4ELTsP2PSEQxmlmM-qLQ" title="" alt="" data-align="center">

Badge验证链接:  [Economics of Blockchain and Digital Assets - Credly](https://www.credly.com/badges/49458e85-db77-4418-a6d0-ba276b3275db/public_url)

# 参考资料

1 [Algorand - Wikipedia](https://en.wikipedia.org/wiki/Algorand)

2 [如何在Algorand链上创建自己的Token？](https://www.youtube.com/watch?v=ryk-tKyZUpk)

原创不易，您的反馈是持续创新的动力。如果我的工作对您有帮助，还请收藏本项目、转发、请作者喝咖啡。

Algo address: EFIRPOWUEZIOGEBSR47R5WOEFIKSDBPA5UJERXX75GIIP3JTPBAI5PC7I4



# Introduction

An algorand sdk in .net core based on purestake.io.

# Terms

**Blockchain**, an advanced database mechanism that allows transparent sharing of information across corporate networks. Blockchain databases store data in blocks, and databases are linked together in a chain. The data is consistent in time because you cannot delete or modify the chain without network consensus. Therefore, you can use blockchain technology to create an immutable ledger in order to track orders, payments, accounts and other transactions.

**Algorand**, a blockchain-based cryptocurrency platform for security, scalability and decentralization. [1] The Algorand platform supports smart contract functions [2], and its consensus mechanism is based on the principle of proof of stake and Byzantine consensus protocol. [1][3][4] The platform’s native cryptocurrency is called Algo. [2]
The Algorand platform is developed by Algorand, Inc., located in Boston. The company was founded in 2017 by MIT computer science professor and Turing Award winner Silvio Mikkali. [5][6]
Algorand's testnet opened to the public in April 2019 [7], and the mainnet opened in June 2019. [8]

**Purestake**'s focus on building a broad range of products for limited networks has allowed us to develop deep subject matter expertise and deliver it to you as an easy-to-use service.

**Algorand.sdk.net**, a cross-platform class library developed based on NetStandard and Net 6, users can use the C# language to directly obtain information on the algorand chain through simple steps. According to user feedback, Post operations may be added later.

# Steps to Use

### 1 Install dependencies

1.1 install the corresponding Nuget package 
```
NuGet\Install-Package Algorand.sdk.net -Version 1.0.0
```

1.2 Download the entire project and add a reference to Algorand.sdk.net

### 2 Set basic information

See Algorand.sdk.Net.UniTests, the basic information format is as follows:

```
{ 
 "Configuration": {
    "HostAddress": "https://mainnet-algorand.api.purestake.io/ps2",
    "ApiKey": "",
    "TestAlgoAddress": "",
    "LFOAssetId": "",
    "ReserveAddress": ""
  }
}
```

Right click on the project Algorand.sdk.Net.UniTests -> Manage UserSecret.json, and configure the real information in it.

Note: UserSecret.json will not be uploaded to Git

## 3 Run TestCases

Unit tests can only run properly after UserSecret.json is configured.

Open View -> TestExplorer. run all unit tests

<img src="https://lh3.googleusercontent.com/GFSCIyCR6P5s7NfrGb-omgl2yyTNVIzfhPM-bRbhyeGRb2Snx_OXMIqZuIlHnDGsdUEMV9QrXEN5jX4Dn0nhkzbBQ5UAw6td1a-YiyB35gPRgDkZlnZG7weML2NGxLodGENmhC9UM6aJvChtbdrQ1N6hS2FilLgWoYX171f3JBLQO5IUCxlmx8Sb6w" title="" alt="" data-align="center">

# 4 Common cases

### 4.1 Get account information

```C#
var accountInfoResponse = await _clientV2.GetAccountInformationAsync(_testAlgoAddress);
var account = accountInfoResponse.Response == null ? null : (AlgoAccount)accountInfoResponse.Response;
Assert.IsTrue(accountInfoResponse.Succeed);
Assert.IsTrue(account.ActualBalance > 1);

#Response Json
{
"address": "",
"amount":,
"amount-without-pending-rewards":,
"apps-local-state": [],
"apps-total-schema": {
"num-byte-slice": 0,
"num-uint": 0
},
"assets": [
{
"amount":,
"asset-id":,
"is-frozen": false
} }
],
"created-apps": [],
"created-assets": [],
"min-balance": 200000,
"pending-rewards": 0,
"reward-base": 218288,
"rewards": 0,
"round": 23961492,
"status": "Offline",
"total-apps-opted-in": 0,
"total-assets-opted-in": 1,
"total-created-apps": 0,
"total-created-assets": 0
}
```

### 4.2 Get Asset Information

```C#
var assetResponse = await _clientV2.GetAssetInformationAsync(_lfoAssetId);
Assert.IsTrue(assetResponse.Succeed);
Assert.IsTrue(assetResponse.Response != null);

#Response Json
{
"asset-holding": {
"amount":,
"asset-id":,
"is-frozen": false
},
"round":
}
```

For more cases, see Algorand.sdk.Net.UnitTests Test Cases.

# Summary

This project has developed a .NET Core class library based on purestake.io, and C# users can easily call Algorand related information.

# The Author

#Rex Fan 

Love C#, blockchain and other technologies. 

Email: rex.fan18@gmail.com 

Linkedin: https://www.linkedin.com/in/rongfan1031/ 

With Wharton: Economics of Blockchain and Digital Assets - Certificate

<img title="" src="https://lh3.googleusercontent.com/9hJTqzfQFkwAkb88ah2WNwd7iTTshO0Ogyj3oVP7f3f6XMHf5lgOHe7IZyBi2_5RUwpV8blE4IgkXm8FgdwQDpAK3nx9tR_GHmcsGU5DJl723uLIzo0VkeVRER73zYdpgvClyoSKTeUpjVUi5Ghewe_qRp9qlMfj7-K51B4ELTsP2PSEQxmlmM-qLQ" alt="" data-align="center">

Validation Badge URL:  **[Economics of Blockchain and Digital Assets - Credly](https://www.credly.com/badges/49458e85-db77-4418-a6d0-ba276b3275db/public_url)**

# Reference

1 [Algorand - Wikipedia](https://en.wikipedia.org/wiki/Algorand)

2 [How to create your own Algorand token](https://www.youtube.com/watch?v=ryk-tKyZUpk)

Originality is not easy, your feedback is the driving force for continuous innovation. 

If my work is helpful to you, please bookmark this project, forward it, or buy the author to drink coffee.

**Algo address:** EFIRPOWUEZIOGEBSR47R5WOEFIKSDBPA5UJERXX75GIIP3JTPBAI5PC7I4
