using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram_Bot_1.Service
{
    public class CommandService:ICommandService
    {
        private readonly List<TelegramCommand> _commands;
        public CommandService()
        {
            _commands = new List<TelegramCommand>
            {
                new HelpCommand()
            };
        }

    public List<TelegramCommand> Get() => _commands;
    }
}
