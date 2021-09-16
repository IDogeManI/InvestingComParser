using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using AngleSharp.Html.Parser;

namespace TESTERforWNDFORMS
{
    static class CandleModelParser
    {
        public static string GetPage (string link = "https://ru.investing.com/crypto/ethereum/eth-usd-candlestick")
        {
            try
            {
                HttpRequest httpRequest = new HttpRequest
                {
                    KeepAlive = true ,
                    UserAgent = Http.ChromeUserAgent()
                };
                httpRequest.AddHeader(HttpHeader.Referer , link);
                httpRequest.AddHeader(HttpHeader.Accept , "*/*");
                //httpRequest.AddHeader(HttpHeader.AcceptLanguage, "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                httpRequest.AddHeader(HttpHeader.ContentType , "application/x-www-form-urlencoded");
                httpRequest.AddHeader(HttpHeader.Origin , "https://ru.investing.com");
                httpRequest.AddHeader(":authority" , "ru.investing.com");
                httpRequest.AddHeader(":method" , "POST");
                httpRequest.AddHeader(":path" , "/instruments/Service/GetTechincalData");
                httpRequest.AddHeader(":scheme" , "https");
                httpRequest.AddHeader("content-type" , "application/x-www-form-urlencoded");
                httpRequest.AddHeader("cookie" , "PHPSESSID=afp1kum8i6hdgm90p7vjdvevj4; adBlockerNewUserDomains=1625900288; StickySession=id.92775249066.844ru.investing.com; udid=4c8ef06a32fbfcbe328f30043a4aef73; _ga=GA1.2.1143588076.1625900288; _ym_d=1625900288; _ym_uid=16259002881050914750; G_ENABLED_IDPS=google; r_p_s_n=1; logglytrackingsession=ecb30b20-9815-42ca-a313-c9a3970a134c; G_AUTHUSER_H=0; sideBlockTimeframe=1month; SideBlockUser=a%3A2%3A%7Bs%3A6%3A%22stacks%22%3Ba%3A1%3A%7Bs%3A11%3A%22last_quotes%22%3Ba%3A7%3A%7Bi%3A0%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221167484%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A24%3A%22%2Fequities%2Fyandex-futures%22%3B%7Di%3A1%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A6%3A%22941155%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A17%3A%22%2Fequities%2Falibaba%22%3B%7Di%3A2%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221058142%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A34%3A%22%D0%AD%D1%84%D0%B8%D1%80%D0%B8%D1%83%D0%BC+%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A24%3A%22%2Fcrypto%2Fethereum%2Feth-usd%22%3B%7Di%3A3%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A7%3A%221054919%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A32%3A%22Binance+Coin+%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A28%3A%22%2Fcrypto%2Fbinance-coin%2Fbnb-usd%22%3B%7Di%3A4%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bi%3A1169910%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A43%3A%22%2Fequities%2Fuber-technologies-inc%3Fcid%3D1169910%22%3B%7Di%3A5%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A3%3A%22166%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A0%3A%22%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A19%3A%22%2Findices%2Fus-spx-500%22%3B%7Di%3A6%3Ba%3A3%3A%7Bs%3A7%3A%22pair_ID%22%3Bs%3A4%3A%222186%22%3Bs%3A10%3A%22pair_title%22%3Bs%3A51%3A%22%D0%94%D0%BE%D0%BB%D0%BB%D0%B0%D1%80+%D0%A1%D0%A8%D0%90+%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9+%D1%80%D1%83%D0%B1%D0%BB%D1%8C%22%3Bs%3A9%3A%22pair_link%22%3Bs%3A19%3A%22%2Fcurrencies%2Fusd-rub%22%3B%7D%7D%7Ds%3A10%3A%22stack_size%22%3Ba%3A1%3A%7Bs%3A11%3A%22last_quotes%22%3Bi%3A8%3B%7D%7D; shouldUseCommentsSocket=1; geoC=RU; adsFreeSalePopUp=1; gtmFired=OK; nyxDorf=Z2phO2QsNWs%2FbDo2M34yMmAyP2QwKTAz; smd=4c8ef06a32fbfcbe328f30043a4aef73-1628488598; __cflb=0H28uv9TXEXY1dxGsSwM21AWkmXN8C3K7U3HtNhA1QX; _ym_visorc=w; __cf_bm=ffffc322599a588816d8708d1a505ae6b06d7dba-1628488600-1800-AZzcjClR8krfJHc48Xug2iMPOYdBWNkZgMf0BVPUuGPB/KnwQDmV/m6oWjvjzvAULj+JxYivYn7tpfMCaqD+zbMCLSoGurJ3+Ppar/tvrZKDpkif8L7Bcei00lI5xDL1Rg==; _ym_isad=2");
                httpRequest.AddHeader("sec-fetch-dest" , "empty");
                httpRequest.AddHeader("sec-fetch-mode" , "cors");
                httpRequest.AddHeader("sec-fetch-site" , "same-origin");
                httpRequest.AddHeader("x-requested-with" , "XMLHttpRequest");

                return httpRequest.Get(link).ToString();
            }
            catch
            {
                return null;
            }


        }

