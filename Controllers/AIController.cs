using API.DTOs.AI.Request;
using API.DTOs.AI.Response;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IAIAssistantService _aIAssistantService;

        public AIController(IAIAssistantService aIAssistantService)
        {
            _aIAssistantService = aIAssistantService;
        }

        [HttpPost("assistant/message")]
        public async Task<ActionResult<PostMessageResponseDTO>> PostMessage([FromBody] PostMessageRequestDTO requestBody)
        {
            string textMessageResponse = await _aIAssistantService.SendMessageAndGetResponse(requestBody.TextMessage);

            PostMessageResponseDTO response = new()
            {
                TextMessage = textMessageResponse
            };

            return Ok(response);
        }
    }
}