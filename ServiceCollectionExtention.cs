using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Telegram_Bot_1
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services,IConfiguration configuration)
        {
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/bot/post";
            client.SetWebhookAsync(webHook).Wait();
           
            return services.AddSingleton<ITelegramBotClient>(client);
        }
    }
}