        public static List<string>[] ParsTover (string response)
        {
            try
            {
                if(response != null)
                {
                    HtmlParser htmlParser = new HtmlParser();
                    var Doc = htmlParser.ParseDocument(response);
                    int i = 0;
                    if(Doc.QuerySelector("tbody#patternTableBody>tr.noHover").TextContent.Contains("Новые модели"))
                    {
                        List<string>[] vs = new List<string>[5];
                        foreach(var item in Doc.QuerySelectorAll("tbody#patternTableBody>tr"))
                        {
                            if(item.QuerySelector("td").InnerHtml.Contains("Новые модели"))
                            {
                                continue;
                            }
                            if(item.QuerySelector("td").InnerHtml.Contains("Завершенные модели"))
                            {
                                break;
                            }
                            List<string> InerHtm = item.InnerHtml.Split('\n').Where(x => x != "").ToList();
                            InerHtm[0] = InerHtm[0].Substring(24);
                            InerHtm[0] = InerHtm[0].Remove(InerHtm[0].IndexOf(@""""));
                            if(InerHtm[0] == null || InerHtm[0] == "")
                            {
                                return null;
                            }

                            InerHtm[1] = InerHtm[1].Substring(InerHtm[1].IndexOf(@">") + 1);
                            InerHtm[1] = InerHtm[1].Remove(InerHtm[1].IndexOf(@"<"));
                            if(InerHtm[1] == null || InerHtm[1] == "")
                            {
                                return null;
                            }

                            InerHtm[2] = InerHtm[2].Substring(InerHtm[2].IndexOf(@">") + 1);
                            InerHtm[2] = InerHtm[2].Remove(InerHtm[2].IndexOf(@"<"));
                            if(InerHtm[2] == null || InerHtm[2] == ""|| InerHtm[2] == "15" || InerHtm[2] == "1H" || InerHtm[2] == "30")
                            {
                                return null; 
                            }

                            InerHtm[3] = InerHtm[3].Substring(24);
                            InerHtm[3] = InerHtm[3].Remove(InerHtm[3].IndexOf(@""""));
                            if(InerHtm[3] == null || InerHtm[3] == "")
                            {
                                return null;
                            }
                            InerHtm[3] += " Надежность";

                            InerHtm[4] = InerHtm[4].Substring(InerHtm[4].IndexOf(@">") + 1);
                            InerHtm[4] = InerHtm[4].Remove(InerHtm[4].IndexOf(@"<"));
                            if(InerHtm[4] == null || InerHtm[4] == "")
                            {
                                return null;
                            }
                            InerHtm[4] += " Свеча";

                            vs[i] = InerHtm;
                            i++;
                            
                        }
                        return vs;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }



    }
}
