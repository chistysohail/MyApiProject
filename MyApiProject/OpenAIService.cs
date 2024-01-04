
using HigLabo.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyApiProject
{

    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _assistantId;

        public OpenAIService(HttpClient httpClient, string apiKey, string assistantId)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _assistantId = assistantId;
        }

        public async Task<string> SendMessageAsync(string threadId, string userInput)
        {
            var requestUri = $"https://api.openai.com/v1/assistants/{_assistantId}/messages";
            var requestContent = new
            {
                thread_id = threadId,
                input = userInput
            };

            var response = await _httpClient.SendJsonAsync<HttpResponseMessage>(HttpMethod.Post, requestUri, requestContent, cancellationToken: default);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}

