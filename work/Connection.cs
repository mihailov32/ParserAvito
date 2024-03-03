using System.Net;

namespace ParserAvito.work
{
    internal class Connection
    {
        public static bool OK()
        {
            try
            {
                Dns.GetHostEntry("google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
