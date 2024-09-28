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
        public async Task<ActionResult<string>> PostMessage([FromBody] string requestBody)
        {
            return Ok(await _aIAssistantService.SendMessageAndGetResponse(requestBody));
        }
    }
}