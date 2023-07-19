using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.UI.Infrastructe.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string PathAndQuery(this HttpRequest httpRequest)
        {
            return httpRequest.QueryString.HasValue
                ? $"{httpRequest.Path}{httpRequest.QueryString}" :
                httpRequest.Path.ToString();
        }

    }
}