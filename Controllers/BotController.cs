using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram_Bot_1.Service;

namespace Telegram_Bot_1.Controllers
{
    [Route("api/bot")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient _client;
        private readonly ICommandService _command;
        public BotController(ITelegramBotClient client,ICommandService command)
        {
            _command = command;
            _client = client;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }
        [HttpPost("post")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok();
            var message = update.Message;
            foreach(var command in _command.Get())
            {
                if(command.Contains(message))
                {
                    await command.Execute(message, _client);
                    break;
                }
            }
            return Ok();
        }
    }
}
