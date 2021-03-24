using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram_Bot_1.Service
{
    public interface ICommandService
    {
        List<TelegramCommand> Get();
    }
}
