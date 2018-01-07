using System;

namespace TelegramNotifyBot.WebApi.Model
{
    public class MessageDto
    {
        public Guid SenderId { get; set; }
        public string Emoji { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
