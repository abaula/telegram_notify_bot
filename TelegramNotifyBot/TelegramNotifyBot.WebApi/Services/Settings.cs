using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TelegramNotifyBot.WebApi.Const;
using TelegramNotifyBot.WebApi.Model;
using TelegramNotifyBot.WebApi.Services.Abstractions;

namespace TelegramNotifyBot.WebApi.Services
{
    internal class Settings : ISettings
    {
        public Settings(IConfiguration configuration)
        {
            ApiKey = configuration[AppConst.Settings.TelegramApiKey];
            ChatId = Convert.ToInt32(configuration[AppConst.Settings.TelegramChatId]);
            ValidSenders = configuration.GetSection(AppConst.Settings.ValidSenders)
                .GetChildren()
                .Select(s => new ValidSenderDto
                {
                    Id = new Guid(s["Id"]),
                    Name = s["Name"]
                })
                .ToArray();
        }

        public string ApiKey { get; }
        public int ChatId { get; }
        public ValidSenderDto[] ValidSenders { get; }
    }
}
