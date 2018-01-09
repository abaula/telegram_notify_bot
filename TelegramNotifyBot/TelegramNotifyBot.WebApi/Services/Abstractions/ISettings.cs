using TelegramNotifyBot.WebApi.Model;

namespace TelegramNotifyBot.WebApi.Services.Abstractions
{
    public interface ISettings
    {
        string ApiKey { get; }
        int ChatId { get; }
        string DefaultEmoji { get; }
        ValidSenderDto[] ValidSenders { get; }
    }
}
