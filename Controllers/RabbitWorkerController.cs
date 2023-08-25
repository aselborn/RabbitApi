using Microsoft.AspNetCore.Mvc;
using RabbitApi.Models;
using RabbitApi.Services;
using System.Net.Mime;

namespace RabbitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitWorkerController : Controller
    {
        IAddmessageService _addmessageService;
        IConsumeService _consumeService;
        public RabbitWorkerController(IAddmessageService addmessageService, IConsumeService consumeService) 
        { 
            _addmessageService = addmessageService;
            _consumeService = consumeService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces("application/problem+json", MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SimpleMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(SimpleMessage message)
        {
            _addmessageService.Addmessage(message);
            return Ok();
        }

        
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SimpleMessage>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<List<SimpleMessage>> GetAllMessages()
        {
            return _consumeService.ReadMessages();
            
        }
    }
}
