using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelegramNotifyBot.WebApi.Model;
using TelegramNotifyBot.WebApi.Services.Abstractions;

namespace TelegramNotifyBot.WebApi.Controllers
{
    [Route("messages")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MessagesController : Controller
    {
        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MessageDto message)
        {
            await _messagesService.Publish(message);

            return Ok();
        }
    }
}
