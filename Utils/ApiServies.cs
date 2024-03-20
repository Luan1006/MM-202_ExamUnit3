using System.Text.Json;

namespace MM202ExamUnit3.Utils
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetApiResponse(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public JsonDocument ParseJsonString(string json)
        {
            return JsonDocument.Parse(json);
        }
    }
}