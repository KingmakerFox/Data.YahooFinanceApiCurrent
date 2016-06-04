namespace KingmakerFox.Data.YahooApiCurrentTest

open KingmakerFox.Data.YahooFinanceApiCurrent
open System
open Xunit

type YahooApiCurrentTests() = 
    
    [<Theory>]
    [<InlineData("MSFT","USD")>]
    [<InlineData("AAPL","USD")>]
    [<InlineData("IBM","USD")>]
    [<InlineData("AC.TO","CAD")>]
    member this.TestCurrency (symbol:string, expectedValue:string) =
        let data = GetDataItem(symbol,"Currency")
        let actualResult = data.Value
        Assert.Equal(expectedValue,actualResult)

    [<Theory>]
    [<InlineData("MSFT",82)>]
    [<InlineData("AAPL",82)>]
    [<InlineData("IBM",82)>]
    [<InlineData("AC.TO",82)>]
    member this.TestCollectionCount(symbol:string,expectedValue:int) =
        let data = GetDataItems(symbol)
        Assert.Equal(82,data.Count)

    [<Theory>]
    [<InlineData("MSFT","NMS")>]
    [<InlineData("IBM","NYQ")>]
    [<InlineData("AC.TO","TOR")>]
    member this.TestStockExchange(symbol:string, expectedValue:string) =
        let data = StockExchange(symbol).Value
        Assert.Equal(expectedValue, data)

    [<Theory>]
    [<InlineData("MSFT","MSFT")>]
    [<InlineData("IBM","IBM")>]
    [<InlineData("AC.TO","AC.TO")>]
    member this.TestSymbol(symbol:string, expectedValue:string) =
        let data = Symbol(symbol).Value
        Assert.Equal(expectedValue, data)

    [<Theory>]
    [<InlineData("MSFT","Microsoft Corporation")>]
    [<InlineData("IBM","International Business Machines")>]
    [<InlineData("AC.TO","AIR CANADA")>]
    member this.Name(symbol:string, expectedValue:string) =
        let data = Name(symbol).Value
        Assert.Equal(expectedValue, data)