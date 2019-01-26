using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesCupApi.Utils.Interfaces
{
    public interface IHttpHandler
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
