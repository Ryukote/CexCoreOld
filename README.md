
## .NET Core Wrapper for *[CEX.IO](https://cex.io/)*

### Getting started
This is completed version of original repository by fasetto.
In this fork, I have filled the gap created by original author with adding all crypto currencies available on CEX.IO and fixed a small bug for placing market order.
## Getting started

1) For both public and private REST methods:

```csharp
private ApiCredentials credentials = new ApiCredentials("userId","apiKey","apiSecret");

private CexClient client = new CexClient(credentials);
```

2) For public only REST methods (where you don't need credentials):

```csharp
private CexClient client = new CexClient();
```

## Balance

You can get your balance information by calling GetBalanceAsync and filter it trough Bitcoin or Altcoin properties:

```csharp
Balance balance = await client.Account.GetBalanceAsync();
decimal btcBalance = balance.BTC.Available;
```

## Last price

To get the last price for Bitcoin or some Altcoin use GetLastPriceAsync method and give it SymbolPairs enum as argument:

```csharp
var lastPrice = await client.GetLastPriceAsyn(SymbolPairs.BTC_USD);
```

## Place order (Limit order)

Placing limit order means that it will execute after it reach wanted price. For example if the current price for BTC is 5000$ and you want to sell it when it reach 5500$, you will use limit order.

```csharp
var order = new Order(SymbolPairs.BTC_USD, 5500.0m, 0.01m, OrderType.Buy);
Order result = await client.Account.PlaceLimitOrder(order);
```

## Place order (Market order)

Placing market order means that it will execute in instant at the current market price. So, for example, if the current BTC price is 5300$, you will sell your BTC for that price.

```csharp
var order = new Order(SymbolPairs.BTC_USD, null, 0.01m, OrderType.Buy);
Order result = await client.Account.PlaceMarketOrder(order);
```

## Margin trading

Margin trading means borrowing money for trading which is very risky stuff. Please do margin trading with bigger knowledge about margin trading.

```csharp
var lastPrice = await client.GetLastPriceAsync(SymbolPairs.BTC_USD);

var position = new Position()
{
    Pair = SymbolPairs.BTC_USD,
    Amount = 4.7m,
    Symbol = Symbols.BTC,
    Leverage = 3,
    Type = PositionType.Short,
    EstimatedOpenPrice = lastPrice,
    StopLossPrice = lastPrice + 40.0m
};

// returns position id.
var positionId = await client.Account.OpenPosition(position);
```

# You want to support this library?
If you think this library is great idea and you want to support this, you can help with issues, pull requests and small donations.
You can do donations with:
  - BTC on: 322SRqTS3EeKGaVFuo6xsw8e5Xji4QcJR6
  - ETH on: 0xc06d8766061e0644fb780f38abb1226ba289664c
  - XRP on: rE1sdh25BJQ3qFwngiTBwaq3zPGGYcrjp1 with destination tag: 59558
