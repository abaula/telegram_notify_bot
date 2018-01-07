using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using TelegramNotifyBot.WebApi.Model;
using TelegramNotifyBot.WebApi.Services.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramNotifyBot.WebApi.Services
{
    internal class MessagesService : IMessagesService
    {
        private readonly ISettings _settings;
        private readonly TelegramBotClient _bot;

        public MessagesService(ISettings settings)
        {
            _settings = settings;
            _bot = new TelegramBotClient(_settings.ApiKey);
        }

        public async Task Publish(MessageDto message)
        {
            CheckSenderIsValidOrThrow(message);
            await _bot.SendTextMessageAsync(_settings.ChatId, FormatMessage(message), ParseMode.Markdown);
        }

        private void CheckSenderIsValidOrThrow(MessageDto message)
        {
            if (_settings.ValidSenders.Any(s => s.Id == message.SenderId))
                return;

            throw new SecurityException();
        }

        private string FormatMessage(MessageDto message)
        {
            var sender = _settings.ValidSenders.Single(s => s.Id == message.SenderId);
            //var emoji = "\U0001F680";
            var m = $"```\r\n{GetEmoji(message)}<{sender.Name}>:```{message.Message}{GetUrl(message)}";
            return m;
        }

        private string GetEmoji(MessageDto message)
        {
            if (string.IsNullOrEmpty(message.Emoji))
                return ParseEmpjiString("U+1F47D");

            return ParseEmpjiString(message.Emoji);
        }

        private string ParseEmpjiString(string emoji)
        {
            //Beginn at position 2 to skip the "U+" prefix
            var codePoint = int.Parse(emoji.Substring(2), System.Globalization.NumberStyles.HexNumber);
            return char.ConvertFromUtf32(codePoint);
        }

        private string GetUrl(MessageDto message)
        {
            if (string.IsNullOrEmpty(message.Url))
                return null;

            return $"\r\n[{message.Url}]";
        }
    }
}
