using System.Net.Http.Headers;

namespace UI
{
    public static class HttpClientFactory
    {
        public static HttpClient Create()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7226/swagger")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
