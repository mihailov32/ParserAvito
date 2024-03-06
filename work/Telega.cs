using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ParserAvito.work
{
    internal class Telega
    {
        public static void Start(string link)
        {
            string token = GetToken();
            var client = new TelegramBotClient("6988411111:AAFFgGSiIH3NMQyD9M3cFvTav7Q3GI4k-hs");
            client.SendTextMessageAsync(token, link);
        }

        public static string GetToken()
        {
            string token = File.ReadAllText("Settings\\TelegramToken.txt");
            return token;
        }

    }
}
