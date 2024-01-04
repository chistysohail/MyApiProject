using HigLabo.Net;
using HigLabo.Core;
using System.Threading.Tasks;

namespace MyApiProject
{
    public class OpenAIService
    {
        private readonly OpenAIClient _openAIClient;
        private readonly string _assistantId;

        public OpenAIService(string apiKey, string assistantId)
        {
            _openAIClient = new OpenAIClient(apiKey);
            _assistantId = assistantId;
        }

        public async Task<string> SendMessageAsync(string threadId, string userInput)
        {
            var requestContent = new
            {
                thread_id = threadId,
                input = userInput
            };

            // Use the SendJsonAsync method from OpenAIClient
            var response = await _openAIClient.SendJsonAsync<HttpResponseMessage>(HttpMethod.Post, $"https://api.openai.com/v1/assistants/{_assistantId}/messages", requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
