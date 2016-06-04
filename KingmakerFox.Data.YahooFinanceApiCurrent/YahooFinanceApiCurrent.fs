namespace KingmakerFox.Data

open Microsoft.FSharp.Collections
open System
open System.Collections.Generic
open System.Diagnostics.CodeAnalysis
open System.Linq
open System.Net
open System.Text
open System.Xml
open System.Xml.Linq
open System.Xml.Linq.FSharpExtensions

module YahooFinanceApiCurrent =

    let SymbolDataUrl (symbol: string) = @"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22" + symbol + "%22)&env=store://datatables.org/alltableswithkeys"

    let GetSymbolData (symbol:string) =    
        let dataUrl = SymbolDataUrl(symbol)
        let doc = XDocument.Load(dataUrl)
        let results = doc.Root.Element("results").Elements("quote").First(fun w -> w.Attribute("symbol").Value=symbol).Elements()
        results

    let GetDataItem (symbol:string, dataItem:string) =
        let data = GetSymbolData(symbol)
        let result = Some(data.FirstOrDefault(fun e -> (e.Name = XName dataItem)).Value)
        result

    let GetDataItems(symbol:string) =
        let data = GetSymbolData(symbol)
        let dataseq = data |> Seq.cast<XElement>
        let dataEnumerator = dataseq.GetEnumerator()
        let datadict = new Dictionary<string,string>()
        while dataEnumerator.MoveNext() do
            datadict.Add (dataEnumerator.Current.Name.ToString(), dataEnumerator.Current.Value)
        datadict

    // #1
    [<ExcludeFromCodeCoverage>]
    let Ask(symbol:string) =
        let result = GetDataItem(symbol,"Ask")
        result

    // #2
    [<ExcludeFromCodeCoverage>]
    let AverageDailyVolume(symbol:string) =
        let result = GetDataItem(symbol,"AverageDailyVolume")
        result

    // #3
    [<ExcludeFromCodeCoverage>]
    let Bid(symbol:string) =
        let result = GetDataItem(symbol,"Bid")
        result

    // #4
    [<ExcludeFromCodeCoverage>]
    let AskRealtime(symbol:string) =
        let result = GetDataItem(symbol,"AskRealtime")
        result

    // #5
    [<ExcludeFromCodeCoverage>]
    let BidRealtime(symbol:string) =
        let result = GetDataItem(symbol,"BidRealtime")
        result

    // #6
    [<ExcludeFromCodeCoverage>]
    let BookValue(symbol:string) =
        let result = GetDataItem(symbol,"BookValue")
        result

    // #7
    [<ExcludeFromCodeCoverage>]
    let ChangeAndPercentChange(symbol:string) =
        let result = GetDataItem(symbol,"Change_PercentChange")
        result

    // #8
    [<ExcludeFromCodeCoverage>]
    let Change(symbol:string) =
        let result = GetDataItem(symbol,"Change")
        result

    // #9
    [<ExcludeFromCodeCoverage>]
    let Commission(symbol:string) =
        let result = GetDataItem(symbol,"Commission")
        result

    // #10
    [<ExcludeFromCodeCoverage>]
    let Currency(symbol:string) =
        let result = GetDataItem(symbol,"Currency")
        result

    // #11
    [<ExcludeFromCodeCoverage>]
    let ChangeRealtime(symbol:string) =
        let result = GetDataItem(symbol,"ChangeRealtime")
        result

    // #12
    [<ExcludeFromCodeCoverage>]
    let AfterHoursChangeRealtime(symbol:string) =
        let result = GetDataItem(symbol,"AfterHoursChangeRealtime")
        result

    // #13
    [<ExcludeFromCodeCoverage>]
    let DividendShare(symbol:string) =
        let result = GetDataItem(symbol,"DividendShare")
        result

    // #14
    [<ExcludeFromCodeCoverage>]
    let LastTradeDate(symbol:string) =
        let result = GetDataItem(symbol,"LastTradeDate")
        result

    // #15
    [<ExcludeFromCodeCoverage>]
    let TradeDate(symbol:string) =
        let result = GetDataItem(symbol,"TradeDate")
        result

    // #16
    [<ExcludeFromCodeCoverage>]
    let EarningsShare(symbol:string) =
        let result = GetDataItem(symbol,"EarningsShare")
        result

    // #17
    [<ExcludeFromCodeCoverage>]
    let ErrorIndicationReturnedForSymbolChangedInvalid(symbol:string) =
        let result = GetDataItem(symbol,"ErrorIndicationreturnedforsymbolchangedinvalid")
        result

    // #18
    [<ExcludeFromCodeCoverage>]
    let EPSEstimateCurrentYear(symbol:string) =
        let result = GetDataItem(symbol,"EPSEstimateCurrentYear")
        result

    // #19
    [<ExcludeFromCodeCoverage>]
    let EPSEstimateNextYear(symbol:string) =
        let result = GetDataItem(symbol,"EPSEstimateNextYear")
        result

    // #20
    [<ExcludeFromCodeCoverage>]
    let EPSEstimateNextQuarter(symbol:string) =
        let result = GetDataItem(symbol,"EPSEstimateNextQuarter")
        result

    // #21
    [<ExcludeFromCodeCoverage>]
    let DaysLow(symbol:string) =
        let result = GetDataItem(symbol,"DaysLow")
        result

    // #22
    [<ExcludeFromCodeCoverage>]
    let DaysHigh(symbol:string) =
        let result = GetDataItem(symbol,"DaysHigh")
        result

    // #23
    [<ExcludeFromCodeCoverage>]
    let YearLow(symbol:string) =
        let result = GetDataItem(symbol,"YearLow")
        result

    // #24
    [<ExcludeFromCodeCoverage>]
    let YearHigh(symbol:string) =
        let result = GetDataItem(symbol,"YearHigh")
        result

    // #25
    [<ExcludeFromCodeCoverage>]
    let HoldingsGainPercent(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsGainPercent")
        result

    // #26
    [<ExcludeFromCodeCoverage>]
    let AnnualizedGain(symbol:string) =
        let result = GetDataItem(symbol,"AnnualizedGain")
        result

    // #27
    [<ExcludeFromCodeCoverage>]
    let HoldingsGain(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsGain")
        result

    // #28
    [<ExcludeFromCodeCoverage>]
    let HoldingsGainPercentRealtime(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsGainPercentRealtime")
        result

    // #29
    [<ExcludeFromCodeCoverage>]
    let HoldingsGainRealtime(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsGainRealtime")
        result

    // #30
    [<ExcludeFromCodeCoverage>]
    let MoreInfo(symbol:string) =
        let result = GetDataItem(symbol,"MoreInfo")
        result

    // #31
    [<ExcludeFromCodeCoverage>]
    let OrderBookRealtime(symbol:string) =
        let result = GetDataItem(symbol,"OrderBookRealtime")
        result

    // #32
    [<ExcludeFromCodeCoverage>]
    let MarketCapitalization(symbol:string) =
        let result = GetDataItem(symbol,"MarketCapitalization")
        result

    // #33
    [<ExcludeFromCodeCoverage>]
    let MarketCapRealtime(symbol:string) =
        let result = GetDataItem(symbol,"MarketCapRealtime")
        result

    // #34
    [<ExcludeFromCodeCoverage>]
    let EBITDA(symbol:string) =
        let result = GetDataItem(symbol,"EBITDA")
        result

    // #35
    [<ExcludeFromCodeCoverage>]
    let ChangeFromYearLow(symbol:string) =
        let result = GetDataItem(symbol,"ChangeFromYearLow")
        result

    // #36
    [<ExcludeFromCodeCoverage>]
    let PercentChangeFromYearLow(symbol:string) =
        let result = GetDataItem(symbol,"PercentChangeFromYearLow")
        result

    // #37
    [<ExcludeFromCodeCoverage>]
    let LastTradeRealtimeWithTime(symbol:string) =
        let result = GetDataItem(symbol,"LastTradeRealtimeWithTime")
        result

    // #38
    [<ExcludeFromCodeCoverage>]
    let ChangePercentRealtime(symbol:string) =
        let result = GetDataItem(symbol,"ChangePercentRealtime")
        result

    // #39
    [<ExcludeFromCodeCoverage>]
    let ChangeFromYearHigh(symbol:string) =
        let result = GetDataItem(symbol,"ChangeFromYearHigh")
        result

    // #40
    [<ExcludeFromCodeCoverage>]
    let PercentChangeFromYearHigh(symbol:string) =
        let result = GetDataItem(symbol,"PercebtChangeFromYearHigh")  // Spelling error with Yahoo's API
        result

    // #41
    [<ExcludeFromCodeCoverage>]
    let LastTradeWithTime(symbol:string) =
        let result = GetDataItem(symbol,"LastTradeWithTime")
        result

    // #42
    [<ExcludeFromCodeCoverage>]
    let LastTradePriceOnly(symbol:string) =
        let result = GetDataItem(symbol,"LastTradePriceOnly")
        result

    // #43
    [<ExcludeFromCodeCoverage>]
    let HighLimit(symbol:string) =
        let result = GetDataItem(symbol,"HighLimit")
        result

    // #44
    [<ExcludeFromCodeCoverage>]
    let LowLimit(symbol:string) =
        let result = GetDataItem(symbol,"LowLimit")
        result

    // #45
    [<ExcludeFromCodeCoverage>]
    let DaysRange(symbol:string) =
        let result = GetDataItem(symbol,"DaysRange")
        result

    // #46
    [<ExcludeFromCodeCoverage>]
    let DaysRangeRealtime(symbol:string) =
        let result = GetDataItem(symbol,"DaysRangeRealtime")
        result

    // #47
    [<ExcludeFromCodeCoverage>]
    let FiftyDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"FiftydayMovingAverage")
        result

    // #48
    [<ExcludeFromCodeCoverage>]
    let TwoHundredDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"TwoHundreddayMovingAverage")
        result

    // #49
    [<ExcludeFromCodeCoverage>]
    let ChangeFromTwoHundredDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"ChangeFromTwoHundreddayMovingAverage")
        result

    // #50
    [<ExcludeFromCodeCoverage>]
    let PercentChangeFromTwoHundredDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"PercentChangeFromTwoHundreddayMovingAverage")
        result

    // #51
    [<ExcludeFromCodeCoverage>]
    let ChangeFromFiftyDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"ChangeFromFiftydayMovingAverage")
        result

    // #52
    [<ExcludeFromCodeCoverage>]
    let PercentChangeFromFiftyDayMovingAverage(symbol:string) =
        let result = GetDataItem(symbol,"PercentChangeFromFiftydayMovingAverage")
        result

    // #53
    let Name(symbol:string) =
        let result = GetDataItem(symbol,"Name")
        result

    // #54
    [<ExcludeFromCodeCoverage>]
    let Notes(symbol:string) =
        let result = GetDataItem(symbol,"Notes")
        result

    // #55
    [<ExcludeFromCodeCoverage>]
    let Open(symbol:string) =
        let result = GetDataItem(symbol,"Open")
        result

    // #56
    [<ExcludeFromCodeCoverage>]
    let PreviousClose(symbol:string) =
        let result = GetDataItem(symbol,"PreviousClose")
        result

    // #57
    [<ExcludeFromCodeCoverage>]
    let PricePaid(symbol:string) =
        let result = GetDataItem(symbol,"PricePaid")
        result

    // #58
    [<ExcludeFromCodeCoverage>]
    let ChangeInPercent(symbol:string) =
        let result = GetDataItem(symbol,"ChangeinPercent")
        result

    // #59
    [<ExcludeFromCodeCoverage>]
    let PriceSales(symbol:string) =
        let result = GetDataItem(symbol,"PriceSales")
        result

    // #60
    [<ExcludeFromCodeCoverage>]
    let PriceBook(symbol:string) =
        let result = GetDataItem(symbol,"PriceBook")
        result

    // #61
    [<ExcludeFromCodeCoverage>]
    let ExDividendDate(symbol:string) =
        let result = GetDataItem(symbol,"ExDividendDate")
        result

    // #62
    [<ExcludeFromCodeCoverage>]
    let PERatio(symbol:string) =
        let result = GetDataItem(symbol,"PERatio")
        result

    // #63
    [<ExcludeFromCodeCoverage>]
    let DividendPayDate(symbol:string) =
        let result = GetDataItem(symbol,"DividendPayDate")
        result

    // #64
    [<ExcludeFromCodeCoverage>]
    let PERatioRealtime(symbol:string) =
        let result = GetDataItem(symbol,"PERatioRealtime")
        result

    // #65
    [<ExcludeFromCodeCoverage>]
    let PEGRatio(symbol:string) =
        let result = GetDataItem(symbol,"PEGRatio")
        result

    // #66
    [<ExcludeFromCodeCoverage>]
    let PriceEPSEstimateCurrentYear(symbol:string) =
        let result = GetDataItem(symbol,"PriceEPSEstimateCurrentYear")
        result

    // #67
    [<ExcludeFromCodeCoverage>]
    let PriceEPSEstimateNextYear(symbol:string) =
        let result = GetDataItem(symbol,"PriceEPSEstimateNextYear")
        result

    // #68
    let Symbol(symbol:string) =
        let result = GetDataItem(symbol,"Symbol")
        result

    // #69
    [<ExcludeFromCodeCoverage>]
    let SharesOwned(symbol:string) =
        let result = GetDataItem(symbol,"SharesOwned")
        result

    // #70
    [<ExcludeFromCodeCoverage>]
    let ShortRatio(symbol:string) =
        let result = GetDataItem(symbol,"ShortRatio")
        result

    // #71
    [<ExcludeFromCodeCoverage>]
    let LastTradeTime(symbol:string) =
        let result = GetDataItem(symbol,"LastTradeTime")
        result

    // #72
    [<ExcludeFromCodeCoverage>]
    let TickerTrend(symbol:string) =
        let result = GetDataItem(symbol,"TickerTrend")
        result

    // #73
    [<ExcludeFromCodeCoverage>]
    let OneYearTargetPrice(symbol:string) =
        let result = GetDataItem(symbol,"OneyrTargetPrice")
        result

    // #74
    [<ExcludeFromCodeCoverage>]
    let Volume(symbol:string) =
        let result = GetDataItem(symbol,"Volume")
        result

    // #75
    [<ExcludeFromCodeCoverage>]
    let HoldingsValue(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsValue")
        result

    // #76
    [<ExcludeFromCodeCoverage>]
    let HoldingsValueRealtime(symbol:string) =
        let result = GetDataItem(symbol,"HoldingsValueRealtime")
        result

    // #77
    [<ExcludeFromCodeCoverage>]
    let YearRange(symbol:string) =
        let result = GetDataItem(symbol,"YearRange")
        result

    // #78
    [<ExcludeFromCodeCoverage>]
    let DaysValueChange(symbol:string) =
        let result = GetDataItem(symbol,"DaysValueChange")
        result

    // #79
    [<ExcludeFromCodeCoverage>]
    let DaysValueChangeRealtime(symbol:string) =
        let result = GetDataItem(symbol,"DaysValueChangeRealtime")
        result

    // #80
    let StockExchange(symbol:string) =
        let result = GetDataItem(symbol,"StockExchange")
        result

    // #81
    [<ExcludeFromCodeCoverage>]
    let DividendYield(symbol:string) =
        let result = GetDataItem(symbol,"DividendYield")
        result

    // #82
    [<ExcludeFromCodeCoverage>]
    let PercentChange(symbol:string) =
        let result = GetDataItem(symbol,"PercentChange")
        result
