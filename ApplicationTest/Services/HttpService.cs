using System;
using System.Net.Http;

namespace ApplicationTest.Services
{
    public class HttpService
    {
        public HttpClient Client { get; }

        public HttpService()
        {
            this.Client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
    }
}
