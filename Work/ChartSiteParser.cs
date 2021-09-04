using System.Collections.Generic;
using System.Linq;
using Leaf.xNet;

namespace TESTERforWNDFORMS
{
    static class ChartSiteParser
    {
        public static string GetPage (string link = "https://ru.investing.com/crypto/ethereum/eth-usd" , string pair_interval = "1800" , string PairID = "1058142")
        {
            try
            {
                HttpRequest httpRequest = new HttpRequest
                {
                    KeepAlive = true ,
                    UserAgent = Http.RandomUserAgent()
                };
                httpRequest.AddHeader(HttpHeader.Referer , link);
                httpRequest.AddHeader("accept" , "application/json, text/javascript, */*; q=0.01");
                httpRequest.AddHeader("accept-language" , "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                httpRequest.AddHeader("cookie" , "PHPSESSID=afp1kum8i6hdgm90p7vjdvevj4; adBlockerNewUserDomains=1625900288; StickySession=id.92775249066.844ru.investing.com; udid=4c8ef06a32fbfcbe328f30043a4aef73; _ga=GA1.2.1143588076.1625900288; _ym_uid=16259002881050914750; _ym_d=1625900288; G_ENABLED_IDPS=google; logglytrackingsession=ecb30b20-9815-42ca-a313-c9a3970a134c; G_AUTHUSER_H=0; sideBlockTimeframe=1month; SideBlockUser=a%3A2%3A%7Bs%3A6%3A%22stacks%22%3Ba%3A1%3A%7Bs%3A11%3A%22last_quotes%22%3Ba%3A7%3A%7Bi%3A0%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221167484%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A24%3A%22%2Fequities%2Fyandex-futures%22%3B%7Di%3A1%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A6%3A%22941155%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A17%3A%22%2Fequities%2Falibaba%22%3B%7Di%3A2%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221058142%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A34%3A%22%D0%AD%D1%84%D0%B8%D1%80%D0%B8%D1%83%D0%BC+%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A24%3A%22%2Fcrypto%2Fethereum%2Feth-usd%22%3B%7Di%3A3%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221054919%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A32%3A%22Binance+Coin+%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A28%3A%22%2Fcrypto%2Fbinance-coin%2Fbnb-usd%22%3B%7Di%3A4%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bi%3A1169910%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A43%3A%22%2Fequities%2Fuber-technologies-inc%3Fcid%3D1169910%22%3B%7Di%3A5%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A3%3A%22166%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A19%3A%22%2Findices%2Fus-spx-500%22%3B%7Di%3A6%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A4%3A%222186%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A51%3A%22%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90+%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9+%D1%80%D1%83%D0%B1%D0%BB%D1%8C%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A19%3A%22%2Fcurrencies%2Fusd-rub%22%3B%7D%7D%7Ds%3A10%3A%22stack_size%22%3Ba%3A1%3A%7Bs%3A11%3A%22last_quotes%22%3Bi%3A8%3B%7D%7D; shouldUseCommentsSocket=1; r_p_s_n=1; geoC=RU; gtmFired=OK; _ym_isad=2; adsFreeSalePopUp=3; smd=4c8ef06a32fbfcbe328f30043a4aef73-1628851921; __cflb=0H28uv9TXEXY1dxGsSwM21AWkmXN8C3KHMFXEZP8sBR; _ym_visorc=w; __cf_bm=e173568f28a8ed1cf37a3d0191ddf6fbb11674f1-1628851923-1800-AQ8BUextpM7UtuEy4zxXSIskFJc19kuDbfep9WDBVzcvizC4zZmn+DENMwPDK4S5uYyeLK9bAtpNokcMYka4TJ2k5QXIpz+qx91dLI5CVwYkPl3qF7v8ryIYuGbovTBpRQ==; nyxDorf=Njs3bTF5ZDplNm9jYSxlZTBiNG8zKjo5");
                httpRequest.AddHeader("sec-fetch-dest" , "empty");
                httpRequest.AddHeader("sec-fetch-mode" , "cors");
                httpRequest.AddHeader("sec-fetch-site" , "same-origin");
                httpRequest.AddHeader("x-requested-with" , "XMLHttpRequest");
                var urlParams = new RequestParams
                {
                    ["pair_id"] = PairID ,
                    ["pair_id_for_news"] = PairID ,
                    ["chart_type"] = "candlestick" ,
                    ["pair_interval"] = pair_interval ,
                    ["candle_count"] = "70" ,
                    ["events"] = "yes" ,
                    ["volume_series"] = "yes" ,
                    ["period"] = ""
                };
                return httpRequest.Get("https://ru.investing.com/common/modules/js_instrument_chart/api/data.php?pair_id=" + PairID + "&pair_id_for_news=" + PairID + "&chart_type=candlestick&pair_interval=" + pair_interval + "&candle_count=70&events=yes&volume_series=yes&period=" , urlParams).ToString();
            }
            catch
            {

                return null;
            }
            
        }
        public static void ParsTover (string response,int pair_interval_Lenth, int PairID_Lenth, out string CourseForNow, out List<double> AvgCandles)
        {
            if(response!= null)
            {
                List<string> NotSplitCandles = new List<string>();

                NotSplitCandles = response.Substring(60 + pair_interval_Lenth + PairID_Lenth).Split(']').Where(x=>x!="").Where(x=>x[0]=='['||(x[0] ==','&&x[1] == '[')).ToList();
                NotSplitCandles.AsParallel().ForAll(x =>
                {
                    NotSplitCandles[NotSplitCandles.FindIndex(z => z == x)] = x.Substring(x.IndexOf('[') + 1);
                });
                List<string>[] AllCandles = new List<string>[NotSplitCandles.Count];
                Enumerable.Range(0 , NotSplitCandles.Count).AsParallel().ForAll(x =>
                {
                    AllCandles[x] = NotSplitCandles[x].Split(',').ToList();
                });
                CourseForNow = AllCandles[NotSplitCandles.Count-1][4];
                List<double> CandlesAvg = new List<double>();
                for(int i = 0; i < NotSplitCandles.Count; i++)
                {
                    CandlesAvg.Add((double.Parse(AllCandles[i][2] , System.Globalization.CultureInfo.InvariantCulture)
                        + double.Parse(AllCandles[i][3] , System.Globalization.CultureInfo.InvariantCulture)) / 2);
                }
                Enumerable.Range(0 , CandlesAvg.Count).AsParallel().ForAll(x =>
                {
                    CandlesAvg[x] = CandlesAvg[x] * -1;
                });
                AvgCandles = CandlesAvg;
            }
            else
            {
                CourseForNow = null;
                AvgCandles = null;
            }
        }
    }
}
