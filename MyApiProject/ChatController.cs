using Microsoft.AspNetCore.Mvc;

namespace MyApiProject
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly OpenAIService _openAIService;

        public ChatController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            var response = await _openAIService.SendMessageAsync(request.ThreadId, request.UserInput);
            return Ok(response);
        }
    }

}
