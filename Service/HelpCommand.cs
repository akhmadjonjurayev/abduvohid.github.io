using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot_1.Service
{
    internal class HelpCommand : TelegramCommand
    {
        public override string Name => "help";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("mainly"),
                        new KeyboardButton("next")
                    },
                    new[]
                    {
                        new KeyboardButton("photos")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "help" ,parseMode : ParseMode.Markdown,replyMarkup : keyBoard);
        }
        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(Name);
        }
    }
}