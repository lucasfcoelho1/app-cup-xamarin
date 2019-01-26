using MoviesCupApi.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCupApi.Utils
{
    public class HttpConnection
    {
        private IHttpHandler _httpHandler;

        public HttpConnection(IHttpHandler httpClient)
        {
            _httpHandler = httpClient;
        }
    }
}
