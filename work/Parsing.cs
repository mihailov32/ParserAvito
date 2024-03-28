using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserAvito.work
{
    internal class Parsing
    {
        public static string[][] GetPage(IWebDriver driver)
        {
            try
            {
                var page = driver.FindElements(By.CssSelector("[data-marker='item']"));
                string[][] array = new string[page.Count][];
                for (int i = 0; i < page.Count; i++)
                {
                    array[i] = new string[]{
                        page[i].FindElement(By.TagName("h3")).Text,
                        page[i].FindElement(By.CssSelector("[itemprop='price']")).GetAttribute("content").ToString(),
                        page[i].FindElement(By.CssSelector("[itemprop='url']")).GetAttribute("href").ToString()
                        };
                    Task.Delay(1000);
                }
                return array;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> Filtration(string[][] array, int maxPrice, int minPrice, string nameElement)
        {
            List<string> result = new List<string>();
            if (nameElement == "Не важно")
            {
                nameElement = "";
            }
            for (int i = 0; i < array.Length; i++)
            {
                var priceInt = array[i][1];
                if (priceInt.ToLower().Contains("бесплатно"))
                    priceInt = "0";
                if (priceInt.Contains("Цена не указана"))
                    continue;
                if (array[i][0].ToLower().Contains(nameElement) && Convert.ToInt32(priceInt) > minPrice && Convert.ToInt32(priceInt) < maxPrice)
                {
                    string withFilter = "";
                    withFilter += array[i][0].ToString() + " ";
                    withFilter += array[i][1].ToString() + "\n";
                    withFilter += array[i][2].ToString() + "\n";
                    result.Add(withFilter);
                }
            }
            Task.Delay(1000);
            return result;
        }

        public static int GetMaxGage(IWebDriver driver)
        {

            int maxPage = 0;
            var list = driver.FindElements(By.ClassName("styles-module-text-InivV"));
            foreach (var item in list)
            {
                try
                {
                    if (Convert.ToInt32(item.Text) > maxPage)
                    {
                        maxPage = Convert.ToInt32(item.Text);
                    }
                }
                catch
                {
                    continue;
                }
            }
            Task.Delay(1000);
            return maxPage;
        }
    }
}
