using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocialServices.Utilities
{
    public static class TinyURL
    {
        public static string GetTinyUrl(string url) { 
            Uri address = new Uri("http://tinyurl.com/api-create.php?url=" + url);
            WebClient client = new WebClient();
            return client.DownloadString(address);
        }
    }
}
