using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leaf.xNet;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using System.Runtime.Remoting.Messaging;
using System.IO;
using AngleSharp.Io;

namespace ParserAvito
{
    internal class Avito
    {

        // Получение исходного кода страницы
        public static string GetPage(string link)
        {
            HttpRequest request = new HttpRequest();
            request.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");
            request.KeepAlive = true;
            request.UserAgent = Http.RandomUserAgent();
            try
            {
                var response = request.Get(link).ToString();
                return response;
            }
            catch
            {
                return null;
            }
        }
        // парсинг страницы по дивам с объявами
        public static List<string> ParseString(string Response, int maxPrice, int minPrice, string nameElement)
        {
            List<IElement> result = GetAds(Response);

            string selectorName = "h3";
            string selectorPrice = "strong.styles-module-root-LIAav";
            string selectorLink = "div.iva-item-titleStep-pdebR>div.iva-item-title-py3i_>a";
            string[][] array = new string[result.Count][];

            int maxPage = GetMaxPage(Response);

            for (int i = 0; i < result.Count; i++)
            {
                array[i] = new string[]{
                    result[i].QuerySelector(selectorName).TextContent,
                    result[i].QuerySelector(selectorPrice).TextContent,
                    result[i].QuerySelector(selectorLink).GetAttribute("href")
                };
            }
            return ParseByFilter(array, maxPrice, minPrice, nameElement);
        }

        private static List<IElement> GetAds(string Response)
        {
            HtmlParser parser = new HtmlParser();
            var doc = parser.ParseDocument(Response);
            string selector = "div.items-items-kAJAg" +
                              ">div" +
                              ">div.styles-module-theme-CRreZ";

            List<IElement> result = new List<IElement>();

            foreach (var s in doc.QuerySelectorAll(selector))
            {
                result.Add(s);
            }
            return result;
        }


        // парсинг по параметрам
        private static List<string> ParseByFilter(string[][] stringArray, int maxPrice, int minPrice, string nameElement)
        {
            List<string> result = new List<string>();

            if (nameElement == "Не важно")
            {
                nameElement = "";
            }

            // просмотр каждой страницы
            for (int i = 0; i < stringArray.Length; i++)
            {
                var PriceInt = (stringArray[i][1].Replace("₽", ""));
                if (PriceInt.ToLower().Contains("бесплатно"))
                    PriceInt = "0";
                string priceString = DeleteChar(PriceInt, ' ');
                if (priceString.Contains("Цена не указана"))
                {
                    continue;
                }
                if (stringArray[i][0].ToLower().Contains(nameElement) && Convert.ToInt32(priceString) < maxPrice && Convert.ToInt32(priceString) > minPrice)
                {
                    string withFilter = "";
                    withFilter += stringArray[i][0].ToString() + " ";
                    withFilter += stringArray[i][1].ToString() + "\n";
                    withFilter += "avito.ru" + stringArray[i][2].ToString() + "\n";
                    withFilter += "\n";
                    result.Add(withFilter);
                }
            }
            return result;
        }

        // Удаление конкретного символа
        public static string DeleteChar(string line, char sybol)
        {
            char[] chars = line.ToCharArray();
            string result = "";

            for (int j = 0; j < chars.Length; j++)
            {
                if (chars[j] != sybol)
                {
                    var boba = chars[j];
                    result += boba.ToString();
                }
            }
            return result;
        }



        public static int GetMaxPage(string Response)
        {
            HtmlParser parser = new HtmlParser();
            string SelMaxPage = "span.styles-module-text-InivV";
            var doc = parser.ParseDocument(Response);
            int maxPage = 0;
            foreach (var s in doc.QuerySelectorAll(SelMaxPage))
            {
                try
                {
                    if (Convert.ToInt32(s.TextContent) > maxPage)
                    {
                        maxPage = Convert.ToInt32(s.TextContent);
                    };
                }
                catch
                {
                    continue;
                }
            }
            return maxPage;
        }
    }
}
